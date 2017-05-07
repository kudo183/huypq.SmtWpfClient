using System.Data.Entity;

namespace huypq.SmtWpfClientSQL
{
    public interface IDbContext
    {
        DbSet<SmtDeletedItem> SmtDeletedItem { get; set; }
        DbSet<SmtTable> SmtTable { get; set; }
    }
}
