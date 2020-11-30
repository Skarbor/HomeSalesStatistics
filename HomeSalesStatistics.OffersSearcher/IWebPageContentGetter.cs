using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeSalesStatistics.OffersSearcher
{
    public interface IWebPageContentGetter
    {
        string GetWebPageContent(string url);
    }
}
