using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Support.UI;
using System;

namespace SuperPUBG.CS
{
    partial class mailBot
    {
        public IWebDriver Driver { get; set; }
        public WebDriverWait wait { get; set; }
        public IJavaScriptExecutor JS { get; set; }

        public IWebDriver EnterWithChrome()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("incognito");
            ChromeDriverService chromeService = ChromeDriverService.CreateDefaultService();
            chromeService.HideCommandPromptWindow = true;
            Driver = new ChromeDriver(chromeService, options);
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(12));
            JS = Driver as IJavaScriptExecutor;
            return Driver;
        }

        //public IWebDriver EnterWithChrome(SeleniumHost sh)
        //{
        //    ChromeOptions options = new ChromeOptions();
        //    options.AddArgument("incognito");
        //    ChromeDriverService chromeService = ChromeDriverService.CreateDefaultService();
        //    chromeService.HideCommandPromptWindow = true;
        //    Driver = new ChromeDriver(chromeService, options);

        //    sh.DriverService = chromeService;

        //    wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(12));
        //    JS = Driver as IJavaScriptExecutor;
        //    return Driver;
        //}

        //public IWebDriver EnterWithIE()
        //{
        //    InternetExplorerDriverService ieService = InternetExplorerDriverService.CreateDefaultService();
        //    ieService.HideCommandPromptWindow = true;
        //    Driver = new InternetExplorerDriver(ieService);
        //    wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(12));
        //    JS = Driver as IJavaScriptExecutor;
        //    return Driver;
        //}

        //public IWebDriver EnterWithIE(SeleniumHost sh)
        //{
        //    InternetExplorerDriverService ieService = InternetExplorerDriverService.CreateDefaultService();
        //    ieService.HideCommandPromptWindow = true;
        //    Driver = new InternetExplorerDriver(ieService);

        //    sh.DriverService = ieService;

        //    wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(12));
        //    JS = Driver as IJavaScriptExecutor;
        //    return Driver;
        //}

        public IWebDriver EnterWithPhantom()
        {
            PhantomJSDriverService phantomjsService = PhantomJSDriverService.CreateDefaultService();
            phantomjsService.HideCommandPromptWindow = true;
            Driver = new PhantomJSDriver(phantomjsService);
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(12));
            JS = Driver as IJavaScriptExecutor;
            return Driver;
        }
    }
}
