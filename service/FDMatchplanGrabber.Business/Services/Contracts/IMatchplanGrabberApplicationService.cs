using FDMatchplanGrabber.Business.Dtos;

namespace FDMatchplanGrabber.Business.Services.Contracts;

public interface IMatchplanGrabberApplicationService
{
    Task<IEnumerable<FussballDeMatch>> GetMatches(string urlToMatchplan);
    Task<IEnumerable<FussballDeMatch>> GetMatchesAndWriteToFile(MatchesFileWriteDto fileWriteDto);
}
