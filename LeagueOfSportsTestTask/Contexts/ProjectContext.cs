using LeagueOfSportsTestTask.Models;
using System.Data.Entity;

namespace LeagueOfSportsTestTask.Contexts
{
    public class ProjectContext : DbContext
    {
        public ProjectContext()
           : base("DbConnection")
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<FilmType> FilmTypes{ get; set; }
        public DbSet<Film> Films{ get; set; }
    }
}