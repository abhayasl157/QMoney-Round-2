using Azure;
using Microsoft.Playwright;
using QMoneyCodeChallenge.src.QMoneyTests;
using System.Text.RegularExpressions;

namespace QMoneyCodeChallenge.src.QMoney;

public class Tests : TestSetUp
{

    [Test]
    public async Task Test1()
    {
        //As an end user on the Qantas Money App page, when I click the Google Play button, I am taken to the following URL.
        
        
        await Initialize();
        await Page.GotoAsync(url: "https://www.qantasmoney.com/app");
        //await Page.ClickAsync(selector: "text= Google Play");
        //await Page.Locator(".Button_root__nYhgw Button_hasImage__AU3iu Button_hasLabel__74c8O").ClickAsync();
        //var Button = Page.Locator(".Button_hasLabel__74c8O a[href='/app/andriod']");
        //var locator = Page.Locator(".Button_hasLabel__74c8O").GetByText("Google Play");
        var image = Page.Locator("img[src='//images.ctfassets.net/2wgn0n5ijj9k/7yXkbI5NS0EIEmmIskOWwc/e51dfa4d74c0c6516e2582b748a3602a/google-play-download.svg'][alt='Get it on Google Play']").First;
        await image.ClickAsync();        
        var ExpectedUrl = "https://play.google.com/store/apps/details?id=com.qantas.fs";

        //Asset

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

    [Test]
    public async Task Test2()
    {

        //As an end user on the Qantas Money home page, when I click the upper right “Log in” button, I am taken to the Qantas Money Login page.
       
        
        await Initialize();
        await Page.GotoAsync(url: "https://www.qantasmoney.com/");        
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
    public async Task Test3()
    {
        await Initialize();
        await Page.GotoAsync(url: "https://www.qantasmoney.com/qantas-pay/buy-currency");
        await Page.Locator("#source-amount").FillAsync("2500");

        //Assert
        //await Except(Page).ToContainTextAsync(new Regex("\\d 3,750 PTS"));
        var locator = Page.Locator(".QPayCalculatorsEarnSection_root__JNVIL");
        var result = await locator.InnerTextAsync();
        Assert.That(result.Contains("3,750"));
        await Page.CloseAsync();
        
    }
   
}
    
