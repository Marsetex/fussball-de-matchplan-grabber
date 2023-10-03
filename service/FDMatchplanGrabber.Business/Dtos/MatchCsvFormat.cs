namespace FDMatchplanGrabber.Business.Dtos
{
    public record MatchCsvFormat
    (
        string HeaderElements,
        string[] MatchElements
    );
}