namespace Contracts.DataTransferObject
{
    public class UpdateEstatesDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public int Floor { get; set; }
        public int NumberOfRooms { get; set; }
        public int YearOfConstruction { get; set; }
        public float FlatArea { get; set; }
        public decimal Price { get; set; }
        public DateTime EndDate { get; set; }
    }
}
