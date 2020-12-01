using System;
using System.Collections.Generic;
using HomeSalesStatistics.Model;
using HomeSalesStatistics.OffersSearcher.olx;
using Microsoft.Extensions.DependencyInjection;

namespace HomeSalesStatistics.OffersSearcher
{
    public class Searcher : ISearcher
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IEnumerable<ISearcher> _searchers;

        public Searcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _searchers = InitializeSearchers();
        }

        public IEnumerable<HouseSaleOffer> SearchForOffers()
        {
            var offers = new List<HouseSaleOffer>();

            foreach (var searcher in _searchers)
            {
                offers.AddRange(searcher.SearchForOffers());
            }

            return offers;
        }

        private IEnumerable<ISearcher> InitializeSearchers()
        {
            return new ISearcher[] {_serviceProvider.GetRequiredService<OlxSearcher>()};
        }
    }
}
