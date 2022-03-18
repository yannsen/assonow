using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChoixSejour.Models
{
    public class BddContext : DbContext
    {
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Sejour> Sejours { get; set; }
        public DbSet<Sondage> Sondages { get; set; }
        public DbSet<Vote> Votes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user id=root;password=rrrrr;database=ChoixSejourTest");
        }

        public void InitializeDb()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
            this.Sejours.AddRange(
                new Sejour
                {
                    Id = 1,
                    Lieu = "Disney",
                    Telephone = "000000000"
                },
                new Sejour
                {
                    Id = 2,
                    Lieu = "Chambord",
                    Telephone = "111111111"
                }
            );
            this.SaveChanges();
        }
    }
}
