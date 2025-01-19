namespace FDMatchplanGrabber.Proxy.FusballDe;

public class FussballDeProxy : IFussballDeProxy
{
    private readonly HttpClient _httpClient;

    public FussballDeProxy()
    {
        _httpClient = new HttpClient();
    }

    public async Task<string> GetMatchplanHtmlDom(string urlToMatchplan)
    {
        return await _httpClient.GetStringAsync(urlToMatchplan).ConfigureAwait(false);
    }
}
