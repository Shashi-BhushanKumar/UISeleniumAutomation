using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium.Interactions;
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
            Thread.Sleep(3000);
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
            IWebElement userName= webdriver.FindElement(By.XPath("//input[@id='username']"));
            IWebElement password= webdriver.FindElement(By.XPath("//input[@id='password']"));
            Thread.Sleep(5000);
            action.SendKeys(userName, "shashibhushan");
            action.SendKeys(password, "shashibhushan");
              IWebElement ele=webdriver.FindElement(By.XPath("//input[@id='login']"));
            action.Click(ele).Build().Perform(); 
            var data = webdriver.FindElement(By.XPath("//td[@class='welcome_menu']")).Text;
            Assert.AreEqual(data, "Welcome to Adactin Group of Hotels", "Both data did not Match.");
            webdriver.Close();
        }

        [TestMethod]
        public void ToVerifyNoSuchElementException()
        {

            try
            {
                Actions action = new Actions(webdriver);
                webdriver.Manage().Window.Maximize();
                webdriver.Navigate().GoToUrl("http://adactinhotelapp.com/");
                Thread.Sleep(2000);
                IWebElement username = webdriver.FindElement(By.XPath("//input[@id='username']"));
                IWebElement password = webdriver.FindElement(By.XPath("//input[@id='password']"));
                action.SendKeys("shashibhushan");
                action.SendKeys("shashibhushan");
                IWebElement ele1= webdriver.FindElement(By.XPath("//input[@id='login']"));
                webdriver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(5);
                SelectElement ele=new SelectElement(webdriver.FindElement(By.XPath("//*[@id='location']")));
                ele.SelectByValue("Sydney");
                var data = webdriver.FindElement(By.XPath("//td[@class='welcome_menu']")).Text;
                Assert.AreEqual(data, "Welcome to Adactin Group of Hotels", "Both data did not Match.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
           


            webdriver.Close();
        }
        [TestMethod]
        public void ToVerifyAmazonOnePlus()
        {
            webdriver.Navigate().GoToUrl("https://www.amazon.in/");
            Thread.Sleep(3000);
            webdriver.FindElement(By.XPath("//div[@id='nav-xshop']//a[5]")).Click();
            webdriver.FindElement(By.XPath("//input[@type='checkbox']//following::span[11]")).Click();
            List<string> ele = new List<string>();
             List<IWebElement> s = webdriver.FindElements(By.XPath("//span[@class='a-size-base-plus a-color-base a-text-normal']")).ToList();

            string first = s[0].Text;
            string second = s[1].Text;
            Assert.IsTrue(s[0].Text.Contains("OnePlus"));
            Assert.IsTrue(first.Contains("OnePlus"));
            Assert.IsTrue(second.Contains("OnePlus"));

            webdriver.Close();
        }
    }
}
