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

        public static string ConnectionString = "";

        public static void SetConnection(string dataSource, string dbName)
        {
            ConnectionString = $"Data Source={dataSource};Initial Catalog={dbName};Integrated Security=True";
        }

        public static void SetConnection(string server, string dbName, string user, string pass)
        {
            ConnectionString = $"Server={server};Database={dbName};User Id={user};Password={pass}";
        }
    }
}
