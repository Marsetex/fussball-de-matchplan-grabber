using FDMatchplanGrabber.Service.Business.Dtos;

namespace FDMatchplanGrabber.Service.Business.Services.Contracts
{
    public interface IMatchDataConverter
    {
        public MatchCsvFormat ConvertMatchToCsv(IEnumerable<FussballDeMatch> matches, string _dateFormat);
    }
}
