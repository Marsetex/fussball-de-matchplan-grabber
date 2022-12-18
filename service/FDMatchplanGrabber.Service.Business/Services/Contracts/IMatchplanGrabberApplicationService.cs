using FDMatchplanGrabber.Service.Business.Dtos;

namespace FDMatchplanGrabber.Service.Business.Services.Contracts;

public interface IMatchplanGrabberApplicationService
{
    Task<IEnumerable<FussballDeMatch>> GetMatches(string urlToMatchplan);

    Task<IEnumerable<FussballDeMatch>> GetMatchesAndWriteToFile(string urlToMatchplan, string storageDirectory, string fileName, string fileFormat, string dateFormat);
}
