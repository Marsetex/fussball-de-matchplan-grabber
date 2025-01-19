using System.Text;
using FDMatchplanGrabber.Business.Services.Contracts;
using FDMatchplanGrabber.Business.Dtos;

namespace FDMatchplanGrabber.Business.Services;

public class FileWriterService : IFileWriterService
{
    private readonly MatchDataConverter _matchDataConverter;

    public FileWriterService()
    {
        _matchDataConverter = new MatchDataConverter();
    }

    public async Task WriteToFile(
        IEnumerable<FussballDeMatch> matches,
        string storageDirectory,
        string fileName,
        string fileFormat,
        string dateFormat)
    {
        var convertedMatches = _matchDataConverter.ConvertMatchToCsv(matches, dateFormat);

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
