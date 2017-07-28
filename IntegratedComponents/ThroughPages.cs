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
            baseURL = "http://vmchnqafull01/chrysler/GenSurvey.aspx?guid=UJ6%2bk2G%2fz3yU0D2Do%2b4Gtg%3d%3d";
            DR.Navigate().GoToUrl(baseURL);

            getCheckBoxes();
        }
        [TestMethod]

        public static void getCheckBoxes()
        {
            ReadOnlyCollection<IWebElement> CBlist = DR.FindElements(By.XPath("//div[@class='checkBoxWithLabels']/div"));

            foreach (IWebElement CB in CBlist)
            {
                if (!CB.FindElement(By.TagName("input")).GetAttribute("value").Equals("checked")
                && !CB.FindElement(By.XPath("//div[@class='checkBoxWithLabels']/div/div/span")).Text.Equals("No Concerns"))
                {
                    CB.FindElement(By.CssSelector(".checkBoxLabel.unselectable.CheckBoxLabel_Color")).Click();
                }
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
