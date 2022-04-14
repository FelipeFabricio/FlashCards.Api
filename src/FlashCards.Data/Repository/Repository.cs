using FlashCards.Business.Interfaces;
using FlashCards.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FlashCards.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly FlashCardContext context;
        protected readonly DbSet<TEntity> dbSet;

        protected Repository(FlashCardContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task Add(TEntity entity)
        {
            dbSet.Add(entity);
            await SaveChanges();
        }

        public async Task Remove(int id)
        {
            var entity = await GetById(id);

            if (entity == null) return;

            dbSet.Remove(entity);
            await SaveChanges();
        }

        public async Task Update(TEntity entity)
        {
            dbSet.Update(entity);
            await SaveChanges();
        }

        public Task<int> SaveChanges()
        {
            return context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context?.Dispose();
        }
    }
}
