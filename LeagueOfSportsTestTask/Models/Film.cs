using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace LeagueOfSportsTestTask.Models
{
    public class Film
    {
        public int Id { get; set; }

        [Column("IdUser")]
        public int IdUser { get; set; }

        [Required]
        [Column("IdFilmType")]
        [Display(Name = "Жанр")]
        public int IdFilmType { get; set; }

        [Display(Name = "Название")]
        [Required]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Описание")]
        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Режиссер")]
        public string Creator { get; set; }

        [Display(Name = "Дата производства")]
        [Range(1970, 2020)]
        [Required]
        public int CreatedYear { get; set; }
        
        [ForeignKey("IdFilmType")]
        public FilmType FilmType { get; set; }

        [ForeignKey("IdUser")]
        public User User { get; set; }
    }
}