using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
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
            webdriver.Manage().Window.Maximize();
            webdriver.Navigate().GoToUrl("http://adactinhotelapp.com/");
            Thread.Sleep(2000);
            webdriver.FindElement(By.XPath("//input[@id='username']")).SendKeys("shashibhushan");
            webdriver.FindElement(By.XPath("//input[@id='password']")).SendKeys("shashibhushan");
            Thread.Sleep(5000);
            webdriver.FindElement(By.XPath("//input[@id='login']")).Click();
            var data = webdriver.FindElement(By.XPath("//td[@class='welcome_menu']")).Text;
            Assert.AreEqual(data, "Welcome to Adactin Group of Hotels", "Both data did not Match.");
            webdriver.Close();
        }
    }
}
