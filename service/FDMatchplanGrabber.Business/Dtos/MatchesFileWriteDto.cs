namespace FDMatchplanGrabber.Business.Dtos
{
    public record MatchesFileWriteDto
    (
        string UrlToMatchplan,
        string StorageDirectory,
        string FileName,
        string FileFormat,
        string DateFormat
    );
}
