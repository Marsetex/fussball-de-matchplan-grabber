using FDMatchplanGrabber.Service.Business.Dtos;

namespace FDMatchplanGrabber.Service.Business.Services.Contracts
{
    public interface IHtmlDomParserService
    {
        public IEnumerable<FussballDeMatch> ParseFussballDeMatchplanDom(string htmlDom);
    }
}
