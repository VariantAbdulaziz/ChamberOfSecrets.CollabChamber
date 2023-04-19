using ChamberOfSecrets.CollabChamber.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamberOfSecrets.CollabChamber.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly CollabChamberDbContext _dbContext;

    public GenericRepository(CollabChamberDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<T> Add(T entity)
    {
        _dbContext.Add(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public Task Delete(T entity)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Exists(int id)
    {
        return (await Get(id)) != null;
    }

    public async Task<T> Get(int id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> GetAll()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task Update(T entity)
    {
        _dbContext.Set<T>().Update(entity);
        await _dbContext.SaveChangesAsync();
    }
}
