using Application.Constants;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly KanBankasıContext _context;

        public Repository(KanBankasıContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            entity.CreatedDate = DateTime.Now;
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>()
                .Where(x => x.DeletedDate == null)
                .ToListAsync();
        }

        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(filter);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity= await _context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                return entity;
            }
            return null;
        }

        public async Task RemoveAsync(T entity)
        {
            if (entity.DeletedDate == null)
            {
                entity.DeletedDate = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            else
            {

                //throw new Exception("Veri zaten silinmiş");
                throw new Exception(Messages<T>.EntityAlreadyDeleted);
            }
            
        }

        public async Task UpdateAsync(T entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
