using System.Linq;
using System.Text.RegularExpressions;

namespace HomeSalesStatistics.OffersSearcher.olx
{
    internal class OlxOfferPriceParser
    {
        private readonly IWebPageContentGetter _webPageContentGetter = new WebPageContentGetter();
        private readonly string priceRegex = @"<strong class=""pricelabel__value [not-]*arranged"">([0-9' ']*)zł</strong>";
        public decimal GetOfferPrice(string linkToOffer)
        {
            var html = _webPageContentGetter.GetWebPageContent(linkToOffer);

            var rx = new Regex(priceRegex);
            var priceString = rx.Matches(html).Select(match => match.Groups[1].Value).First();
            var priceStringWithoutSpaces = priceString.Replace(" ", "");
            return decimal.Parse(priceStringWithoutSpaces);
        }
    }
}
