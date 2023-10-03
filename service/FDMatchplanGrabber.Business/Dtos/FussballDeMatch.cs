namespace FDMatchplanGrabber.Business.Dtos
{
    public record FussballDeMatch
    (
        DateTime MatchDate,
        string Ground,
        string HomeTeam,
        string AwayTeam,
        string MatchLink
    );
}
