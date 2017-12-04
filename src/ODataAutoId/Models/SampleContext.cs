using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ODataAutoId.Models {
    public class SampleContext : DbContext {

        public SampleContext() 
            : base("name=SampleContext") {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Item> Items { get; set; }

    }
}