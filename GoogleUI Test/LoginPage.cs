using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Security.AccessControl;
using System.Threading;

namespace GoogleUI_Test
{
    [TestClass]
    public class LoginPage
    {
        IWebDriver webdriver = new ChromeDriver();
        
        [TestMethod]
        public void ToVerifyAdactinLoginPage()
        {
            
            webdriver.Manage().Window.Maximize();
            webdriver.Navigate().GoToUrl("http://adactinhotelapp.com/");
            Thread.Sleep(4000);
            string data = webdriver.FindElement(By.XPath("//a[contains(text(),'New User Register Here')]")).Text;
            Assert.AreEqual(data, "New User Register Here", "Both data did not Match.");
            webdriver.Close();
        }
        [TestMethod]
        public void ToVerifyTheLoginPageWithCredential()
        {
            Actions action = new Actions(webdriver);
            webdriver.Manage().Window.Maximize();
            webdriver.Navigate().GoToUrl("http://adactinhotelapp.com/");
            Thread.Sleep(2000);
            IWebElement ele= webdriver.FindElement(By.XPath("//input[@id='username']"));
            IWebElement ele1 = webdriver.FindElement(By.XPath("//input[@id='password']"));
            Thread.Sleep(3000);
            action.SendKeys(ele,"shashibhushan").Build().Perform();
            action.SendKeys(ele1,"shashibhushan").Build().Perform();
            Thread.Sleep(5000);
            IWebElement eleclick= webdriver.FindElement(By.XPath("//input[@id='login']"));
            action.Click(eleclick).Build().Perform();
            webdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            var data = webdriver.FindElement(By.XPath("//td[@class='welcome_menu']")).Text;
            Assert.AreEqual(data, "Welcome to Adactin Group of Hotels", "Both data did not Match.");
            webdriver.Close();
        }
        [TestMethod]
        public void ToVerifyTheSearchHotel()
        {
            Actions action = new Actions(webdriver);
            webdriver.Manage().Window.Maximize();
            webdriver.Navigate().GoToUrl("http://adactinhotelapp.com/");
            Thread.Sleep(2000);
            IWebElement ele= webdriver.FindElement(By.XPath("//input[@id='username']"));
            IWebElement ele1 = webdriver.FindElement(By.XPath("//input[@id='password']"));
            action.SendKeys(ele, "shashibhushan").Build().Perform();
            action.SendKeys(ele1, "shashibhushan").Build().Perform();
            Thread.Sleep(5000);
            IWebElement eleclick= webdriver.FindElement(By.XPath("//input[@id='login']"));
            action.Click(eleclick).Build().Perform();
            var data = webdriver.FindElement(By.XPath("//td[@class='welcome_menu']")).Text;
            Assert.AreEqual(data, "Welcome to Adactin Group of Hotels", "Both data did not Match.");
            SelectElement drop = new SelectElement(webdriver.FindElement(By.Id("location")));
            drop.SelectByValue("London");
            Thread.Sleep(3000);
            IWebElement submit= webdriver.FindElement(By.XPath("//*[@id='Submit']"));
            action.Click(submit).Build().Perform();
            Thread.Sleep(3000);
            var HotelData = webdriver.FindElement(By.XPath("//td[@class='login_title']")).Text;
            Assert.AreEqual(HotelData, "Select Hotel", "Both data did not Match.");
            webdriver.Close();

        }
    }
}
