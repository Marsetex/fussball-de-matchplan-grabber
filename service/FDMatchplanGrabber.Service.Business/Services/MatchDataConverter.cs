using System.Globalization;
using FDMatchplanGrabber.Service.Business.Dtos;
using FDMatchplanGrabber.Service.Business.Services.Contracts;

namespace FDMatchplanGrabber.Service.Business.Services
{
    public class MatchDataConverter : IMatchDataConverter
    {
        public MatchCsvFormat ConvertMatchToCsv(IEnumerable<FussballDeMatch> matches, string _dateFormat)
        {
            return new MatchCsvFormat
            (
                HeaderElements: "Date,Time,Ground,Home,Away",
                MatchElements: matches
                    .Select(x => $"{x.MatchDate.ToString(_dateFormat, CultureInfo.InvariantCulture)},{x.MatchDate.ToShortTimeString()},{x.Ground},{x.HomeTeam},{x.AwayTeam}")
                    .ToArray()
            );
        }
    }
}
