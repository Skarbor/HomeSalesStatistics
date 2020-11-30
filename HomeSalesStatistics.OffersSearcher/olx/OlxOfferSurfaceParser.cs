using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace HomeSalesStatistics.OffersSearcher.olx
{
    public class OlxOfferSurfaceParser
    {
        private readonly IWebPageContentGetter _webPageContentGetter = new WebPageContentGetter();

        //<strong class="offer-details__value">51,50 m²</strong>
        private readonly string surfaceRegex = @"<strong class=""offer-details__value"">([0-9,]*) m²</strong>";
        public decimal GetSurface(string linkToOffer)
        {
            var html = _webPageContentGetter.GetWebPageContent(linkToOffer);

            var rx = new Regex(surfaceRegex);
            var surfaceString = rx.Matches(html).Select(match => match.Groups[1].Value).First();
            var surfaceStringReadyForCasting = surfaceString.Replace(",", ".");
            return decimal.Parse(surfaceStringReadyForCasting);
        }
    }
}
