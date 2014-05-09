using System.Linq;
using System.Net;
using HtmlAgilityPack;

namespace RiskMeter.WebScraper.Pages
{
    public abstract class CityDataPage
    {
        const string BaseUrl = "http://www.city-data.com/crime/";

        private const string UserAgent =
            "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/31.0.1650.59 Safari/537.36";

        private HtmlDocument _document;
        private HtmlWeb _htmlWeb;

        protected CityDataPage() : this(string.Empty)
        {
        }

        protected CityDataPage(string path)
        {
            Path = path;
        }

        protected string Url
        {
            get { return BaseUrl + Path; }
        }
        protected string Path { get; set; }

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
                    PreRequest = OnPreRequest,
                    PostResponse = OnAfterResponse
                });
            }
        }

        protected CookieCollection Cookies { get; set; }

        protected string GetDocumentTitle()
        {
            var singleOrDefault = Document.DocumentNode.Descendants("title").SingleOrDefault();
            if (singleOrDefault != null)
                return singleOrDefault.InnerText;
                
            return string.Empty;
        }

        private bool OnPreRequest(HttpWebRequest request)
        {
            AddCookiesTo(request);

            return true;
        }
        private void OnAfterResponse(HttpWebRequest request, HttpWebResponse response)
        {
            SaveCookiesFrom(response);
        }

        private void SaveCookiesFrom(HttpWebResponse response)
        {
            if (response.Cookies.Count > 0)
            {
                if (Cookies == null) Cookies = new CookieCollection();
                Cookies.Add(response.Cookies);
            }
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