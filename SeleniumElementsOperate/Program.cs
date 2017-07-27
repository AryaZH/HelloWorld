using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;

namespace SeleniumElementsOperate

{
    class Program
    {

        
        private static string baseURL;
        public static IWebDriver DR;


        static void Main(string[] args)
        {
            DR = new ChromeDriver();
            baseURL = "http://vmchnqafull01/chrysler/GenSurvey.aspx?guid=4a%2f7E6M9nzEcbxv16toA7w%3d%3d";
            DR.Navigate().GoToUrl(baseURL);
            //DR.Manage().Window.Maximize();
            //DR.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));

            RunAllPages();
        }

        public static void RunAllPages()
        {
                // Get Next button
                bool hasNext = DR.FindElement(By.Name("btnNext")).Displayed;

                while (hasNext)
                {
                    System.Threading.Thread.Sleep(1000);
                    hasNext = FlowControl();
                }
        }

        public static bool FlowControl()
        {

            getRadioButtons();

            SelectList();

            getCheckBoxes();

            while (DR.FindElements(By.Name("btnNext")).Count > 0)
            {
                DR.FindElement(By.Name("btnNext")).Click();
                System.Threading.Thread.Sleep(1000);
                return true;
            }
            return false;
        }


        public static void getRadioButtons()
        {
            ReadOnlyCollection<IWebElement> RadioButtonsC = DR.FindElements(By.XPath("//div[contains(@class,'customRadioButtonsList')]/div[last()-1]/span"));
            foreach (IWebElement RadioButton in RadioButtonsC)
            {
                RadioButton.Click();
            }
        }

        public static void getCheckBoxes()
        {
            ReadOnlyCollection<IWebElement> getCheckBoxes = DR.FindElements(By.XPath("//div[@class='checkBoxWithLabels']/div/span[position() mod 2 = 1]"));
            foreach (IWebElement cb in getCheckBoxes)
            {
                cb.Click();
            }
        }

        public static void SelectList()
        {
            ReadOnlyCollection<IWebElement> SelectQuestions = DR.FindElements(By.XPath("//select[@class='dropdown-answer mobile cascading-text']"));
            foreach (IWebElement SelectQ in SelectQuestions)
            {
                SelectElement SE = new SelectElement(SelectQ);

                Random rd = new Random();
                int i = rd.Next(1, SE.AllSelectedOptions.Count);
                SE.SelectByIndex(i);
            }
        }

    }
}
