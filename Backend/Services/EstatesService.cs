using AutoMapper;
using Contracts.DataTransferObject;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using Services.Abstractions;

namespace Services
{
    public class EstatesService : IEstatesService
    {
        private readonly IEstatesRepository estatesRepository;
        private readonly IMapper mapper;

        public EstatesService(IEstatesRepository estatesRepository, IMapper mapper)
        {
            this.estatesRepository = estatesRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<EstatesDto>> GetAllActive()
        {
            var estates = await estatesRepository.GetAllActive();

            return mapper.Map<List<EstatesDto>>(estates);
        }

        public async Task<EstatesDto> GetByIdAsync(int id)
        {
            var estate = await estatesRepository.GetByIdAsync(id);

            if (estate == null) throw new Exception("Invalid id.");

            return mapper.Map<EstatesDto>(estate);
        }

        public  EstatesDto GetById(int id)
        {
            var estate =  estatesRepository.GetById(id);

            if (estate == null) throw new Exception("Invalid id.");

            return mapper.Map<EstatesDto>(estate);
        }

        public async Task CreateAsync(CreateEstatesDto dto)
        {
            var estate = Estates.Create(dto.Name, dto.Address, dto.Description, dto.Floor, dto.NumberOfRooms, dto.YearOfConstruction, dto.FlatArea, dto.Price, dto.EndDate);
            await estatesRepository.Insert(estate);
        }

        public async Task UpdateAsync(int id, UpdateEstatesDto dto)
        {
            var estate = await estatesRepository.GetByIdAsync(id);

            if (estate == null) throw new Exception("Invalid id.");

            estate.Update(dto.Name, dto.Address, dto.Description, dto.Floor, dto.NumberOfRooms, dto.YearOfConstruction, dto.FlatArea, dto.Price, dto.EndDate);
            await estatesRepository.Update(estate);
        }

        public async Task DeleteAsync(int id)
        {
            var estate = await estatesRepository.GetByIdAsync(id);

            if (estate == null) throw new Exception("Invalid id.");

            estatesRepository.Remove(estate);
        }

        public async Task BuyEstate(int id)
        {
            var estate = await estatesRepository.GetByIdAsync(id);

            if (estate == null) throw new Exception("Invalid id.");

            estate.BuyEstate();

            await estatesRepository.Update(estate);
        }
    }
}
