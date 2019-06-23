using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeagueOfSportsTestTask.Models
{
    public class Film
    {
        public int Id { get; set; }
        [Column("IdUser")]
        public int IdUser { get; set; }
        [Column("IdFilmType")]
        public int IdFilmType { get; set; }
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public string Creator { get; set; }
        public DateTime CreatedDate { get; set; }
        public string PosterFile { get; set; }

        [ForeignKey("IdFilmType")]
        public FilmType FilmType { get; set; }

        [ForeignKey("IdUser")]
        public User User { get; set; }
    }
}