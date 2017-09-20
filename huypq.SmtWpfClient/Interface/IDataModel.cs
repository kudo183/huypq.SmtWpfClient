using huypq.SmtShared;
using System.ComponentModel;

namespace huypq.SmtWpfClient.Abstraction
{
    public interface IDataModel<T> : INotifyPropertyChanged where T : IDto
    {
        int ID { get; set; }
        int TenantID { get; set; }
        int State { get; set; }
        long CreateTime { get; set; }
        long LastUpdateTime { get; set; }

        string DisplayText { get; }
        bool HasChange();
        void Update(object obj);
        void SetCurrentValueAsOriginalValue();

        T ToDto();
        void FromDto(T dto);
    }
}
