using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamberOfSecrets.CollabChamber.Persistence;

public class CollabChamberDbContextFactory : IDesignTimeDbContextFactory<CollabChamberDbContext>
{

    CollabChamberDbContext IDesignTimeDbContextFactory<CollabChamberDbContext>.CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<CollabChamberDbContext>();
        var connectionString = configuration.GetConnectionString("CollabChamberConnectionString");

        builder.UseNpgsql(connectionString);

        return new CollabChamberDbContext(builder.Options);
    }
}
