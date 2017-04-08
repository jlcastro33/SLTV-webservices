using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartLeopard.Dal.Entities;

namespace SmartLeopard.Dal
{ 
    public class DatabaseContext : DbContext
    {
        private IDatabaseInitializer<DatabaseContext> CreateDatabaseInitiazer(bool allowToUpdate)
        {
            if (allowToUpdate) return new DatabaseInitializerCreateUpdate();
            return  new DatabaseInitializerOnlyCreate();
        }

        public DatabaseContext() : base("DatabaseConnectionString")
        {
            var allowDatabaseSchemeUpdate = true;
            Database.SetInitializer(new DropCreateDatabaseAlways<DatabaseContext>()); //CreateDatabaseInitiazer(allowDatabaseSchemeUpdate));
        }

        public DbSet<Device> Devices { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
