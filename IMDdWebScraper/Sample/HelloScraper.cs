using IronWebScraper;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDdWebScraper.Sample
{
    public class HelloScraper : WebScraper
    {
        /// <summary>
        /// Override this method initialize your web-scraper.
        /// Important tasks will be to Request at least one start url... and set allowed/banned domain or url patterns.
        /// </summary>
        public override void Init()
        {
            License.LicenseKey = "LicenseKey"; // Write License Key
            this.LoggingLevel = WebScraper.LogLevel.All; // All Events Are Logged
            this.Request("https://blog.scrapinghub.com", Parse);
        }

        /// <summary>
        /// Override this method to create the default Response handler for your web scraper.
        /// If you have multiple page types, you can add additional similar methods.
        /// </summary>
        /// <param name="response">The http Response object to parse</param>
        public override void Parse(Response response)
        {
            // set working directory for the project
            this.WorkingDirectory = AppSetting.GetAppRoot() + @"\HelloScraperSample\Output\";
            // Loop on all Links
            foreach (var title_link in response.Css("h2.entry-title a"))
            {
                // Read Link Text
                string strTitle = title_link.TextContentClean;
                // Save Result to File
                Scrape(new ScrapedData() { { "Title", strTitle } }, "HelloScraper.Jsonl");
            }
            // Loop On All Links
            if (response.CssExists("div.prev-post > a[href]"))
            {
                // Get Link URL
                var next_page = response.Css("div.prev-post > a[href]")[0].Attributes["href"];
                // Scrpae Next URL
                this.Request(next_page, Parse);
            }
        }
    }
}
