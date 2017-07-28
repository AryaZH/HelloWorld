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
            baseURL = "http://vmchnqafull01/chrysler/GenSurvey.aspx?guid=kTzHW1GDjmX4RF6O4HGvMA%3d%3d";
            DR.Navigate().GoToUrl(baseURL);

            RunAllPages();
        }

        public static void RunAllPages()
        {
            try
            {
                bool hasNext = DR.FindElement(By.Name("btnNext")).Displayed;
                while (hasNext)
                {
                    System.Threading.Thread.Sleep(1000);
                    hasNext = EachPage();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static bool EachPage()
        {
            getRadioButtons();

            SelectList();

            getCheckBoxes();

            Single_TextBox();

            Muti_TextBox();

            Scales();

            while (DR.FindElements(By.Name("btnNext")).Count > 0)
            {
                DR.FindElement(By.Name("btnNext")).Click();
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
            ReadOnlyCollection<IWebElement> CBlist = DR.FindElements(By.XPath("//div[@class='checkBoxWithLabels']/div"));

            foreach (IWebElement CB in CBlist)
            {
                if (!CB.FindElement(By.TagName("input")).GetAttribute("value").Equals("checked")
                && !CB.FindElement(By.CssSelector(".checkBoxLabel.unselectable.CheckBoxLabel_Color")).Text.Equals("No Concerns"))
                {
                    CB.FindElement(By.CssSelector(".checkBoxLabel.unselectable.CheckBoxLabel_Color")).Click();
                }   
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

        public static void Single_TextBox()
        {
            ReadOnlyCollection<IWebElement> SingleTextList = DR.FindElements(By.XPath("//div[@class='singleLineTextBox']/input"));
            foreach(IWebElement St in SingleTextList)
            {
                St.SendKeys("Single Testing");
            }
        }

        public static void Muti_TextBox()
        {
            ReadOnlyCollection<IWebElement> MutiTextList = DR.FindElements(By.ClassName("multilineTextBox"));

            foreach (IWebElement St in MutiTextList)
            {
                St.SendKeys("Muti Text Testing");
            }
        }

        public static void Scales()
        {
            ReadOnlyCollection<IWebElement> ScaleList = DR.FindElements(By.XPath("//div[contains(@class,'slider')]/div[contains(@class,'ticks')]"));

            foreach (IWebElement St in ScaleList)
            {
                St.Click();
            }
        }

    }
}