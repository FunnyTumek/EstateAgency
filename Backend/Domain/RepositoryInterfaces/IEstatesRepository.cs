using Domain.Entities;

namespace Domain.RepositoryInterfaces
{
    public interface IEstatesRepository
    {
        Task<IEnumerable<Estates>> GetAllActive();
        Task<Estates> GetByIdAsync(int Id);
        Estates GetById(int Id);
        Task Insert(Estates estates);
        void Remove(Estates estates);
        Task Update(Estates estates);
    }
}
