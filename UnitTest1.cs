using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;

namespace TestingCICD
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver driver;
        private string appUrl;
        public TestContext testContext;

        public UnitTest1()
        {
        }

        [TestMethod]
        [TestCategory("Chrome")]
        public void TheBingSearchTest()
        {
            driver.Navigate().GoToUrl(appUrl);
            driver.Manage().Window.Maximize();
            IWebElement ele = driver.FindElement(By.Id("sb_form_q"));
            ele.SendKeys("Azure Pipelines");
            ele.SendKeys(Keys.Enter);
            driver.FindElement(By.XPath("//ol[@id='b_results']/li/div[2]/h2/a")).Click();
            Assert.IsTrue(driver.Title.Contains("Azure Pipelines"), "Verified title of the page");
        }

        public TestContext TestContext
        {
            get { return testContext; }
            set { testContext = value; }
        }

        [TestInitialize()]
        public void SetupTest()
        {
            appUrl = "https://www.bing.com/";
            string browser = "Chrome";
            switch (browser)
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                case "Edge":
                    driver = new EdgeDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }
        }

        [TestCleanup]
        public void CleanupTest()
        {
            driver.Quit();
        }
    }
}
