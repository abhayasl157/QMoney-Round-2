using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Extensions.Configuration;

namespace QMoneyCodeChallenge.Tests.QMoneyTests
{
    public class TestSetUp

    {
        public IPage? Page { get; set; }
        public async Task Initialize()
        {

            var browser = GlobalUsings.GetBrowser();
            if (browser == null) browser = await GlobalUsings.SetBrowser();
            if (browser != null && Page == null)
            {
                Page = await browser.NewPageAsync();
            }

            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

            string QMoneyAppUrl = configuration["PageSettings:QMoneyAppUrl"] ?? throw new InvalidOperationException("Config for QMoneyAppUrl missing");
            string QMoneyWebUrl = configuration["PageSettings:QMoneyWebUrl"] ?? throw new InvalidOperationException("Config for QMoneyWebUrl missing");
            string QMoneyWeb_QPayUrl = configuration["PageSettings:QMoneyWeb_QPayUrl"] ?? throw new InvalidOperationException("Config for QMoneyWeb_QPayUrl missing");
            string QMoneyApp_ExpectedUrl = configuration["PageSettings:QMoneyApp_ExpectedUrl"] ?? throw new InvalidOperationException("Config for QMoneyApp_ExpectedUrl missing");
        }



    }
}