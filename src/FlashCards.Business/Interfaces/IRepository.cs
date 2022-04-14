namespace FlashCards.Business.Interfaces
{
    public interface IRepository<TEntity> : IDisposable
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task Add(TEntity entity);
        Task Remove(int id);
        Task Update(TEntity entity);
        Task<int> SaveChanges();

    }
}
