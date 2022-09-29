using Microsoft.EntityFrameworkCore;
using PracticeProject.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeProject.Database
{
    public class FamilyDbContext : DbContext
    {


        //Tables
        public DbSet<Person> Persons { get; set; }
        public DbSet<Relation> Relations { get; set; }

        public FamilyDbContext(DbContextOptions<FamilyDbContext> options)
                    : base(options)
        {
        }

        public readonly string _database = "PracticeProjectDb";

        public string ConnectionString => $@"Server=localhost;Database={_database};Integrated Security=true";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.ConnectionString);
        }

        
        //For configuring model properties using Fluent API (fx the only way to do composite keys)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Relation>()
                .HasOne(x => x.Person1)
                .WithMany(x => x.Person1Relations)
                .HasForeignKey(x => x.PersonId1);

            modelBuilder.Entity<Relation>()
                .HasOne(x => x.Person2)
                .WithMany(x => x.Person2Relations)
                .HasForeignKey(x => x.PersonId2)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
