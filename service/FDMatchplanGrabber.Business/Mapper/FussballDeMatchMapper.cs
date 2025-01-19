using System.Text.RegularExpressions;
using FDMatchplanGrabber.Business.Dtos;

namespace FDMatchplanGrabber.Business.Mapper;

public static class FussballDeMatchMapper
{
    /// <summary>
    ///     This regular expression removes obsolete new lines and tab characters
    ///     TODO: Outsource the regex 
    /// </summary>
    private static readonly Regex _pattern = new("[\n\t]");

    public static FussballDeMatch MapToMatch(DateTime matchDate, string homeTeam, string awayTeam, string matchLink)
    {
        return new FussballDeMatch
        (
            MatchDate: matchDate, 
            Ground: string.Empty,
            HomeTeam: _pattern.Replace(homeTeam, string.Empty),
            AwayTeam: _pattern.Replace(awayTeam, string.Empty),
            MatchLink: matchLink
        );
    }
}
