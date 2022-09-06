using Domain.Entities;
using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories
{
    public class EstatesRepository : IEstatesRepository
    {
        private readonly EstatesDbContext dbContext;

        public EstatesRepository(EstatesDbContext dbContext) => this.dbContext = dbContext;
        public async Task<IEnumerable<Estates>> GetAllActive() =>
            await dbContext.Estates.Where(estate => estate.IfBought == false && estate.EndDate >= DateTime.Now).ToListAsync();

        public async Task<Estates> GetByIdAsync(int id) =>
            await dbContext.Estates.FirstOrDefaultAsync(x => x.Id == id);

        public Estates GetById(int id) =>
            dbContext.Estates.FirstOrDefault(x => x.Id == id);
        public async Task Insert(Estates estates)
        {
            await dbContext.Estates.AddAsync(estates);
            await dbContext.SaveChangesAsync();
        }
        public void Remove(Estates estates)
        {
            dbContext.Estates.Remove(estates);
            dbContext.SaveChanges();
        }

        public async Task Update(Estates estates) => 
            await dbContext.SaveChangesAsync();
    }
}
