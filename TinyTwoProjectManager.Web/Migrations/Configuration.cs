using System.Data.Entity.Migrations;
using TinyTwoProjectManager.Data.Infrastructure;

namespace TinyTwoProjectManager.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ProjectManagerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "TinyTwoProjectManager.Data.Infrastructure.ProjectManagerDbContext";
        }
    }
}