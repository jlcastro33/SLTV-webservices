using System.Data.Common;
using System.Data.Entity.Migrations.History;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.Migrations.Sql;
using MySql.Data.Entity;

namespace SmartLeopard.Dal.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SmartLeopard.Dal.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            SetSqlGenerator("MySql.Data.MySqlClient", new MyOwnMySqlMigrationSqlGenerator()); 
            SetHistoryContextFactory("MySql.Data.MySqlClient", (conn, schema) => new MySqlHistoryContext(conn, schema));
            CodeGenerator = new MySqlMigrationCodeGenerator();
        }

        protected override void Seed(SmartLeopard.Dal.DatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
    public class MyOwnMySqlMigrationSqlGenerator : MySqlMigrationSqlGenerator
    {
        protected override MigrationStatement Generate(AddForeignKeyOperation addForeignKeyOperation)
        {
            addForeignKeyOperation.PrincipalTable = addForeignKeyOperation.PrincipalTable.Replace("dbo.", "");
            addForeignKeyOperation.DependentTable = addForeignKeyOperation.DependentTable.Replace("dbo.", "");
            var ms = base.Generate(addForeignKeyOperation);
            return ms;
        }
    }
    public class MySqlHistoryContext : HistoryContext
    {
        public MySqlHistoryContext(DbConnection connection, string defaultSchema) : base(connection, defaultSchema)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        { 
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HistoryRow>().Property(h => h.MigrationId).HasMaxLength(100).IsRequired();

            modelBuilder.Entity<HistoryRow>().Property(h => h.ContextKey).HasMaxLength(200).IsRequired();
        }
    }
}
