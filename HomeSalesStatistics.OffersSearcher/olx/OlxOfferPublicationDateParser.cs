using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace HomeSalesStatistics.OffersSearcher.olx
{
    public class OlxOfferPublicationDateParser
    {
        private readonly IWebPageContentGetter _webPageContentGetter = new WebPageContentGetter();
        private readonly string publicationDateRegex = @"<strong>o ([0-9:]*), ([0-9]*) ([a-z]*) ([0-9]*)</strong>";
        public DateTime GetOfferPublicationDate(string linkToOffer)
        {
            var html = _webPageContentGetter.GetWebPageContent(linkToOffer);

            var rx = new Regex(publicationDateRegex);
            var dayText = rx.Matches(html).Select(match => match.Groups[2].Value).First();
            var monthText = rx.Matches(html).Select(match => match.Groups[3].Value).First();
            var yearText = rx.Matches(html).Select(match => match.Groups[4].Value).First();

            var day = int.Parse(dayText);
            var month = GetMonthFromString((monthText));
            var year= int.Parse(yearText);

            return new DateTime(year, month, day);
        }

        private int GetMonthFromString(string monthText)
        {
            switch (monthText)
            {
                case "stycznia":
                    return 1;

                case "lutego":
                    return 2;

                case "marca":
                    return 3;

                case "kwietnia":
                    return 4;

                case "maja":
                    return 5;

                case "czerwca":
                    return 6;

                case "lipca":
                    return 7;

                case "sierpnia":
                    return 8;

                case "września":
                    return 9;

                case "października":
                    return 10;

                case "listopada":
                    return 11;

                case "grudnia":
                    return 12;

                default:
                    throw new ArgumentException($"Could not parse {monthText} as a month");
            }
        }
    }
}
