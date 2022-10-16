using FDMatchplanGrabber.Service.Business.Dtos;

namespace FDMatchplanGrabber.Service.Business.Services.Contracts
{
    public interface IFileService
    {
        Task WriteToCsvFile(IEnumerable<FussballDeMatch> match);
    }
}