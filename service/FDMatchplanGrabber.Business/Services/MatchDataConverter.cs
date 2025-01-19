using System.Globalization;
using FDMatchplanGrabber.Business.Dtos;
using FDMatchplanGrabber.Business.Services.Contracts;

namespace FDMatchplanGrabber.Business.Services;

public class MatchDataConverter : IMatchDataConverter
{
    private const string HeaderElements = "Date,Time,Ground,Home,Away";

    public MatchCsvFormat ConvertMatchToCsv(IEnumerable<FussballDeMatch> matches, string _dateFormat)
    {
        return new MatchCsvFormat
        (
            HeaderElements: HeaderElements,
            MatchElements: matches
                .Select(match => GetMatchElement(match, _dateFormat))
                .ToArray()
        );
    }

    private static string GetMatchElement(FussballDeMatch match, string _dateFormat)
    {
        var convertedDate = match.MatchDate.ToString(_dateFormat, CultureInfo.InvariantCulture);
        var matchShortTime = match.MatchDate.ToShortTimeString();

        return $"{convertedDate},{matchShortTime},{match.Ground},{match.HomeTeam},{match.AwayTeam}";
    }
}
