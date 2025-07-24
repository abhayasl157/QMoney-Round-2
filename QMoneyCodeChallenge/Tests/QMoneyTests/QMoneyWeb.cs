
using Microsoft.Extensions.Configuration;
using QMoneyCodeChallenge.Tests.QMoneyTests;

namespace QMoneyCode_Challenge.Tests.QMoneyTests
{
    public class Tests : TestSetUp
    {
        private readonly string _QMoneyWebUrl;
        private readonly string _QMoneyWeb_QPayUrl;

        public Tests()
        {
            var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false)
                    .Build();
            _QMoneyWebUrl = configuration["PageSettings:QMoneyWebUrl"] ?? string.Empty;
            _QMoneyWeb_QPayUrl = configuration["PageSettings:QMoneyWeb_QPayUrl"] ?? string.Empty;

        }

        [Test]

        //AC2: As an end user on the Qantas Money home page, when I click the upper right “Log in” button, I am taken to the Qantas Money Login page.
        public async Task QMoneyWeb_LoginButton_QMoney_Navigation_check()
        {
            await Initialize();
            await Page.GotoAsync(_QMoneyWebUrl);
            await Page.Locator(".icon-close").ClickAsync();
            await Page.Locator(".LoginLinks_loginBtn__Ez_2l").ClickAsync();
            var button = Page.Locator(".SubLoginLink_copyContainer__kN_F8").First.ClickAsync();
            //var ExpectedUrl = '$(new Regex(\".*accounts.qantas.com/auth/member/*\"))';

            //Assert
            var CurrentURL = Page.Url;
            //Assert.Equals(CurrentURL, (new Regex(".*accounts.qantas.com/auth/member/*")));
            var uri = new Uri(CurrentURL);
            string AbsoluteExpectedPath = $"{uri.Host}{uri.AbsolutePath}"; // to extract the Host and absolute path from the expected url
            if (CurrentURL.Contains(AbsoluteExpectedPath))
            {
                Console.WriteLine("Verification Passed: The current URL matches the expected URL.");
            }
            else
            {
                Console.WriteLine($"Verification Failed: Expected URL: {AbsoluteExpectedPath}, But landed on: {CurrentURL}");
            }


        }

        [Test]

        //AC4: As an end user on the Buy Foreign Currency page, if I enter $2500AUD into the calculator, it will show me that I can earn 3,750 Qantas Points.
        public async Task QMoneyWeb_QPay_PointsCheck()
        {
            await Initialize();
            await Page.GotoAsync(_QMoneyWeb_QPayUrl);
            await Page.Locator("#source-amount").FillAsync("2500");

            //Assert
            //await Except(Page).ToContainTextAsync(new Regex("\\d 3,750 PTS"));
            var locator = Page.Locator(".QPayCalculatorsEarnSection_root__JNVIL");
            var result = await locator.InnerTextAsync();
            Assert.That(result.Contains("3,750"));
            await Page.CloseAsync();

        }

    }

}
