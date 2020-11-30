using System;

namespace HomeSalesStatistics.Model
{
    public class HouseSaleOffer
    {
        public string url { get; set; }
        public decimal Surface { get; set; }
        public decimal Price { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
