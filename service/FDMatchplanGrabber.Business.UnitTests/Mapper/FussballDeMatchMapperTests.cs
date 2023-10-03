using FDMatchplanGrabber.Business.Mapper;
using Xunit;

namespace FDMatchplanGrabber.Business.UnitTests.Mapper
{
    public class FussballDeMatchMapperTests
    {
        [Fact]
        public void MapToMatch_WithValidData_()
        {
            // Arrange
            var matchDate = "";
            var homeTeam = "SV Ulm";
            var awayTeam = "SC Baden-Baden";
            var matchLink = "";

            // Act
            var result = FussballDeMatchMapper.MapToMatch(matchDate, homeTeam, awayTeam, matchLink);

            // Assert
            Assert.Equal(homeTeam, result.HomeTeam);
            Assert.Equal(awayTeam, result.AwayTeam);
        }
    }
}