
using Microsoft.Extensions.Configuration;
using QMoneyCodeChallenge.Tests.QMoneyTests;

namespace QMoneyCodeChallenge.Tests.QMoney;

public class Tests : TestSetUp
{
    private readonly string _QMoneyAppUrl;
    private readonly string _QMoneyApp_ExpectedUrl;
    public Tests()
    {
        var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();
        _QMoneyAppUrl = configuration["PageSettings:QMoneyAppUrl"] ?? string.Empty;

        _QMoneyApp_ExpectedUrl = configuration["PageSettings:QMoneyApp_ExpectedUrl"] ?? string.Empty;
    }
    
    [Test]

    //AC1: As an end user on the Qantas Money App page, when I click the Google Play button, I am taken to the following URL.
    public async Task QMoneyApp_GooglePlayButton_Navigation_Check()
    {
        await Initialize();
        await Page.GotoAsync(_QMoneyAppUrl);
        var image = Page.Locator("img[src='//images.ctfassets.net/2wgn0n5ijj9k/7yXkbI5NS0EIEmmIskOWwc/e51dfa4d74c0c6516e2582b748a3602a/google-play-download.svg'][alt='Get it on Google Play']").First;
        await image.ClickAsync();
        var ExpectedUrl = _QMoneyApp_ExpectedUrl;

        //Assert

        var CurrentURL = Page.Url;
        //Assert.AreEqual(ExpectedUrl, CurrentURL);
        if (CurrentURL.Equals(ExpectedUrl, StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Verification Passed: The current URL matches the expected URL.");
        }
        else
        {
            Console.WriteLine($"Verification Failed: Expected URL: {ExpectedUrl}, But got: {CurrentURL}");
        }

    }

}  
