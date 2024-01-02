using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using EventsManagement_Chayma.Models;

namespace EventsManagement_Chayma.Models;

public partial class EventsDbContext : DbContext
{
    public EventsDbContext()
    {
    }

    public EventsDbContext(DbContextOptions<EventsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Organizer> Organizers { get; set; }

    public virtual DbSet<Participant> Participants { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }
    public DbSet<EventsManagement_Chayma.Models.Comment>? Comment { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:EventsCS");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Event__3214EC07044FA894");

            entity.ToTable("Event");

            entity.Property(e => e.Description).HasMaxLength(20);
            entity.Property(e => e.EndDate).HasMaxLength(20);
            entity.Property(e => e.Location).HasMaxLength(20);
            entity.Property(e => e.StartDate).HasMaxLength(20);
            entity.Property(e => e.Title).HasMaxLength(30);

            entity.HasOne(d => d.Organizer).WithMany(p => p.Events)
                .HasForeignKey(d => d.OrganizerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Event_Org");
        });

        modelBuilder.Entity<Organizer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Organize__3214EC071E02B1E5");

            entity.ToTable("Organizer");

            entity.Property(e => e.Email).HasMaxLength(40);
            entity.Property(e => e.Name).HasMaxLength(30);
            entity.Property(e => e.Phone)
                .HasMaxLength(30)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Organizer>().HasData(

           new Organizer
           {
               Id = 1,
               Name = "Organizer 1",
               Email = "email1@gmail.com",
               Phone = "255 641"

           },
           new Organizer
           {
               Id = 2,
               Name = "Organizer 2",
               Email = "email2@gmail.com",
               Phone = "255 641"

           },

           new Organizer
           {
               Id = 3,
               Name = "Organizer 3",
               Email = "email3@gmail.com",
               Phone = "255 641"

           }
           );

        modelBuilder.Entity<Event>().HasData(
            new Event
            {
                Id = 1,
                Title = "Event 1",
                Description = "Description 1",
                Location = "Location 1",
                StartDate = "15/02/2023",
                EndDate = "15/02/2023",
                OrganizerId = 2

            },
            new Event
            {
                Id = 2,
                Title = "Event 2",
                Description = "Description 2",
                Location = "Location 2",
                StartDate = "15/02/2023",
                EndDate = "15/02/2023",
                OrganizerId = 3

            },
            new Event
            {
                Id = 3,
                Title = "Event 3",
                Description = "Description 3",
                Location = "Location 3",
                StartDate = "15/02/2023",
                EndDate = "15/02/2023",
                OrganizerId = 1

            },

            new Event
            {
                Id = 4,
                Title = "Event 4",
                Description = "Description 4",
                Location = "Location 4",
                StartDate = "15/02/2023",
                EndDate = "15/02/2023",
                OrganizerId = 2
            }

            );

       // OnModelCreatingPartial(modelBuilder);
    }

   


    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

   



}
