using System.Net;
using HtmlAgilityPack;

namespace RiskMeter.WebScraper.PageScrapers
{
    public abstract class DataScraper
    {
        const string BaseUrl = "http://www.city-data.com/crime/";

        private HtmlDocument _document;
        private HtmlWeb _htmlWeb;

        private const string UserAgent =
            "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/31.0.1650.59 Safari/537.36";

        protected DataScraper()
        {
            Url = BaseUrl;


        }

        protected DataScraper(string url)
        {
            Url = BaseUrl + url;
        }

        protected string Url { get; set; }

        protected HtmlDocument Document
        {
            get
            {
                if (_document == null)
                {
                    _document = new HtmlDocument();
                    _document = Web.Load(Url);
                }

                return _document;
            }
        }

        protected HtmlWeb Web
        {
            get
            {
                return _htmlWeb ?? (_htmlWeb = new HtmlWeb
                {
                    UserAgent = UserAgent,
                    UseCookies = true,
                    AutoDetectEncoding = true,
                    PreRequest = OnPreRequest
                });
            }
        }

        protected CookieCollection Cookies
        {
            get
            {
                return new CookieCollection()
                {
                    new Cookie("__qca", "P0-1845033264-1396026927988", "/", "city-data.com"),
                    new Cookie("BCSI-AC-8cb6d2318d5100e4", "226E2A62000000063j2AsUvCJWzd3mQZVMvoAAD3O6gDAAAABgAAANgJCQAg/QAAAAAAAIsrAAA=", "/", "city-data.com"),
                    new Cookie("__utma", "26892847.434413862.1396026929.1398634598.1398705941.6", "/", "city-data.com"),
                    new Cookie("__utmb", "26892847.5.10.1398705941", "/", "city-data.com"),
                    new Cookie("__utmc", "26892847", "/", "city-data.com"),
                    new Cookie("__utmz", "26892847.1396027363.2.2.utmcsr=google|utmccn=(organic)|utmcmd=organic|utmctr=(not%20provided)", "/", "city-data.com"),
                };
            }
        }

        private bool OnPreRequest(HttpWebRequest request)
        {
            AddCookiesTo(request);

            return true;
        }

        private void AddCookiesTo(HttpWebRequest request)
        {
            if (Cookies != null && Cookies.Count > 0)
            {
                request.CookieContainer.Add(Cookies);
            }
        }
    }
}