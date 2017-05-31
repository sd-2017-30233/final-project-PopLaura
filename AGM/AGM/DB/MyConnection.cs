using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AGM.Models;


namespace AGM.DB
{
    public class MyConnection : System.Data.Entity.DbContext
    {
        public DbSet<User> Users { get; set; }

        public System.Data.Entity.DbSet<AGM.Models.Artist> Artists { get; set; }
        public System.Data.Entity.DbSet<AGM.Models.Paitings> Paiting { get; set; }

        public System.Data.Entity.DbSet<AGM.Models.Logare> Logares { get; set; }

        //public System.Data.Entity.DbSet<AGM.Models.Logare> Logares { get; set; }
    }
}