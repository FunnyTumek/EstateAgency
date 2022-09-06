using Microsoft.AspNetCore.Http;

namespace Domain.Entities
{
    public class Estates
    {
        #region Properties
        public int Id { get;  private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string? Description { get; private set; }
        public int? Floor { get; private set; }
        public int? NumberOfRooms { get; private set; }
        public int? YearOfConstruction { get; private set; }
        public float FlatArea { get; private set; }
        public decimal Price { get; private set; }
        public bool IfBought { get; private set; }
        public DateTime AddedDate { get; private set; }
        public DateTime EndDate { get; private set; }


        #endregion
        public static Estates Create(string name, string address, string description, int floor, int numberOfRooms, int yearOfConstruction, float flatArea, decimal price, DateTime endDate)
        {
            Validate(name, address, flatArea, price, endDate);
            return new()
            {             
                Name = name,
                Address = address,
                Description = description,
                Floor = floor,
                NumberOfRooms = numberOfRooms,
                YearOfConstruction = yearOfConstruction,
                FlatArea = flatArea,
                Price = price,
                AddedDate = DateTime.Now,
                EndDate = endDate,
                IfBought = false,
            };
        }

        public void Update(string name, string address, string description, int floor, int numberOfRooms, int yearOfConstruction, float flatArea, decimal price, DateTime endDate)
        {
            Validate(name, address, flatArea, price, endDate);

            Name = name;
            Address = address;
            Description = description;
            Floor = floor;
            NumberOfRooms = numberOfRooms;
            YearOfConstruction = yearOfConstruction;
            FlatArea = flatArea;
            Price = price;
            EndDate = endDate;
        }

        public void BuyEstate()
        {
            IfBought = true;
            EndDate = DateTime.Now;
        }


        private static void Validate(string name, string address, float flatArea, decimal price, DateTime endDate)
        {
            if (name is null) throw new ArgumentException("Missing name.");
            if (address is null) throw new ArgumentException("Missing address.");
            if (flatArea <= 0) throw new ArgumentException("Invalid flat area.");
            if (price <= 0) throw new ArgumentException("Invalid price.");

            int result = DateTime.Compare(DateTime.Now, endDate);
            if (result > 0) throw new ArgumentException("Invalid date.");
        }
    }
}
