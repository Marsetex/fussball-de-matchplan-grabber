using FDMatchplanGrabber.Business.Dtos;

namespace FDMatchplanGrabber.Business.Services.Contracts
{
    public interface IFileWriterService
    {
        Task WriteToFile(IEnumerable<FussballDeMatch> match, string storageDirectory, string fileName, string fileFormat, string dateFormat);
    }
}