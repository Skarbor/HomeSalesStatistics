using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using HomeSalesStatistics.Model;

namespace HomeSalesStatistics.DataAccess.Repository
{
    public interface IHouseSellingOffersRepository
    {
        void Add(HouseSaleOffer houseSellingOffer);
        void Bulk(IEnumerable<HouseSaleOffer> houseSellingOffers);
        IEnumerable<HouseSaleOffer> Get(Expression<Func<HouseSaleOffer, bool>> expression);
    }
}