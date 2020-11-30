using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using HomeSalesStatistics.Model;

namespace HomeSalesStatistics.OffersSearcher.olx
{
    public class OlxParser
    {
        private readonly string url = "https://www.olx.pl/nieruchomosci/mieszkania/sprzedaz/lublin/?view=list";
        private readonly IWebPageContentGetter _webPageContentGetter = new WebPageContentGetter();
        public string GetOffersLinks()
        {
            var html = _webPageContentGetter.GetWebPageContent(url);

            var cleanedHtmlContent = html.Replace("\n", "").Replace("\r", "").Replace("\t", "").Replace(" ", "");

            var otodomOffers = new List<string>(GetOffersWithOtodomInLink(cleanedHtmlContent));
            var olxOffers = new List<string>(GetOffersWithOlxInLink(cleanedHtmlContent));

            OlxOfferPriceParser priceParser = new OlxOfferPriceParser();
            OlxOfferSurfaceParser surfaceParser = new OlxOfferSurfaceParser();
            OlxOfferPublicationDateParser publicationDateParser = new OlxOfferPublicationDateParser();

            var linkToOffer = olxOffers.First();

            var price = priceParser.GetOfferPrice(linkToOffer);
            var surface = surfaceParser.GetSurface(linkToOffer);
            var publicationDate = publicationDateParser.GetOfferPublicationDate(linkToOffer);

            return null;
        }

        private IEnumerable<string> GetOffersWithOtodomInLink(string htmlContent)
        {
            var getOffersLinksRegex = @"href=""(https://www.otodom.pl/oferta/[a-zA-Z-0-9:/.#;]*)";

            var rx = new Regex(getOffersLinksRegex);
            var offersDetailsLinks =  rx.Matches(htmlContent).Select(match => match.Groups[1].Value);

            return offersDetailsLinks;
        }

        private IEnumerable<string> GetOffersWithOlxInLink(string htmlContent)
        {
            var getOffersLinksRegex = @"<ahref=""(http[a-zA-Z-0-9:/.#;]*)""class=""marginright5";

            var rx = new Regex(getOffersLinksRegex);
            var offersDetailsLinks = rx.Matches(htmlContent).Select(match => match.Groups[1].Value);

            return offersDetailsLinks;
        }
    }
}
