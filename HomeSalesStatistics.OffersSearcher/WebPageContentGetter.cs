using System;
using System.IO;
using System.Net;

namespace HomeSalesStatistics.OffersSearcher
{
    internal class WebPageContentGetter : IWebPageContentGetter
    {
        public string GetWebPageContent(string url)
        {
            try
            {
                WebRequest webRequest = WebRequest.Create(url);

                WebResponse response = webRequest.GetResponse();

                using (Stream dataStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(dataStream);

                    return reader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }
    }
}
