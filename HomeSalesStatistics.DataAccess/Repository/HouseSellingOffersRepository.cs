using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HomeSalesStatistics.Model;

namespace HomeSalesStatistics.DataAccess.Repository
{
    public class HouseSellingOffersRepository : IHouseSellingOffersRepository
    {
        readonly ApplicationDbContext _context = new ApplicationDbContext(); //todo DI

        public HouseSellingOffersRepository()
        {
            _context.Database.EnsureCreated();
        }

        public void Add(HouseSaleOffer houseSellingOffer)
        {
            _context.HouseSaleOffers.Add(houseSellingOffer);
            _context.SaveChanges();
        }

        public void Bulk(IEnumerable<HouseSaleOffer> houseSellingOffers)
        {
            _context.HouseSaleOffers.AddRange(houseSellingOffers);
            _context.SaveChanges();
        }

        public IEnumerable<HouseSaleOffer> Get(Expression<Func<HouseSaleOffer, bool>> expression)
        {
            return _context.HouseSaleOffers.Where(expression).AsEnumerable();
        }
    }
}
