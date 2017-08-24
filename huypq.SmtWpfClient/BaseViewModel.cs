using System;
using System.Collections.Generic;
using SimpleDataGrid.ViewModel;
using System.Linq;
using huypq.SmtShared;
using huypq.SmtShared.Constant;
using huypq.wpf.Utils;
using Microsoft.Extensions.Logging;

namespace huypq.SmtWpfClient.Abstraction
{
    public abstract class BaseViewModel<T> : EditableGridViewModel<T> where T : class, IDto, new()
    {
        ILogger _logger = ServiceLocator.Get<ILoggerProvider>().CreateLogger<BaseViewModel<T>>();

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

            SelectedValuePath = nameof(IDto.ID);
        }

        #region IBaseViewModel interface

        public override void Load()
        {
            _logger.LogDebug("Load {0}", _debugName);

            BeforeLoad();

            PagingResultDto<T> result;

            try
            {
                var qe = new QueryBuilder.QueryExpression()
                {
                    PageIndex = PagerViewModel.CurrentPageIndex,
                    PageSize = PagerViewModel.PageSize,
                    WhereOptions = WhereOptionsFromHeaderFilter(HeaderFilters),
                    OrderOptions = OrderOptionsFromHeaderFilter(HeaderFilters)
                };

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

        public override void Save()
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

        #endregion
    }
}
