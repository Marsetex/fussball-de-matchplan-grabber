using FDMatchplanGrabber.Business.Dtos;

namespace FDMatchplanGrabber.Business.Services.Contracts
{
    public interface IFileService
    {
        Task WriteToFile(IEnumerable<FussballDeMatch> match, string storageDirectory, string fileName, string fileFormat);
    }
}