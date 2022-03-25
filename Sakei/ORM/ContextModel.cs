using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Sakei.ORM
{
    public partial class ContextModel : DbContext
    {
        public ContextModel()
            : base("name=ORM")
        {
        }

        public virtual DbSet<AdminAccounts> AdminAccounts { get; set; }
        public virtual DbSet<Malls> Malls { get; set; }
        public virtual DbSet<MessageBoards> MessageBoards { get; set; }
        public virtual DbSet<PointsLists> PointsLists { get; set; }
        public virtual DbSet<ShoppingLists> ShoppingLists { get; set; }
        public virtual DbSet<TestDatabases> TestDatabases { get; set; }
        public virtual DbSet<TestTypes> TestTypes { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserAccounts> UserAccounts { get; set; }
        public virtual DbSet<UserAnswers> UserAnswers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminAccounts>()
                .Property(e => e.AdminName)
                .IsUnicode(false);

            modelBuilder.Entity<AdminAccounts>()
                .Property(e => e.AdminAccount)
                .IsUnicode(false);

            modelBuilder.Entity<AdminAccounts>()
                .Property(e => e.AdminPassword)
                .IsUnicode(false);

            modelBuilder.Entity<AdminAccounts>()
                .Property(e => e.AdminPasswordSalt)
                .IsUnicode(false);

            modelBuilder.Entity<AdminAccounts>()
                .Property(e => e.AdminEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Malls>()
                .Property(e => e.ItemName)
                .IsUnicode(false);

            modelBuilder.Entity<PointsLists>()
                .Property(e => e.Correct)
                .IsFixedLength();

            modelBuilder.Entity<TestDatabases>()
                .Property(e => e.TestAnswer)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccounts>()
                .Property(e => e.UserAccount)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccounts>()
                .Property(e => e.UserPassword)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccounts>()
                .Property(e => e.UserPasswordSalt)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccounts>()
                .Property(e => e.UserEmail)
                .IsUnicode(false);

            modelBuilder.Entity<UserAnswers>()
                .Property(e => e.UserAnswer)
                .IsFixedLength();
        }
    }
}
