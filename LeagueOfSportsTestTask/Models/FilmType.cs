using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LeagueOfSportsTestTask.Models
{
    public class FilmType
    {
        public int Id { get; set; }
        [Display(Name = "Название")]
        [Required]
        public string Name { get; set; }
        public ICollection<Film> Films { get; set; }

        public FilmType()
        {
            Films = new List<Film>();
        }
    }
}