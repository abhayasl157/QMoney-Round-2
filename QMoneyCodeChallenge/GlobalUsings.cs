global using NUnit.Framework;
using Microsoft.Playwright;

namespace QMoneyCodeChallenge
{
    public static class GlobalUsings

    {
        private static IPlaywright? Player { get; set; }
        private static IBrowser? Browser { get; set; }

        public static IBrowser? GetBrowser()
        {
            return Browser;
        }

        public static async Task<IBrowser> SetBrowser()
        {
            Player = await Playwright.CreateAsync();
            Browser = await Player.Chromium.LaunchAsync(new BrowserTypeLaunchOptions

            {
                Headless = false
            });
            return Browser;
        }
    }
}
