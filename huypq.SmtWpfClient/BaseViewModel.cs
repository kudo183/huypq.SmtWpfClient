using System;
using System.Collections.Generic;
using SimpleDataGrid.ViewModel;
using System.Linq;
using System.Windows;
using SimpleDataGrid;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using huypq.SmtShared;
using huypq.SmtShared.Constant;

namespace huypq.SmtWpfClient.Abstraction
{
    public abstract class BaseViewModel<T> : IEditableGridViewModel<T> where T : class, IDto, new()
    {
        protected string _debugName;

        protected readonly List<T> _originalEntities = new List<T>();

        private IDataService _dataService;
        public IDataService DataService
        {
            get
            {
                if (_dataService == null)
                {
                    _dataService = ServiceLocator.Get<IDataService>();
                }
                return _dataService;
            }
            private set { }
        }

        public BaseViewModel()
        {
            _debugName = NameManager.Instance.GetViewModelName<T>();

            Entities = new ObservableCollectionEx<T>();
            Entities.CollectionChanged += Entities_CollectionChanged;
            HeaderFilters = new List<HeaderFilterBaseModel>();
            PagerViewModel = new PagerViewModel();

            PagerViewModel.ActionCurrentPageIndexChanged = Load;
            PagerViewModel.ActionPageSizeChanged = Load;

            SelectedValuePath = nameof(IDto.ID);
        }

        protected void AddHeaderFilter(HeaderFilterBaseModel filter)
        {
            HeaderFilters.Add(filter);
            filter.ActionFilterValueChanged = Load;
            filter.ActionIsUsedChanged = Load;
            filter.ActionIsSortedChanged = Load;
            filter.ActionPredicateChanged = Load;
        }

        protected virtual void ProccessHeaderAddCommand(object view, string title, Action AfterCloseDialogAction)
        {
            var w = new Window()
            {
                Title = title,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                Content = view
            };
            w.ShowDialog();

            AfterCloseDialogAction?.Invoke();
        }

        protected virtual void ProcessDtoBeforeAddToEntities(T dto)
        {

        }

        protected virtual void ProcessNewAddedDto(T dto)
        {

        }

        protected virtual void BeforeLoad()
        {

        }

        protected virtual void AfterLoad()
        {

        }

        #region IBaseViewModel interface
        public bool IsValid { get; set; }

        public ObservableCollectionEx<T> Entities { get; set; }

        public object ParentItem { get; set; }

        private string sysMsg;

        public string SysMsg
        {
            get { return string.Format("{0:hh:mm:ss.fff}  {1}", DateTime.Now, sysMsg); }
            set
            {
                //if (sysMsg == value)
                //    return;

                sysMsg = value;
                OnPropertyChanged();
            }
        }

        private string msg;

