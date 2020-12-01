using HomeSalesStatistics.OffersSearcher.olx;
using Microsoft.Extensions.DependencyInjection;

namespace HomeSalesStatistics.OffersSearcher
{
    public class DependencyInjectionContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IWebPageContentGetter, WebPageContentGetter>();
            services.AddTransient<OlxSearcher, OlxSearcher>();
        }
    }
}
