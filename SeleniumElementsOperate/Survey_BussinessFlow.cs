using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;


namespace SurveyWebAuto

{
    class Survey_BussinessFlow
    {
        public void WalkSurvey(IWebDriver dr , string SurveyLink)
        {
            dr = new ChromeDriver();
            dr.Navigate().GoToUrl(SurveyLink);

            RunAllPages(dr);
        }

        public void RunAllPages(IWebDriver dr)
        {
            try
            {
                bool hasNext = dr.FindElement(By.Name("btnNext")).Displayed;
                while (hasNext)
                {
                    System.Threading.Thread.Sleep(1000);
                    hasNext = EachPage(dr);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public bool EachPage(IWebDriver dr)
        {
            Survey_PageItems PItem = new Survey_PageItems();

            PItem.getRadioButtons();

            PItem.SelectList();

            PItem.getCheckBoxes();

            PItem.Single_TextBox();

            PItem.Muti_TextBox();

            PItem.Scales();

            while (dr.FindElements(By.Name("btnNext")).Count > 0)
            {
                dr.FindElement(By.Name("btnNext")).Click();
                return true;
            }
            return false;
        }

      
}