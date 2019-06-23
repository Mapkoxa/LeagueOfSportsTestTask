using System.Collections.Generic;

namespace LeagueOfSportsTestTask.Models
{
    public class FilmType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Film> Films { get; set; }

        public FilmType()
        {
            Films = new List<Film>();
        }
    }
}