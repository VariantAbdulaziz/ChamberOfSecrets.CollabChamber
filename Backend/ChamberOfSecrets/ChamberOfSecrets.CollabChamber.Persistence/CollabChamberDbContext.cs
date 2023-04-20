using ChamberOfSecrets.CollabChamber.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ChamberOfSecrets.CollabChamber.Persistence;
public class CollabChamberDbContext : DbContext
{
    public DbSet<Meeting> Meetings { get; set; }
    public DbSet<Participant> Participants { get; set; }
    public DbSet<CodeEditor> CodeEditors { get; set; }
    public DbSet<MeetingParticipant> MeetingParticipants { get; set; }
    public DbSet<Shadow> Shadows { get; set; }
    public DbSet<Connection> Connections { get; set; }


    public CollabChamberDbContext(DbContextOptions<CollabChamberDbContext> options)
            : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Meeting>()
                .HasOne(m => m.CodeEditor)
                .WithOne(m => m.Meeting)
                .HasForeignKey<CodeEditor>(m => m.MeetingId)
                .IsRequired();

        modelBuilder.Entity<Participant>()
                .HasOne(m => m.Connection)
                .WithOne(m => m.Participant)
                .HasForeignKey<Connection>(e => e.ParticipantId)
                .IsRequired();

        modelBuilder.Entity<Connection>()
                .HasOne(m => m.Shadow)
                .WithOne(m => m.Connection)
                .HasForeignKey<Shadow>(e => e.ConnectionId)
                .IsRequired();
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CollabChamberDbContext).Assembly);
    }
}
