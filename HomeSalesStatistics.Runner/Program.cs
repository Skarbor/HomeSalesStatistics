using System;
using HomeSalesStatistics.DataAccess.Repository;
using HomeSalesStatistics.OffersSearcher;
using HomeSalesStatistics.OffersSearcher.olx;

namespace HomeSalesStatistics.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            ISearcher homeOffersSearcher = new Searcher();

            var foundedHomeSalesOffers = homeOffersSearcher.SearchForOffers();

            IHouseSellingOffersRepository repository = new HouseSellingOffersRepository();
            repository.Bulk(foundedHomeSalesOffers);

            Console.ReadLine();
        }
    }
}
