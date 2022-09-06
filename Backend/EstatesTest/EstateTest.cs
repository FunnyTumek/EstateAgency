using Domain.Entities;
using System.Globalization;

namespace EstatesTest
{
    public class EstateTest
    {
        [Theory]
        [InlineData(0, 321312, "Name", "Address", "2022-12-31 13:26", "Invalid flat area.")]
        [InlineData(231, -3, "Name", "Address", "2022-12-31 13:26", "Invalid price.")]
        [InlineData(231, 3210, null, "Address", "2022-12-31 13:26", "Missing name.")]
        [InlineData(231, 1231, "Name", null, "2022-12-31 13:26", "Missing address.")]
        [InlineData(231, 1231, "Name", "Address", "2022-08-20 13:26", "Invalid date.")]
        public void Should_Throw_ArgumentException_When_Creating_Estate_With_Wrong_Data(float estateFlatArea, decimal estatePrice, string estateName, string estateAddress, string estateEndDate, string errorMessage)
        {
            // Arrange
            const string  EstateDescription = "Description";
            const int  EstateFloor = 3;
            const int EstateNumberOfRooms = 2;
            const int EstateYearOfConstruction = 2000;
            DateTime expectedEndDate = DateTime.Parse(estateEndDate);

            // Act
            Action estateCreation = () => Estates.Create(estateName, estateAddress, EstateDescription, EstateFloor, EstateNumberOfRooms, EstateYearOfConstruction, estateFlatArea, estatePrice, expectedEndDate);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(estateCreation);
            Assert.Equal(errorMessage, exception.Message);
        }
    }
}