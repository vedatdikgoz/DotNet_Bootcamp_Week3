using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;




namespace Core.DataAccess.EntityFrameworkCore
{
    public class EntityRepositoryBase<TEntity>: IEntityRepository<TEntity>
        where TEntity: class, IEntity, new()       
    {
        private readonly DbContext _context;

        public EntityRepositoryBase(DbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(TEntity entity) 
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await Task.Run(() => { _context.Set<TEntity>().Remove(entity); });
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _context.Set<TEntity>().SingleOrDefaultAsync(filter);
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                    ? await _context.Set<TEntity>().ToListAsync()
                    : await _context.Set<TEntity>().Where(filter).ToListAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await Task.Run(() => { _context.Set<TEntity>().Update(entity); });
        }
    }
}
