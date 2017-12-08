using huypq.SmtShared;
using huypq.wpf.Utils;

namespace huypq.SmtWpfClient.Abstraction
{
    public abstract class BaseDataModel<T> : BindableObject, IDataModel<T> where T : IDto
    {
        public int ID { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

        public int State { get; set; }

        public abstract bool HasChange();
        public abstract void SetCurrentValueAsOriginalValue();
        public abstract void Update(object obj);

        public virtual string DisplayText
        {
            get { return ID.ToString(); }
        }
        
        public virtual T ToDto()
        {
            throw new System.NotImplementedException();
        }

        public virtual void FromDto(T dto)
        {
            throw new System.NotImplementedException();
        }
    }
}
