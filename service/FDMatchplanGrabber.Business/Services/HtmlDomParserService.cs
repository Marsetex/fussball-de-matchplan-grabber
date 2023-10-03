using FDMatchplanGrabber.Business.Dtos;
using FDMatchplanGrabber.Business.Mapper;
using FDMatchplanGrabber.Business.Services.Contracts;
using HtmlAgilityPack;

namespace FDMatchplanGrabber.Service.Business.Services
{
    public class HtmlDomParserService : IHtmlDomParserService
    {
        public IEnumerable<FussballDeMatch> ParseFussballDeMatchplanDom(string htmlDom)
        {
            HtmlDocument htmlSnippet = LoadHtmlDocument(htmlDom);
            var matchplanColumns = htmlSnippet.DocumentNode.SelectNodes("//*[@id='id-team-matchplan-table']//tbody//tr");

            if (matchplanColumns == null) 
            {
                return Enumerable.Empty<FussballDeMatch>();
            }

            var matches = new List<FussballDeMatch>();
            for (int i = 0; i < matchplanColumns.Count; i = i + 3)
            {
                var matchDateRow = matchplanColumns[i].SelectSingleNode(".//td");
                var teams = matchplanColumns[i + 2].SelectNodes(".//*[@class='club-name']");
                var matchLink = matchplanColumns[i + 2].SelectNodes(".//*[@class='column-detail']//a").First().GetAttributeValue("href", null);

                var matchDate = DateTime.ParseExact(matchDateRow.InnerText.Split(" Uhr | ")[0], "dddd, dd.MM.yyyy - HH:mm", null);
                
                matches.Add(FussballDeMatchMapper.MapToMatch(matchDate, teams[0].InnerText, teams[1].InnerText, matchLink));
            }

            return matches;
        }

        private static HtmlDocument LoadHtmlDocument(string htmlDom)
        {
            var htmlSnippet = new HtmlDocument();
            htmlSnippet.LoadHtml(htmlDom);

            return htmlSnippet;
        }
    }
}
