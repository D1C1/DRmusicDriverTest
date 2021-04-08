using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

namespace DRmusicDriverTest
{
    [TestClass]
    public class EdgeDriverTest
    {
        // In order to run the below test(s), 
        // please follow the instructions from http://go.microsoft.com/fwlink/?LinkId=619687
        // to install Microsoft WebDriver.

        private EdgeDriver _driver;

        [TestInitialize]
        public void EdgeDriverInitialize()
        {
            // Initialize edge driver 
            var options = new EdgeOptions
            {
                PageLoadStrategy = PageLoadStrategy.Normal
            };
            _driver = new EdgeDriver("C:\\webDrivers");
        }

        [TestMethod]
        public void VerifyPageTitle()
        {
            // Replace with your own test logic
            _driver.Navigate().GoToUrl("https://www.bing.com");
            //_driver.Url = "https://www.bing.com";
            Assert.AreEqual("Bing", _driver.Title);
        }
        [TestMethod]
        public void TestMethod1()
        {
            _driver.Navigate().GoToUrl("file:///C:/mortenLP/HTML/DrMusic/index.html");
            string title = _driver.Title;
            Assert.AreEqual("Dr music", title);

            //recordList
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement recordList = wait.Until(d => d.FindElement(By.Id("recordList")));
            Assert.IsTrue(recordList.Text.Contains("Elephant"));

            //Post test
            IWebElement titleIn = _driver.FindElement(By.Id("TitleInput"));
            IWebElement artistIn = _driver.FindElement(By.Id("ArtistInput"));
            IWebElement durationIn = _driver.FindElement(By.Id("DurationInput"));
            IWebElement yearIn = _driver.FindElement(By.Id("YearInput"));
            IWebElement addButton = _driver.FindElement(By.Id("AddButton"));
            IWebElement deleteIn = _driver.FindElement(By.Id("DeleteInput"));
            IWebElement deleteButton = wait.Until(d => d.FindElement(By.Id("DeleteButton")));


            titleIn.SendKeys("TestTitle2");
            artistIn.SendKeys("TestArtist2");
            durationIn.SendKeys("5");
            yearIn.SendKeys("1990");
            addButton.Submit();
            IWebElement addMessage = wait.Until(d => d.FindElement(By.Id("AddMessage")));
            Assert.IsTrue(addMessage.Text.Contains("200"));


            deleteIn.SendKeys("18");
            deleteButton.Submit();
            IWebElement deleteMessage = wait.Until(d => d.FindElement(By.Id("DeleteMessage")));
            Assert.IsTrue(deleteMessage.Text.Contains("200"));
        }

        [TestCleanup]
        public void EdgeDriverCleanup()
        {
            _driver.Quit();
        }
    }
}
