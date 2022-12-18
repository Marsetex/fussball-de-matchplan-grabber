using FDMatchplanGrabber.Service.Business.Dtos;
using FDMatchplanGrabber.Service.Business.Proxies;
using FDMatchplanGrabber.Service.Business.Services.Contracts;

namespace FDMatchplanGrabber.Service.Business.Services;

public class MatchplanGrabberApplicationService : IMatchplanGrabberApplicationService
{
    private readonly FussballDeProxy _fussballDeProxy;
    private readonly HtmlDomParserService _parserService;

    public MatchplanGrabberApplicationService()
    {
        _fussballDeProxy = new FussballDeProxy();
        _parserService = new HtmlDomParserService();
    }

    public async Task<IEnumerable<FussballDeMatch>> GetMatches(string urlToMatchplan)
    {
        var htmlDom = await _fussballDeProxy.GetMatchplanHtmlDom(urlToMatchplan).ConfigureAwait(false);
        return _parserService.ParseFussballDeMatchplanDom(htmlDom);
    }

    public async Task<IEnumerable<FussballDeMatch>> GetMatchesAndWriteToFile(string urlToMatchplan, string storageDirectory, string fileName, string fileFormat, string dateFormat)
    {
        var _fileWriterService = new FileWriterService(dateFormat);

        var matches = await GetMatches(urlToMatchplan).ConfigureAwait(false);
        
        await _fileWriterService.WriteToFile(matches, storageDirectory, fileName, fileFormat).ConfigureAwait(false);

        return matches;
    }
}
