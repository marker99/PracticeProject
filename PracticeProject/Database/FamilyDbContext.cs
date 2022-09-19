using Microsoft.EntityFrameworkCore;
using PracticeProject.Models;

namespace PracticeProject.Database
{
    public class FamilyDbContext : DbContext
    {
        //Tables
        public DbSet<Person> Persons { get; set; }
        public DbSet<Relation> Relations { get; set; }


        public readonly string _database = "FamilyDb";

        public string ConnectionString => $@"Server=localhost;Database={_database};Integrated Security=true";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.ConnectionString);
        }


        //For configuring model properties using Fluent API (fx the only way to do composite keys)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
