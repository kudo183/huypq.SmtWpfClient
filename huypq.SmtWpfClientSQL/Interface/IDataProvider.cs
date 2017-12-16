namespace huypq.SmtWpfClientSQL
{
    public interface IDataProvider
    {
        object ActionInvoker(string actionName, object parameters);
    }
}
