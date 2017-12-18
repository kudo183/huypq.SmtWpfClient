using huypq.QueryBuilder;
using huypq.SmtShared;
using System.Reflection;

namespace huypq.SmtWpfClientSQL
{
    public static class Settings
    {
        public static string DataControllerNamespacePattern;
        public static Assembly DataControllerAssembly;

        public static OrderByExpression.OrderOption DefaultOrderOption = new OrderByExpression.OrderOption()
        {
            PropertyPath = nameof(IDto.ID),
            IsAscending = false
        };

        public static string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PhuDinh;Integrated Security=True";
    }
}
