using System.Text;
using FDMatchplanGrabber.Business.Services.Contracts;
using FDMatchplanGrabber.Business.Dtos;

namespace FDMatchplanGrabber.Business.Services
{
    public class FileWriterService : IFileService
    {
        private readonly MatchDataConverter _matchDataConverter;
        private readonly string _dateFormat;

        public FileWriterService(string dateFormat)
        {
            _matchDataConverter = new MatchDataConverter();
            _dateFormat = dateFormat;
        }

        public async Task WriteToFile(IEnumerable<FussballDeMatch> matches, string storageDirectory, string fileName, string fileFormat)
        {
            var convertedMatches = _matchDataConverter.ConvertMatchToCsv(matches, _dateFormat);

            var builder = new StringBuilder();
            builder.Append(convertedMatches.HeaderElements + "\n");
            foreach (var match in convertedMatches.MatchElements)
            {
                builder.Append(match + "\n");
                Console.WriteLine("Writing match: " + match);
            }

            if (!Directory.Exists(storageDirectory))
            {
                Directory.CreateDirectory(storageDirectory);
            }

            var abolsutePathToFile = $"{storageDirectory}\\{fileName}{fileFormat}";
            await File.WriteAllTextAsync(abolsutePathToFile, builder.ToString(), Encoding.UTF8);
        }
    }
}