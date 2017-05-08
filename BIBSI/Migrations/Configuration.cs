namespace BIBSI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BIBSI.Models.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "BIBSI.Models.Context";
        }

        protected override void Seed(BIBSI.Models.Context context)
        {
           
        }
    }
}
