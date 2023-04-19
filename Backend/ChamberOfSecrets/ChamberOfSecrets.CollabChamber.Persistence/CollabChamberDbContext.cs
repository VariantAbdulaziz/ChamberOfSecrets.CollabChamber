using ChamberOfSecrets.CollabChamber.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamberOfSecrets.CollabChamber.Persistence;
public class CollabChamberDbContext : DbContext
{
    public DbSet<Meeting> Meetings { get; set; }
    public DbSet<Participant> Participants { get; set; }
    public DbSet<CodeEditor> CodeEditors { get; set; }
    public DbSet<MeetingParticipant> MeetingParticipants { get; set; }


    public CollabChamberDbContext(DbContextOptions<CollabChamberDbContext> options)
            : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CollabChamberDbContext).Assembly);
    }
}
