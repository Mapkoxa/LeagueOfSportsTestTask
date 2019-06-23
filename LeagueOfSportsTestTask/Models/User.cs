using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LeagueOfSportsTestTask.Models
{
    public class User
    {
        public int Id { get; set; }
        [Display(Name = "Логин")]
        public string Login { get; set; }

        [Display(Name = "Пароль")]
        public string Password { get; set; }

        public ICollection<Film> AddedFilms { get; set; }

        public User()
        {
            AddedFilms = new List<Film>();
        }
    }
}