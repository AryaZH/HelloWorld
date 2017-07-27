using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Web;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using System.Threading;
using OpenQA.Selenium.Firefox;

namespace IntegratedComponents
{
    [TestClass]
    public class ThroughPages
    {
        private static string baseURL;
        public static IWebDriver DR;

        [TestInitialize]
        public static void Prepared()
        {
            DR = new FirefoxDriver();
            baseURL = "http://enprecis.net/chrysler/GenSurvey.aspx?guid=9iKbKlhYkHCzQc3Ls%2fovSw%3d%3d";
            DR.Navigate().GoToUrl(baseURL);
          //  DR.Manage().Window.Maximize();
            DR.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

        }
        [TestMethod]

        public static void getRadioButtons()
        {
            ReadOnlyCollection<IWebElement> RadioButtonsC = DR.FindElements(By.XPath("//div[contains(@class,'customRadioButtonsList')]/div[last()-1]/span"));
            foreach(IWebElement RadioButton in RadioButtonsC)
            {
                RadioButton.Click();
            }
        }

        [TestCleanup]
        public static void Quit()
        {
            Thread.Sleep(5);
            DR.Quit();
        }
    }
}
