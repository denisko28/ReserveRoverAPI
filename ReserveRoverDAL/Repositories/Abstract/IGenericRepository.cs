namespace ReserveRoverDAL.Repositories.Abstract;

public interface IGenericRepository<TEntity> where TEntity:class
{
    Task<TEntity> GetByIdAsync(int id);

    Task InsertAsync(TEntity entity);

    Task UpdateAsync(TEntity entity);

    Task DeleteByIdAsync(int id);
}