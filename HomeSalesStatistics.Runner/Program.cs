using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HomeSalesStatistics.DataAccess.Repository;
using HomeSalesStatistics.Model;
using HomeSalesStatistics.OffersSearcher;
using HomeSalesStatistics.OffersSearcher.olx;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HomeSalesStatistics.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var scope = host.Services.CreateScope();

            var homeOffersSearcher = scope.ServiceProvider.GetRequiredService<ISearcher>();
            var repository = scope.ServiceProvider.GetRequiredService<IHouseSellingOffersRepository>();

            var foundedHomeSalesOffers = homeOffersSearcher.SearchForOffers();

            repository.Bulk(foundedHomeSalesOffers);

            Console.ReadLine();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddTransient<ISearcher, Searcher>();
                    services.AddTransient<IHouseSellingOffersRepository, HouseSellingOffersRepository>();
                    DependencyInjectionContainer.RegisterServices(services);
                });
    }
}
