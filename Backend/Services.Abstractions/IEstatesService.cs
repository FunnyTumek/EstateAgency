using Contracts.DataTransferObject;

namespace Services.Abstractions
{
    public interface IEstatesService
    {
        Task<IEnumerable<EstatesDto>> GetAllActive();
        Task<EstatesDto> GetByIdAsync(int id);
        EstatesDto GetById(int id);
        Task CreateAsync(CreateEstatesDto dto);
        Task UpdateAsync(int id, UpdateEstatesDto dto);
        Task DeleteAsync(int id);
        Task BuyEstate(int id);
    }
}
