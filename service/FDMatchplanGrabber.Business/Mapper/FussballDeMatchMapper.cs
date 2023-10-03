using System.Text.RegularExpressions;
using FDMatchplanGrabber.Business.Dtos;

namespace FDMatchplanGrabber.Business.Mapper
{
    public static class FussballDeMatchMapper
    {
        /// <summary>
        ///     This regular expression removes obsolete new lines and tab characters
        /// </summary>
        private static readonly Regex _pattern = new Regex("[\n\t]");

        public static FussballDeMatch MapToMatch(string matchDate, string homeTeam, string awayTeam, string matchLink)
        {
            return new FussballDeMatch
            (
                MatchDate: DateTime.ParseExact(matchDate.Split(" Uhr | ")[0], "dddd, dd.MM.yyyy - HH:mm", null),
                Ground: string.Empty,
                HomeTeam: _pattern.Replace(homeTeam, string.Empty),
                AwayTeam: _pattern.Replace(awayTeam, string.Empty),
                MatchLink: matchLink
            );
        }
    }
}