        public string Msg
        {
            get { return msg; }
            set
            {
                if (msg == value)
                    return;

                msg = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string SelectedValuePath { get; set; }

        private object _selectedValue;

        public object SelectedValue
        {
            get { return _selectedValue; }
            set
            {
                if (_selectedValue == value)
                {
                    return;
                }

                _selectedValue = value;

                OnSelectedValueChanged();
                RaiseCommandCanExecuteChanged();
                ActionSelectedValueChanged?.Invoke(_selectedValue);
                OnPropertyChanged();
            }
        }

        public T SelectedItem
        {
            get
            {
                if (_selectedValue == null)
                    return null;

                return Entities.First(p => p.ID == (int)_selectedValue);
            }
        }

        public object GetSelectedItem()
        {
            return SelectedItem;
        }

        public Action<object> ActionSelectedValueChanged { get; set; }

        public List<HeaderFilterBaseModel> HeaderFilters { get; set; }

        public PagerViewModel PagerViewModel { get; set; }

        public SimpleCommand LoadCommand { get; set; }

        public SimpleCommand SaveCommand { get; set; }

        protected virtual void RaiseCommandCanExecuteChanged() { }

        protected virtual void OnSelectedValueChanged() { }

        public void Load()
        {
            Logger.Instance.Debug(_debugName + " BaseViewModel Load", Logger.Categories.UI);

            BeforeLoad();

            PagingResultDto<T> result;

            var qe = new QueryBuilder.QueryExpression();
            qe.PageIndex = PagerViewModel.CurrentPageIndex;
            qe.PageSize = PagerViewModel.PageSize;

            try
            {
                qe.WhereOptions = WhereOptionsFromHeaderFilter(HeaderFilters);
                qe.OrderOptions = OrderOptionsFromHeaderFilter(HeaderFilters);

                result = DataService.Get<T>(qe);

                _originalEntities.Clear();

                foreach (var dto in result.Items)
                {
                    ProcessDtoBeforeAddToEntities(dto);
                    _originalEntities.Add(dto);
                }

                Entities.Reset(result.Items);

                PagerViewModel.ItemCount = Entities.Count;
                PagerViewModel.PageCount = result.PageCount;
                PagerViewModel.SetCurrentPageIndexWithoutAction(result.PageIndex);

                AfterLoad();

                SysMsg = "OK";
            }
            catch (System.Net.WebException ex)
            {
                if (ex.Response != null)
                {
                    var statusCode = ((System.Net.HttpWebResponse)ex.Response).StatusCode;
                    SysMsg = string.Format("[{0}] {1}", statusCode, new System.IO.StreamReader(ex.Response.GetResponseStream()).ReadToEnd());
                }
                else
                {
                    SysMsg = ex.Message;
                }
            }
            catch (Exception ex)
            {
                SysMsg = ex.Message;
            }
        }

        public void Save()
        {
            var changedItems = new List<T>();

            foreach (var entity in _originalEntities)
            {
                if (Entities.Any(p => p.ID == entity.ID) == false)
                {
                    entity.State = DtoState.Delete;
                    changedItems.Add(entity);
                }
            }

            foreach (var entity in Entities)
            {
                if (entity.ID == 0)
                {
                    entity.State = DtoState.Add;
                    changedItems.Add(entity);
                }
                else if (entity.HasChange())
                {
                    entity.State = DtoState.Update;
                    changedItems.Add(entity);
                }
            }

            if (changedItems.Count == 0)
            {
                return;
            }

            try
            {
                var response = DataService.Save(changedItems);
                SysMsg = response;
                Load();
            }
            catch (System.Net.WebException ex)
            {
                if (ex.Response != null)
                {
                    var statusCode = ((System.Net.HttpWebResponse)ex.Response).StatusCode;
                    SysMsg = string.Format("[{0}] {1}", statusCode, new System.IO.StreamReader(ex.Response.GetResponseStream()).ReadToEnd());
                }
                else
                {
                    SysMsg = ex.Message;
                }
            }
            catch (Exception ex)
            {
                SysMsg = ex.Message;
            }
        }

        public virtual void LoadReferenceData()
        {
        }

        private void Entities_CollectionChanged(
            object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                ProcessNewAddedDto(e.NewItems[0] as T);
            }
        }
        #endregion

        private List<QueryBuilder.WhereExpression.IWhereOption> WhereOptionsFromHeaderFilter(
            List<HeaderFilterBaseModel> headerFilters)
        {
            var result = new List<QueryBuilder.WhereExpression.IWhereOption>();

            foreach (var filter in headerFilters.Where(p => p.IsUsed == true))
            {
                var wo = WhereOptionFromHeaderFilter(filter);
                if (wo != null)
                {
                    result.Add(wo);
                }
            }

            return result;
        }

        private QueryBuilder.WhereExpression.IWhereOption WhereOptionFromHeaderFilter(
            HeaderFilterBaseModel filter)
        {
            if (filter.FilterValue != null && filter.PropertyType == typeof(string))
            {
                var wo = new QueryBuilder.WhereExpression.WhereOptionString()
                {
                    PropertyPath = filter.PropertyName,
                    Value = (string)filter.FilterValue,
                    Predicate = filter.Predicate
                };
                return wo;
            }
            else if (filter.FilterValue != null && filter.PropertyType == typeof(int))
            {
                int number;
                if (int.TryParse(filter.FilterValue.ToString(), out number) == true)
                {
                    var wo = new QueryBuilder.WhereExpression.WhereOptionInt()
                    {
                        PropertyPath = filter.PropertyName,
                        Value = number,
                        Predicate = filter.Predicate
                    };
                    return wo;
                }
                else
                {
                    throw new ArgumentException(string.Format("filter: {0} not valid", filter.Name));
                }
            }
            else if (filter.PropertyType == typeof(int?))
            {
                var wo = new QueryBuilder.WhereExpression.WhereOptionNullableInt()
                {
                    PropertyPath = filter.PropertyName
                };
                if (filter.FilterValue == null)
                {
                    if (filter.Predicate == QueryBuilder.WhereExpression.Equal || filter.Predicate == QueryBuilder.WhereExpression.NotEqual)
                    {
                        wo.Predicate = filter.Predicate;
                        wo.Value = null;
                    }
                    else
                    {
                        throw new ArgumentException(string.Format("filter: {0} not valid", filter.Name));
                    }
                }
                else
                {
                    int number;
                    if (int.TryParse(filter.FilterValue.ToString(), out number) == true)
                    {
                        wo.Predicate = filter.Predicate;
                        wo.Value = number;
                    }
                    else
                    {
                        throw new ArgumentException(string.Format("filter: {0} not valid", filter.Name));
                    }
                }
                return wo;
            }
            else if (filter.FilterValue != null && filter.PropertyType == typeof(long))
            {
                long number;
                if (long.TryParse(filter.FilterValue.ToString(), out number) == true)
                {
                    var wo = new QueryBuilder.WhereExpression.WhereOptionLong()
                    {
                        PropertyPath = filter.PropertyName,
                        Value = number,
                        Predicate = filter.Predicate
                    };
                    return wo;
                }
                else
                {
                    throw new ArgumentException(string.Format("filter: {0} not valid", filter.Name));
                }
            }
            else if (filter.PropertyType == typeof(long?))
            {
                var wo = new QueryBuilder.WhereExpression.WhereOptionNullableLong()
                {
                    PropertyPath = filter.PropertyName
                };
                if (filter.FilterValue == null)
                {
                    if (filter.Predicate == QueryBuilder.WhereExpression.Equal || filter.Predicate == QueryBuilder.WhereExpression.NotEqual)
                    {
                        wo.Predicate = filter.Predicate;
                        wo.Value = null;
                    }
                    else
                    {
                        throw new ArgumentException(string.Format("filter: {0} not valid", filter.Name));
                    }
                }
                else
                {
                    long number;
                    if (long.TryParse(filter.FilterValue.ToString(), out number) == true)
                    {
                        wo.Predicate = filter.Predicate;
                        wo.Value = number;
                    }
                    else
                    {
                        throw new ArgumentException(string.Format("filter: {0} not valid", filter.Name));
                    }
                }
                return wo;
            }
            else if (filter.FilterValue != null && filter.PropertyType == typeof(bool))
            {
                if (filter.Predicate == QueryBuilder.WhereExpression.Equal || filter.Predicate == QueryBuilder.WhereExpression.NotEqual)
                {
                    var wo = new QueryBuilder.WhereExpression.WhereOptionBool()
                    {
                        Predicate = filter.Predicate,
                        PropertyPath = filter.PropertyName,
                        Value = (bool)filter.FilterValue
                    };
                    return wo;
                }
                else
                {
                    throw new ArgumentException(string.Format("filter: {0} not valid", filter.Name));
                }
            }
            else if (filter.PropertyType == typeof(bool?))
            {
                if (filter.Predicate == QueryBuilder.WhereExpression.Equal || filter.Predicate == QueryBuilder.WhereExpression.NotEqual)
                {
                    var wo = new QueryBuilder.WhereExpression.WhereOptionNullableBool()
                    {
                        Predicate = filter.Predicate,
                        PropertyPath = filter.PropertyName,
                        Value = (bool?)filter.FilterValue
                    };
                    return wo;
                }
                else
                {
                    throw new ArgumentException(string.Format("filter: {0} not valid", filter.Name));
                }
            }
            else if (filter.FilterValue != null && filter.PropertyType == typeof(DateTime))
            {
                var wo = new QueryBuilder.WhereExpression.WhereOptionDate()
                {
                    Predicate = filter.Predicate,
                    PropertyPath = filter.PropertyName,
                    Value = (DateTime)filter.FilterValue
                };
                return wo;
            }
            else if (filter.PropertyType == typeof(DateTime?))
            {
                var wo = new QueryBuilder.WhereExpression.WhereOptionNullableDate()
                {
                    Predicate = filter.Predicate,
                    PropertyPath = filter.PropertyName,
                    Value = (DateTime?)filter.FilterValue
                };
                return wo;
            }
            else if (filter.FilterValue != null && filter.PropertyType == typeof(TimeSpan))
            {
                var wo = new QueryBuilder.WhereExpression.WhereOptionTime()
                {
                    Predicate = filter.Predicate,
                    PropertyPath = filter.PropertyName,
                    Value = (TimeSpan)filter.FilterValue
                };
                return wo;
            }
            else if (filter.PropertyType == typeof(TimeSpan?))
            {
                var wo = new QueryBuilder.WhereExpression.WhereOptionNullableTime()
                {
                    Predicate = filter.Predicate,
                    PropertyPath = filter.PropertyName,
                    Value = (TimeSpan?)filter.FilterValue
                };
                return wo;
            }

            return null;
        }

        private List<QueryBuilder.OrderByExpression.OrderOption> OrderOptionsFromHeaderFilter(
            List<HeaderFilterBaseModel> headerFilters)
        {
            var result = new List<QueryBuilder.OrderByExpression.OrderOption>();

            foreach (var filter in headerFilters)
            {
                switch (filter.IsSorted)
                {
                    case HeaderFilterBaseModel.SortDirection.Ascending:
                        result.Add(new QueryBuilder.OrderByExpression.OrderOption()
                        {
                            PropertyPath = filter.SortPropertyName,
                            IsAscending = true
                        });
                        break;
                    case HeaderFilterBaseModel.SortDirection.Descending:
                        result.Add(new QueryBuilder.OrderByExpression.OrderOption()
                        {
                            PropertyPath = filter.SortPropertyName,
                            IsAscending = false
                        });
                        break;
                }
            }

            return result;
        }
    }
}
