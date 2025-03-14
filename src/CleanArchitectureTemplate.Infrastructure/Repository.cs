using CleanArchitectureTemplate.Shared;
using CleanArchitectureTemplate.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Infrastructure;

public class Repository : IRepository
{
    private readonly AppDbContext _context;
    private readonly IUnitOfWork _unitOfWork;

    public Repository(AppDbContext context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }

    public async Task<T> GetByIdAsync<T, TId>(TId id, CancellationToken cancellationToken) where T : Entity<TId>, IAggregateRoot
    {
        return await _context.Set<T>().FindAsync(new object[] { id }, cancellationToken);
    }

    public async Task<T> GetAsync<T, TId>(ISpecification<T> spec, CancellationToken cancellationToken) where T : Entity<TId>, IAggregateRoot
    {
        return await ApplySpecification(spec).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<List<T>> ListAsync<T, TId>(CancellationToken cancellationToken) where T : Entity<TId>, IAggregateRoot
    {
        return await _context.Set<T>().ToListAsync(cancellationToken);
    }

    public async Task<List<T>> ListAsync<T, TId>(ISpecification<T> spec, CancellationToken cancellationToken) where T : Entity<TId>, IAggregateRoot
    {
        return await ApplySpecification(spec).ToListAsync(cancellationToken);
    }

    public async Task<int> CountAsync<T, TId>(ISpecification<T> spec, CancellationToken cancellationToken) where T : Entity<TId>, IAggregateRoot
    {
        return await ApplySpecification(spec).CountAsync(cancellationToken);
    }

    public async Task<T> AddAsync<T, TId>(T entity, CancellationToken cancellationToken) where T : Entity<TId>, IAggregateRoot
    {
        await _context.Set<T>().AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync<T, TId>(T entity, CancellationToken cancellationToken) where T : Entity<TId>, IAggregateRoot
    {
        _context.Set<T>().Update(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync<T, TId>(T entity, CancellationToken cancellationToken) where T : Entity<TId>, IAggregateRoot
    {
        _context.Set<T>().Remove(entity);
        await _unitOfWork.SaveChangesAsync();
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
