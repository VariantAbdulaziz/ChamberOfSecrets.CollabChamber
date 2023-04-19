using ChamberOfSecrets.CollabChamber.Application.Contracts.Persistence;
using ChamberOfSecrets.CollabChamber.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamberOfSecrets.CollabChamber.Persistence;


public static class PersistenceServicesRegistration
{
    public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CollabChamberDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("CollabChamberConnectionString")));


        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        services.AddScoped<ICodeEditorRepository, CodeEditorRepository>();
        services.AddScoped<IMeetingPartipantRepository, MeetingPartipantRepository>();
        services.AddScoped<IMeetingRepository, MeetingRepository>();
        services.AddScoped<IParticipantRepository, ParticipantRepository>();

        return services;
    }
}
