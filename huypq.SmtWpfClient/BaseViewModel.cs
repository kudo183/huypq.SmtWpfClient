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
            PagerViewModel = new PagerViewModel()
            {
                IsEnablePaging = true,
                CurrentPageIndex = 1,
                ItemCount = 0,
                PageCount = 0
            };

            PagerViewModel.ActionCurrentPageIndexChanged = Load;
            PagerViewModel.ActionIsEnablePagingChanged = Load;

            SelectedValuePath = nameof(IDto.ID);
        }

        protected void AddHeaderFilter(HeaderFilterBaseModel filter)
        {
            HeaderFilters.Add(filter);
            filter.ActionFilterValueChanged = Load;
            filter.ActionIsUsedChanged = Load;
            filter.ActionIsSortedChanged = Load;
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
            qe.PageIndex = PagerViewModel.IsEnablePaging ? PagerViewModel.CurrentPageIndex : 0;
            qe.PageSize = 30;

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

                Msg = "OK";
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
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
                Msg = response;
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
            }
            Load();
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
                if (filter.FilterValue != null && filter.PropertyType == typeof(string))
                {
                    var wo = new QueryBuilder.WhereExpression.WhereOptionString()
                    {
                        PropertyPath = filter.PropertyName,
                        Value = (string)filter.FilterValue
                    };
                    wo.Predicate = QueryBuilder.WhereExpression.GetPredicateFromText(wo.Value);
                    wo.Value = wo.Value.Substring(wo.Predicate.Length);
                    result.Add(wo);
                }
                else if (filter.FilterValue != null && filter.PropertyType == typeof(int))
                {
                    var text = filter.FilterValue.ToString();
                    var wo = new QueryBuilder.WhereExpression.WhereOptionInt()
                    {
                        PropertyPath = filter.PropertyName
                    };
                    wo.Predicate = QueryBuilder.WhereExpression.GetPredicateFromText(text);
                    int number;
                    if (int.TryParse(text.Substring(wo.Predicate.Length), out number) == true)
                    {
                        wo.Value = number;
                        result.Add(wo);
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
                        wo.Predicate = "=";
                        wo.Value = null;
                    }
                    else
                    {
                        var text = filter.FilterValue.ToString();
                        wo.Predicate = QueryBuilder.WhereExpression.GetPredicateFromText(text);
                        int number;
                        if (int.TryParse(text.Substring(wo.Predicate.Length), out number) == true)
                        {
                            wo.Value = number;
                            result.Add(wo);
                        }
                        else
                        {
                            throw new ArgumentException(string.Format("filter: {0} not valid", filter.Name));
                        }
                    }
                }
                else if (filter.FilterValue != null && filter.PropertyType == typeof(long))
                {
                    var text = filter.FilterValue.ToString();
                    var wo = new QueryBuilder.WhereExpression.WhereOptionLong()
                    {
                        PropertyPath = filter.PropertyName
                    };
                    wo.Predicate = QueryBuilder.WhereExpression.GetPredicateFromText(text);
                    long number;
                    if (long.TryParse(text.Substring(wo.Predicate.Length), out number) == true)
                    {
                        wo.Value = number;
                        result.Add(wo);
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
                        wo.Predicate = "=";
                        wo.Value = null;
                    }
                    else
                    {
                        var text = filter.FilterValue.ToString();
                        wo.Predicate = QueryBuilder.WhereExpression.GetPredicateFromText(text);
                        long number;
                        if (long.TryParse(text.Substring(wo.Predicate.Length), out number) == true)
                        {
                            wo.Value = number;
                            result.Add(wo);
                        }
                        else
                        {
                            throw new ArgumentException(string.Format("filter: {0} not valid", filter.Name));
                        }
                    }
                }
                else if (filter.FilterValue != null && filter.PropertyType == typeof(bool))
                {
                    result.Add(new QueryBuilder.WhereExpression.WhereOptionBool()
                    {
                        Predicate = "=",
                        PropertyPath = filter.PropertyName,
                        Value = (bool)filter.FilterValue
                    });
                }
                else if (filter.PropertyType == typeof(bool?))
                {
                    result.Add(new QueryBuilder.WhereExpression.WhereOptionNullableBool()
                    {
                        Predicate = "=",
                        PropertyPath = filter.PropertyName,
                        Value = (bool?)filter.FilterValue
                    });
                }
                else if (filter.FilterValue != null && filter.PropertyType == typeof(DateTime))
                {
                    result.Add(new QueryBuilder.WhereExpression.WhereOptionDate()
                    {
                        Predicate = "=",
                        PropertyPath = filter.PropertyName,
                        Value = (DateTime)filter.FilterValue
                    });
                }
                else if (filter.PropertyType == typeof(DateTime?))
                {
                    result.Add(new QueryBuilder.WhereExpression.WhereOptionNullableDate()
                    {
                        Predicate = "=",
                        PropertyPath = filter.PropertyName,
                        Value = (DateTime?)filter.FilterValue
                    });
                }
                else if (filter.FilterValue != null && filter.PropertyType == typeof(TimeSpan))
                {
                    result.Add(new QueryBuilder.WhereExpression.WhereOptionTime()
                    {
                        Predicate = "=",
                        PropertyPath = filter.PropertyName,
                        Value = (TimeSpan)filter.FilterValue
                    });
                }
                else if (filter.PropertyType == typeof(TimeSpan?))
                {
                    result.Add(new QueryBuilder.WhereExpression.WhereOptionNullableTime()
                    {
                        Predicate = "=",
                        PropertyPath = filter.PropertyName,
                        Value = (TimeSpan?)filter.FilterValue
                    });
                }
            }

            return result;
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
