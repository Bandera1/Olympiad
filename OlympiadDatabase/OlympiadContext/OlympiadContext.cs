namespace OlympiadProject
{
    using OlympiadDatabase.Classes;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class OlympiadContext : DbContext
    {       
        public OlympiadContext() : base("name=OlympiadContext")
        {
        }


        public DbSet<OlympType> OlympTypes { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<SportType> SportTypes { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Olympiad> Olympiads { get; set; }
        public DbSet<OlympResult> OlympResults { get; set; }
    }
}