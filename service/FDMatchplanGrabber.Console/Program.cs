using FDMatchplanGrabber.Service.Business.Services;

namespace FDMatchplanGrabber.Service.Console
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var url = "https://www.fussball.de/mannschaft/sv-ulm-sv-ulm-suedbaden/-/saison/2223/team-id/011MIAV6O4000000VTVG0001VTR8C1K7#!/";
            var dateFormat = "dd/MM/yyyy";
            var _applicationService = new MatchplanGrabberApplicationService();
            var _fileWriterService = new FileWriterService(dateFormat);

            System.Console.WriteLine("Start.");

            try
            {
                var matches = await _applicationService.GetMatches(url).ConfigureAwait(false);
                System.Console.WriteLine($"Retrived {matches.Count()} matches from FussballDe");

                //await _fileWriterService.WriteToCsvFile(matches);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("An error occured");
            }

            System.Console.WriteLine("Done.");
        }
    }
}