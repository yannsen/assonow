using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Projet2.Models
{
    public class BddContext : DbContext
    {
        public DbSet<Member> Member { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Association> Association { get; set; }
        public DbSet<AssociationMember> AssociationMember { get; set; }

        public DbSet<Ticket> Ticket { get; set; }
        
        // add of a dbset for Advice
        public DbSet<Advice> Advice { get; set; }

        // add of a dbset for AdviceRequest

        public DbSet<AdviceRequest> AdviceRequest { get; set; }

        public DbSet<Document> Document { get; set; }
        public DbSet<Donation> Donation { get; set; }
        public DbSet<RecurringDonation> RecurringDonation { get; set; }
        public DbSet<Fundraising> Fundraising { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<CreditCard> CreditCard { get; set; }
        public DbSet<AssociationEvent> AssociationEvent { get; set; }

        public DbSet<Contribution> Contribution { get; set; }

        public DbSet<Order> Order { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                optionsBuilder.UseMySql("server=localhost;user id=root;password=rrrrr;database=projet2;");
            }
            else
            {
                IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
                optionsBuilder.UseMySql(configuration.GetConnectionString("DefaultConnection"));
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>(entity =>
            {
                entity.Property(e => e.Lastname)
                    .HasColumnType("varchar(15)");
            });
        }
    }
}
