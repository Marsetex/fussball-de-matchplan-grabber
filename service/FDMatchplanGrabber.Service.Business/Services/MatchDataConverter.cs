using FDMatchplanGrabber.Service.Business.Dtos;
using FDMatchplanGrabber.Service.Business.Services.Contracts;

namespace FDMatchplanGrabber.Service.Business.Services
{
    public class MatchDataConverter : IMatchDataConverter
    {
        public MatchCsvFormat ConvertMatchToCsv(IEnumerable<FussballDeMatch> matches)
        {
            return new MatchCsvFormat
            (
                HeaderElements: "Date,Time,Ground,Home,Away",
                MatchElements: matches
                    .Select(x => $"{x.MatchDate.ToShortDateString()},{x.MatchDate.ToShortTimeString()},{x.Ground},{x.HomeTeam},{x.AwayTeam}")
                    .ToArray()
            );
        }
    }
}
