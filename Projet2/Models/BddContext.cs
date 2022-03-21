﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace Projet2.Models
{
    public class BddContext : DbContext
    {
        public DbSet<Member> Member { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Association> Association { get; set; }
        public DbSet<AssociationMember> AssociationMember { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user id=root;password=rrrrr;database=projet2;");
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
