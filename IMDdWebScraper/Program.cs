using System;

namespace IMDdWebScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Create Object From Hello Scrape class
            IMDdWebScraper.Sample.HelloScraper scrape = new IMDdWebScraper.Sample.HelloScraper();
            // Start Scraping
            scrape.Start();
        }
    }
    }
}
