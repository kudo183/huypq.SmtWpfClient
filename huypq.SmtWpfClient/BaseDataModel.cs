using System.ComponentModel;
using System.Runtime.CompilerServices;
using huypq.SmtShared;

namespace huypq.SmtWpfClient.Abstraction
{
    public abstract class BaseDataModel<T> : IDataModel<T> where T : IDto
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

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            RaiseDependentPropertyChanged(name);
        }

        protected virtual void RaiseDependentPropertyChanged(string basePropertyName) { }

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
