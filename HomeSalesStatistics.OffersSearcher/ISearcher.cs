using System.Collections.Generic;
using HomeSalesStatistics.Model;

namespace HomeSalesStatistics.OffersSearcher
{
    public interface ISearcher
    {
        IEnumerable<HouseSaleOffer> SearchForOffers();
    }
}
