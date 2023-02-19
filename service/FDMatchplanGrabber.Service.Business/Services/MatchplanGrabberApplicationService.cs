using FDMatchplanGrabber.Service.Business.Arguments;
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

    public async Task<IEnumerable<FussballDeMatch>> GetMatchesAndWriteToFile(MatchesFileWriteArguments args)
    {
        var _fileWriterService = new FileWriterService(args.DateFormat);

        var matches = await GetMatches(args.UrlToMatchplan).ConfigureAwait(false);
        
        await _fileWriterService.WriteToFile(matches, args.StorageDirectory, args.FileName, args.FileFormat).ConfigureAwait(false);

        return matches;
    }
}
