using FDMatchplanGrabber.Business.Mapper;
using Xunit;

namespace FDMatchplanGrabber.Business.UnitTests.Mapper;

public class FussballDeMatchMapperTests
{
    [Fact]
    public void MapToMatch_WithValidData_ReturnCorrectlyMappedDto()
    {
        // Arrange
        var matchDate = DateTime.Now;
        var homeTeam = "SV Ulm";
        var awayTeam = "SC Baden-Baden";
        var matchLink = "http://fussball.de";

        // Act
        var result = FussballDeMatchMapper.MapToMatch(matchDate, homeTeam, awayTeam, matchLink);

        // Assert
        Assert.Equal(matchDate, result.MatchDate);
        Assert.Equal(homeTeam, result.HomeTeam);
        Assert.Equal(awayTeam, result.AwayTeam);
        Assert.Equal(string.Empty, result.Ground);
        Assert.Equal(matchLink, result.MatchLink);
    }
}