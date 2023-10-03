using FDMatchplanGrabber.Business.Dtos;

namespace FDMatchplanGrabber.Business.Services.Contracts
{
    public interface IMatchDataConverter
    {
        public MatchCsvFormat ConvertMatchToCsv(IEnumerable<FussballDeMatch> matches, string _dateFormat);
    }
}
