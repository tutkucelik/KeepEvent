using KeepEvent.BOL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepEvent.DAL.Contexts
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext() : base("CS1") { }
        public DbSet<Category> Category { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Place> Place { get; set; }
        public DbSet<PlaceEvent> PlaceEvent { get; set; }
        public DbSet<AgeRange> AgeRange { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Header> Header { get; set; }
        public DbSet<Contact> Contact { get; set; }
       

       
    }
}
