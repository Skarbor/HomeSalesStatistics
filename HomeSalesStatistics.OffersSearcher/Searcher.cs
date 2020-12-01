using System;
using System.Collections.Generic;
using HomeSalesStatistics.Model;
using HomeSalesStatistics.OffersSearcher.olx;

namespace HomeSalesStatistics.OffersSearcher
{
    public class Searcher : ISearcher
    {
        private readonly ISearcher[] _searchers = new ISearcher[] {new OlxSearcher()};
        public IEnumerable<HouseSaleOffer> SearchForOffers()
        {
            var offers = new List<HouseSaleOffer>();

            foreach (var searcher in _searchers)
            {
                offers.AddRange(searcher.SearchForOffers());
            }

            return offers;
        }
    }
}
