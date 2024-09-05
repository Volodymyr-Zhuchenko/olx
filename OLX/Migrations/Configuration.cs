namespace OLX.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OLX.DB.Data>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "OLX.DB.Data";
        }

        protected override void Seed(OLX.DB.Data context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
