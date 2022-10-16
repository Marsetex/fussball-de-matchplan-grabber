using System.Text;
using FDMatchplanGrabber.Service.Business.Dtos;
using FDMatchplanGrabber.Service.Business.Services.Contracts;

namespace FDMatchplanGrabber.Service.Business.Services
{
    public class FileWriterService : IFileService
    {
        private readonly MatchDataConverter _matchDataConverter;

        public FileWriterService()
        {
            _matchDataConverter = new MatchDataConverter();
        }

        public async Task WriteToCsvFile(IEnumerable<FussballDeMatch> matches)
        {
            var convertedMatches = _matchDataConverter.ConvertMatchToCsv(matches);

            var builder = new StringBuilder();
            builder.Append(convertedMatches.HeaderElements + "\n");
            foreach (var match in convertedMatches.MatchElements)
            {
                builder.Append(match + "\n");
                System.Console.WriteLine("Writing match: " + match);
            }

            await File.WriteAllTextAsync("C:\\Tmp\\Matches.csv", builder.ToString());
        }
    }
}