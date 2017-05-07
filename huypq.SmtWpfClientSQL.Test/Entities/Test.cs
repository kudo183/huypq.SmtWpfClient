namespace huypq.SmtWpfClientSQL.Test
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Test : DbContext, IDbContext
    {
        public Test()
            : base("name=Test")
        {
        }

        public virtual DbSet<SmtDeletedItem> SmtDeletedItem { get; set; }
        public virtual DbSet<SmtTable> SmtTable { get; set; }
        public virtual DbSet<SmtTenant> SmtTenant { get; set; }
        public virtual DbSet<SmtUser> SmtUser { get; set; }
        public virtual DbSet<SmtUserClaim> SmtUserClaim { get; set; }
        public virtual DbSet<TestChildData> TestChildData { get; set; }
        public virtual DbSet<TestData> TestData { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SmtTable>()
                .Property(e => e.TableName)
                .IsUnicode(false);

            modelBuilder.Entity<SmtTenant>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<SmtTenant>()
                .Property(e => e.PasswordHash)
                .IsUnicode(false);

            modelBuilder.Entity<SmtTenant>()
                .Property(e => e.TenantName)
                .IsUnicode(false);

            modelBuilder.Entity<SmtTenant>()
                .HasMany(e => e.SmtUsers)
                .WithRequired(e => e.SmtTenant)
                .HasForeignKey(e => e.TenantID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SmtTenant>()
                .HasMany(e => e.SmtUserClaims)
                .WithRequired(e => e.SmtTenant)
                .HasForeignKey(e => e.TenantID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SmtUser>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<SmtUser>()
                .Property(e => e.PasswordHash)
                .IsUnicode(false);

            modelBuilder.Entity<SmtUser>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<SmtUser>()
                .HasMany(e => e.SmtUserClaims)
                .WithRequired(e => e.SmtUser)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SmtUserClaim>()
                .Property(e => e.Claim)
                .IsUnicode(false);

            modelBuilder.Entity<TestData>()
                .HasMany(e => e.TestChildDatas)
                .WithRequired(e => e.TestData)
                .WillCascadeOnDelete(false);
        }
    }
}
