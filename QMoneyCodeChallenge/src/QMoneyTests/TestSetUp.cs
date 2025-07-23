using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace QMoneyCodeChallenge.src.QMoneyTests
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
                //await Setup();
            }
        }
        /*[SetUp]
        public async Task<IResponse?> Setup()
        {
            var url1 = await Page.GotoAsync(url: "https://www.qantasmoney.com/app");
            var url2 = await Page.GotoAsync(url: "https://www.qantasmoney.com/");
            return url1;
        }*/


    }
}