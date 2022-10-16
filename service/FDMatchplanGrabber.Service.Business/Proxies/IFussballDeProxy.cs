namespace FDMatchplanGrabber.Service.Business.Proxies
{
    public interface IFussballDeProxy
    {
        Task<string> GetMatchplanHtmlDom(string urlToMatchplan);
    }
}
