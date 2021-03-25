using EventCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Data
{
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Address>  Addresses { get; set; }
        public DbSet<EventCategory>  EventCategories { get; set; }
        public DbSet< EventOrganizer>  EventOrganizers { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<EventItem> EventItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(a =>  {
                a.Property(a => a.Id)
                 .ValueGeneratedOnAdd();
                
                });
            modelBuilder.Entity<EventCategory>(c=> {
                c.Property(c => c.Id)
                 .ValueGeneratedOnAdd()
                 .IsRequired();
                c.Property(c => c.Category)
                .IsRequired()
                .HasMaxLength(100);

                });
            modelBuilder.Entity<EventOrganizer>(o =>
            {
                o.Property(o => o.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
                o.Property(o => o.Coordinator)
                .HasMaxLength(100);
                o.Property(o => o.Title)
                 .HasMaxLength(100);
            });
            modelBuilder.Entity<EventType>(t =>
            {
                t.Property(t => t.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
                t.Property(t => t.Type)
                .HasMaxLength(100);

            });
            modelBuilder.Entity<EventItem>(i =>
            {
                i.Property(i => i.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

                i.Property(i => i.Event)
                .IsRequired()
                .HasMaxLength(100);

                i.Property(i => i.Description)
                .HasMaxLength(100);

                i.Property(i => i.Price);

                i.Property(i => i.EventImageUrl)
                .HasMaxLength(100)
                .IsRequired();

                i.Property(i => i.EventStartTime)
                .IsRequired();

                i.Property(i => i.EventEndTime)
                .IsRequired();

                i.HasOne(i => i.Address)
                 .WithMany()
                 .HasForeignKey(i => i.AddressId);

                i.HasOne(i => i.EventCategory)
                 .WithMany()
                 .HasForeignKey(i => i.CatagoryId);

                i.HasOne(i => i.EventOrganizer)
               .WithMany()
               .HasForeignKey(i => i.OrganizerId);

                i.HasOne(i => i.EventType)
                 .WithMany()
                 .HasForeignKey(i => i.TypeId);

            });

        }

    }
}
