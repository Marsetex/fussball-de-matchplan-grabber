namespace FDMatchplanGrabber.Service.Business.Arguments
{
    public record MatchesFileWriteArguments
    (
        string UrlToMatchplan,
        string StorageDirectory,
        string FileName, 
        string FileFormat, 
        string DateFormat
    );
}
