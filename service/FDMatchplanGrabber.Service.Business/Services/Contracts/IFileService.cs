using FDMatchplanGrabber.Service.Business.Dtos;

namespace FDMatchplanGrabber.Service.Business.Services.Contracts
{
    public interface IFileService
    {
        Task WriteToFile(IEnumerable<FussballDeMatch> match, string storageDirectory, string fileName, string fileFormat);
    }
}