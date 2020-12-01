using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using HomeSalesStatistics.Model;

namespace HomeSalesStatistics.OffersSearcher.olx
{
    internal class OlxSearcher : ISearcher
    {
        private readonly IWebPageContentGetter _webPageContentGetter = new WebPageContentGetter();
        private readonly OlxOfferPriceParser _priceParser = new OlxOfferPriceParser();
        private readonly OlxOfferSurfaceParser _surfaceParser = new OlxOfferSurfaceParser();
        private readonly OlxOfferPublicationDateParser _publicationDateParser = new OlxOfferPublicationDateParser();

        private const string OlxUrl = "https://www.olx.pl/nieruchomosci/mieszkania/sprzedaz/lublin/?view=list";

        public IEnumerable<HouseSaleOffer> SearchForOffers()
        {
            var html = _webPageContentGetter.GetWebPageContent(OlxUrl);
            var cleanedHtmlContent = html.Replace("\n", "").Replace("\r", "").Replace("\t", "").Replace(" ", "");

            var otodomOffers = new List<string>(GetOffersWithOtodomInLink(cleanedHtmlContent));
            var olxOffers = new List<string>(GetOffersWithOlxInLink(cleanedHtmlContent));

            var houseSaleOffers = new List<HouseSaleOffer>();

            foreach (var olxOffer in olxOffers)
            {
                var price = _priceParser.GetOfferPrice(olxOffer);
                var surface = _surfaceParser.GetSurface(olxOffer);
                var publicationDate = _publicationDateParser.GetOfferPublicationDate(olxOffer);

                houseSaleOffers.Add(new HouseSaleOffer
                {
                    Price = price,
                    Surface = surface,
                    url = olxOffer,
                    PublicationDate = publicationDate
                });
            }

            return houseSaleOffers;

            //todo parse also otodom offers
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
