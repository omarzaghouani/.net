using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Am.ApplicationCore.Domain;
using AM.infrastructure.Configurations;

namespace AM.infrastructure
{
    public class AMContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
            Initial Catalog=AirportManagementDB;
            Integrated Security=true;
            MultipleActiveResultSets=true");
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        // Configuration Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuration pour la classe Plane
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());

            // Configuration pour la classe Flight
            modelBuilder.ApplyConfiguration(new FlightConfiguration());

            // Configuration pour la classe Ticket
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Passenger)
                .WithMany(p => p.Tickets)
                .HasForeignKey(t => t.PassengerFK);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Flight)
                .WithMany(f => f.Tickets)
                .HasForeignKey(t => t.FlightId);

            // Type possédé pour Passenger (FullName)
            modelBuilder.Entity<Passengers>().OwnsOne(p => p.FullName);

            // Configuration de table par hiérarchie (TPH) pour Passengers
            // modelBuilder.Entity<Passengers>()
            //     .HasDiscriminator<int>("IsTraveller")
            //     .HasValue<Passengers>(0)
            //     .HasValue<Travaler>(1)
            //     .HasValue<Staff>(2);

            // Configuration de table par type (TPT) pour Staff et Traveller
            modelBuilder.Entity<Staff>().ToTable("Staff");
            modelBuilder.Entity<Travaler>().ToTable("Traveller");
        }

        // Redéfinir les conventions globales
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            // Conventions par défaut pour les chaînes de caractères
            configurationBuilder.Properties<string>()
                .HaveMaxLength(100)
                .AreUnicode(false)
                .HaveColumnType("varchar(100)");

            // Conventions pour les dates
            configurationBuilder.Properties<DateTime>()
                .HaveColumnType("date");

            // Conventions pour les nombres décimaux
            configurationBuilder.Properties<decimal>()
                .HavePrecision(18, 2);
        }

        // DbSets pour chaque entité
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Passengers> Passengers { get; set; }
        public DbSet<Travaler> Travalers { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}
