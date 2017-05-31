using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AGM.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        public int users_id { get; set; }
        [Required(ErrorMessage = "Role ID is required.")]
        [Display (Name ="RoleId")]
        public int role_id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [Display (Name="Name")]
        public string name { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Address")]
        public string address { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [Display(Name = "Email")]
        public string email { get; set; }
        [Required(ErrorMessage = "Password is requierd")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }
        [Display(Name = "Phone")]
        //[Required(ErrorMessage = "Phone is requierd")]
        public string phone { get; set; }
        [Display(Name = "Amount")]
        public double amounnt { get; set; }
        [Display(Name = "Short description about yourself!")]
        public string short_description { get; set; }
        //public string username { get; set; }
    }

   /* public class MyConnection : System.Data.Entity.DbContext
    {
        public DbSet<User> Users { get; set; }

        public System.Data.Entity.DbSet<AGM.Models.Artist> Artists { get; set; }
        public System.Data.Entity.DbSet<AGM.Models.Paitings> Paiting { get; set; }

        public System.Data.Entity.DbSet<AGM.Models.Logare> Logares { get; set; }

        //public System.Data.Entity.DbSet<AGM.Models.Logare> Logares { get; set; }
    }*/
    public class Logare
    {
        [Key]
        public string email { get; set; }
        public string password { get; set; }
    }

}