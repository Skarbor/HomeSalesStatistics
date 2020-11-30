using System;
using HomeSalesStatistics.OffersSearcher;
using HomeSalesStatistics.OffersSearcher.olx;

namespace HomeSalesStatistics.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebPageContentGetter webPageContentGetter = new WebPageContentGetter();

            OlxParser olx = new OlxParser();
            olx.GetOffersLinks();

            //var content = webPageContentGetter.GetWebPageContent(
            //    "https://www.olx.pl/nieruchomosci/mieszkania/sprzedaz/lublin/?view=list");

            //Console.WriteLine(content);

            Console.ReadLine();
        }
    }
}
