using CleanArchitectureTemplate.Shared;
using CleanArchitectureTemplate.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace CleanArchitectureTemplate.Infrastructure;

public class Repository : IRepository
{
    private readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<T> GetByIdAsync<T, TId>(TId id) where T : Entity<TId>, IAggregateRoot
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<T> GetAsync<T, TId>(ISpecification<T> spec) where T : Entity<TId>, IAggregateRoot
    {
        return await ApplySpecification(spec).FirstOrDefaultAsync();
    }

    public async Task<List<T>> ListAsync<T, TId>() where T : Entity<TId>, IAggregateRoot
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<List<T>> ListAsync<T, TId>(ISpecification<T> spec) where T : Entity<TId>, IAggregateRoot
    {
        return await ApplySpecification(spec).ToListAsync();
    }

    public async Task<int> CountAsync<T, TId>(ISpecification<T> spec) where T : Entity<TId>, IAggregateRoot
    {
        return await ApplySpecification(spec).CountAsync();
    }

    public async Task<T> AddAsync<T, TId>(T entity) where T : Entity<TId>, IAggregateRoot
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync<T, TId>(T entity) where T : Entity<TId>, IAggregateRoot
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync<T, TId>(T entity) where T : Entity<TId>, IAggregateRoot
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    private IQueryable<T> ApplySpecification<T>(ISpecification<T> spec) where T : class
    {
        IQueryable<T> query = _context.Set<T>();

        if (spec.Criteria != null)
        {
            query = query.Where(spec.Criteria);
        }

        foreach (var include in spec.Includes)
        {
            query = query.Include(include);
        }

        return query;
    }
}
