﻿using FDMatchplanGrabber.Business.Dtos;
using FDMatchplanGrabber.Business.Services.Contracts;
using FDMatchplanGrabber.Proxy.FusballDe;
using FDMatchplanGrabber.Service.Business.Services;

namespace FDMatchplanGrabber.Business.Services;

public class MatchplanGrabberApplicationService : IMatchplanGrabberApplicationService
{
    private readonly IFussballDeProxy _fussballDeProxy;
    private readonly IHtmlDomParserService _parserService;
    private readonly IFileWriterService _fileWriterService;

    public MatchplanGrabberApplicationService()
    {
        _fussballDeProxy = new FussballDeProxy();
        _parserService = new HtmlDomParserService();
        _fileWriterService = new FileWriterService();
    }

    public async Task<IEnumerable<FussballDeMatch>> GetMatches(string urlToMatchplan)
    {
        var htmlDom = await _fussballDeProxy.GetMatchplanHtmlDom(urlToMatchplan).ConfigureAwait(false);
        return _parserService.ParseFussballDeMatchplanDom(htmlDom);
    }

    public async Task<IEnumerable<FussballDeMatch>> GetMatchesAndWriteToFile(MatchesFileWriteDto fileWriteDto)
    {
        var matches = await GetMatches(fileWriteDto.UrlToMatchplan).ConfigureAwait(false);
        
        await _fileWriterService.WriteToFile(
            matches,
            fileWriteDto.StorageDirectory,
            fileWriteDto.FileName,
            fileWriteDto.FileFormat,
            fileWriteDto.DateFormat).ConfigureAwait(false);

        return matches;
    }
}
