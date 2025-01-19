using FDMatchplanGrabber.Business.Dtos;

namespace FDMatchplanGrabber.Business.Services.Contracts;

public interface IHtmlDomParserService
{
    public IEnumerable<FussballDeMatch> ParseFussballDeMatchplanDom(string htmlDom);
}
