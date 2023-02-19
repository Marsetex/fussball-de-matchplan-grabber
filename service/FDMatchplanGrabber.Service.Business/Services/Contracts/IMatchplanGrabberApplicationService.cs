using FDMatchplanGrabber.Service.Business.Arguments;
using FDMatchplanGrabber.Service.Business.Dtos;

namespace FDMatchplanGrabber.Service.Business.Services.Contracts;

public interface IMatchplanGrabberApplicationService
{
    Task<IEnumerable<FussballDeMatch>> GetMatches(string urlToMatchplan);
    Task<IEnumerable<FussballDeMatch>> GetMatchesAndWriteToFile(MatchesFileWriteArguments args);
}
