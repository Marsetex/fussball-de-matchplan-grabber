namespace FDMatchplanGrabber.Service.Business.Dtos
{
    public record MatchCsvFormat
    (
        string HeaderElements,
        string[] MatchElements
    );
}