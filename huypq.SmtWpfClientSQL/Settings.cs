using huypq.QueryBuilder;
using huypq.SmtShared;

namespace huypq.SmtWpfClientSQL
{
    public static class Settings
    {
        public static string DataControllerNamespacePattern;

        public static OrderByExpression.OrderOption DefaultOrderOption = new OrderByExpression.OrderOption()
        {
            PropertyPath = nameof(IDto.ID),
            IsAscending = false
        };

        public static string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PhuDinh;Integrated Security=True";
    }
}
