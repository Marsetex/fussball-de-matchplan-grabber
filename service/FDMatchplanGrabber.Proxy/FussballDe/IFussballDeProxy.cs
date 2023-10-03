namespace FDMatchplanGrabber.Proxy.FusballDe
{
    public interface IFussballDeProxy
    {
        Task<string> GetMatchplanHtmlDom(string urlToMatchplan);
    }
}
