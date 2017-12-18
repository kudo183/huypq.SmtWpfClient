using huypq.SmtShared;
using huypq.SmtWpfClient.Abstraction;
using System;

namespace huypq.SmtWpfClientSQL
{
    public static class DataServiceUtils
    {
        public static IDataProvider GetDataController(string type)
        {
            var dataProviderType = Settings.DataControllerAssembly.GetType(
                string.Format(Settings.DataControllerNamespacePattern, type), true, true);

            return Activator.CreateInstance(dataProviderType) as IDataProvider;
        }

        public static T1 ProcessResult<T, T1>(T response) where T : IDto where T1 : IDataModel<T>, new()
        {
            var result = new T1();
            result.FromDto(response);
            result.SetCurrentValueAsOriginalValue();

            return result;
        }

        public static PagingResultDto<T1> ProcessPagingResult<T, T1>(PagingResultDto<T> response) where T : IDto where T1 : IDataModel<T>, new()
        {
            var result = new PagingResultDto<T1>()
            {
                LastUpdateTime = response.LastUpdateTime,
                PageCount = response.PageCount,
                PageIndex = response.PageIndex,
                TotalItemCount = response.TotalItemCount
            };
            foreach (var item in response.Items)
            {
                var dataModel = new T1();
                dataModel.FromDto(item);
                dataModel.SetCurrentValueAsOriginalValue();
                result.Items.Add(dataModel);
            }
            
            return result;
        }
    }
}
