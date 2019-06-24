using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace LeagueOfSportsTestTask.Models
{
    public class User
    {
        public int Id { get; set; }
        [Remote("IsUserExists", "Users", AdditionalFields = "Id",
            ErrorMessage = "Такой пользователь зарегистрирован")]
        [Display(Name = "Логин")]
        [Required]
        public string Login { get; set; }

        [Required]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        public ICollection<Film> AddedFilms { get; set; }

        public User()
        {
            AddedFilms = new List<Film>();
        }
    }
}