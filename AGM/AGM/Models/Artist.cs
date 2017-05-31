using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AGM.Models
{
    [Table("artist")]
    public class Artist
    {
        [Key]
        [Display (Name ="Artist ID")]
        public int artist_id { get; set; }
        [Required(ErrorMessage = "Artist name is required")]
        [Display(Name = "Artist Name")]
        public String artist_name { get; set; }
        [Required(ErrorMessage = "Birth date required.")]
        [Display(Name = "Birth Date")]
        [DataType (DataType.Date)]
        public DateTime birthday_date { get; set; }
        [Required(ErrorMessage = "Birth place is required.")]
        [Display(Name = "Birth place")]
        public String birth_place { get; set; }
        [Required(ErrorMessage = "A short description about the artist is required.")]
        [Display(Name = "Short description about artist")]
        public String artist_description { get; set; }
    }

    public class DbContext
    {
        public DbSet<Artist> Artist { get; set; }

        //public System.Data.Entity.DbSet<AGM.Models.Logare> Logares { get; set; }
    }
}