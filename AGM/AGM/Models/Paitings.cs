using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace AGM.Models
{
    [Table ("paitings")]
    public class Paitings
    {
        [Key]
        public int paiting_id { get; set; }
        [Required(ErrorMessage = "Url is required")]
        [DataType(DataType.ImageUrl)]
        public string paiting_url { get; set; }
        [Required(ErrorMessage = "Artist id is required")]
        public int artist_id { get; set; }
        public string paiting_description { get; set; }
    }
    
}