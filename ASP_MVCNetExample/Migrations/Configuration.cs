namespace ASP_MVCNetExample.Migrations
{
    using ASP_MVCNetExample.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ASP_MVCNetExample.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ASP_MVCNetExample.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('MovieModels', RESEED, 0)");
            //context.MovieModels.Add(new MovieModel {Id = 1, Name = "Friday Evening", ReleaseDate = "1 / 3 / 1979" });
        }
    }
}
