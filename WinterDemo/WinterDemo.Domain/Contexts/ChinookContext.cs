using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WinterDemo.Domain.Models;

namespace WinterDemo.Domain.Contexts
{
    public class ChinookContext : DbContext
    {
        public ChinookContext()
        {
        }

        public ChinookContext(DbContextOptions<ChinookContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Playlist> Playlist { get; set; }
        public virtual DbSet<PlaylistTrack> PlaylistTrack { get; set; }
        public virtual DbSet<Track> Track { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // add connection config here if not passed in
            }
        }

        // configure models with FluentAPI
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlaylistTrack>(entity =>
            {
                entity.HasNoKey();
            });
        }
    }
}
