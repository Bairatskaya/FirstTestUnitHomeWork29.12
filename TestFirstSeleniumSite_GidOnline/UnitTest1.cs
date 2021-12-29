using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;


namespace TestFirstSeleniumSite_GidOnline
{
    public class UnitTest1:IDisposable
    {
        IWebDriver chrome;

        [Fact]
        public void TestEnterChernobl()
        {
            chrome = new ChromeDriver();
            chrome.Navigate().GoToUrl("https://gidonline.io/");
            IWebElement elem = chrome.FindElement(By.Name("s"));
            elem.Click();
            elem.SendKeys("Чернобыль");
            elem.SendKeys(Keys.Enter);
            string a = chrome.Url;
            Assert.Equal("https://gidonline.io/film/chernobyl/",a);
        }
        [Fact]
        public void TestFindTriller()
        {
            chrome = new ChromeDriver();
            chrome.Navigate().GoToUrl("https://gidonline.io/");
            IWebElement elem = chrome.FindElement(By.CssSelector("a[href='/genre/triller/']"));
            elem.Click();
            string a = chrome.Url;
            Assert.Equal("https://gidonline.io/genre/triller/", a);
        }
        [Fact]
        public void TestMeilToFuture()
        {
             chrome = new ChromeDriver();
            chrome.Navigate().GoToUrl("https://future-mail.org/");
            IWebElement elem = chrome.FindElement(By.Id("new_letter"));
            elem.Click();
            Thread.Sleep(2000);
            IWebElement elem2 = chrome.FindElement(By.Id("author"));
            elem2.SendKeys("Mail to the future");
            IWebElement elem3 = chrome.FindElement(By.Id("comment2"));
            elem3.SendKeys("Everything will be fine");
            IWebElement elem4 = chrome.FindElement(By.Id("inlineDatepicker"));
            elem4.Click();
            IWebElement elem5 = chrome.FindElement(By.Name("may"));
            elem5.Click();
            elem5.SendKeys("razdvatri@gmail.com");
            IWebElement elem6 = chrome.FindElement(By.Id("h_2"));
            elem6.Click();

        }

        [Fact]
        public void TestOpenRegistr()
        {
             chrome = new ChromeDriver();
            chrome.Navigate().GoToUrl("https://www.facebook.com/");
            IWebElement elem = chrome.FindElement(By.CssSelector("a[data-testid='open-registration-form-button']"));
            elem.Click();
            Thread.Sleep(2000);
            IWebElement elem1 = chrome.FindElement(By.XPath("//html[@id='facebook']/body/div[3]/div[2]/div/div/div/div"));            string actual = elem1.Text;
            Assert.Equal("Регистрация",actual);

        }
        [Fact]
        public void TestClickVideo()
        {
            chrome = new ChromeDriver();
            chrome.Navigate().GoToUrl("http://shitday.de/");
            IWebElement elem = chrome.FindElement(By.Id("video"));
            Thread.Sleep(2000);
            elem.Click();
            Thread.Sleep(2000);
            elem.Click();
            Thread.Sleep(2000);
            elem.Click();
            Thread.Sleep(1000);
        }
        [Fact]
        public void TestPutEmail()
        {
             chrome = new ChromeDriver();
            chrome.Navigate().GoToUrl("https://ek.ua/");
            IWebElement elem = chrome.FindElement(By.ClassName("header_action_login"));
            elem.Click();
            Thread.Sleep(3000);
            IWebElement elem2 = chrome.FindElement(By.CssSelector("div[class='signin-with signin-with-ek d-flex justify-content-center align-items-center']"));
            elem2.Click();
            Thread.Sleep(3000);
            IWebElement elem3 = chrome.FindElement(By.Name("l_"));
            elem3.Click();
            elem3.SendKeys("user@gm.com");
            IWebElement elem4 = chrome.FindElement(By.Name("pw_"));
            elem4.Click();
            elem4.SendKeys("user");
            IWebElement elem5 = chrome.FindElement(By.CssSelector("button[class='ek-form-btn blue']"));
            elem5.Click();
            IWebElement elem6 = chrome.FindElement(By.ClassName("info-nick"));
            elem6.Click();
            string a = chrome.Url;
            Assert.Equal("https://ek.ua/ek-wu.php?idwu_=gxuvu2a7082&view_=user", a);

        }
        [Fact]
        public void TestEkSearch()
        {
             chrome = new ChromeDriver();
            chrome.Navigate().GoToUrl("https://ek.ua/");
            IWebElement elem = chrome.FindElement(By.Id("ek-search"));
            elem.Click();
            elem.SendKeys("iphone 13");
            IWebElement elem2 = chrome.FindElement(By.Name("search_but_"));
            elem2.Click();
            IWebElement elem3 = chrome.FindElement(By.ClassName("highlight-search"));
            elem3.Click();
            string a = chrome.Url;
            Assert.Equal("https://ek.ua/APPLE-IPHONE-13-128GB.htm", a);
        }
        [Fact]
        public void TestOptionLeng()
        {
            chrome = new ChromeDriver();
            chrome.Navigate().GoToUrl("https://ek.ua/");
            IWebElement elem = chrome.FindElement(By.ClassName("cr-contr"));
            elem.Click();
            Thread.Sleep(2000);
            IWebElement elem2 = chrome.FindElement(By.CssSelector("div[class='ek-form-control lf-select']"));
            elem2.Click();
            Thread.Sleep(2000);
            IWebElement elem3 = chrome.FindElement(By.CssSelector("a[class='option']"));
            elem3.Click();
            string a = chrome.Url;
            Assert.Equal("https://e-katalog.pl/", a);

        }
        [Fact]
        public void TestLinkYoutubeinEk()
        {
             chrome = new ChromeDriver();
            chrome.Navigate().GoToUrl("https://ek.ua/");      
            IWebElement element = chrome.FindElement(By.CssSelector("a[title='YouTube']"));
            element.Click();
            string elem = chrome.FindElement(By.CssSelector("a[title='YouTube']")).GetAttribute("href");
            Assert.Equal("https://www.youtube.com/c/ekatalogofficial/", elem);
        }
        [Fact]
        public void TestBallYesNo()
        {
             chrome = new ChromeDriver();
            chrome.Navigate().GoToUrl("https://8-gund.com/ru/");
            Thread.Sleep(3000);
            IWebElement elem = chrome.FindElement(By.Id("yourq"));
            elem.Click();
            Thread.Sleep(3000);
            elem.SendKeys("Мы ждем нет или да");
            IWebElement elem1 = chrome.FindElement(By.ClassName("ball-text"));
            string a;
            do
            {
                elem.SendKeys(Keys.Enter);
                Thread.Sleep(1000);
                a = elem1.GetAttribute("textContent");
            }
            while (!a.Contains("Да"));
            Assert.Equal("Да", a);

        }

        public void Dispose()
        {
           chrome.Quit();
        }
    }
}

