using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

namespace SurveyWebUIAuto
{
    class SurveyBussiness_Flow
    {
        public SurveyBussiness_Flow()
        { }

        public SurveyBussiness_Flow(IWebDriver dr)
        { }

        public void WalkSurvey(IWebDriver dr, string SurveyLink, List<string> CList)
        {
            dr = new ChromeDriver();
            dr.Navigate().GoToUrl(SurveyLink);
            RunAllPages(dr,CList);
            dr.Quit();
        }

        public void RunAllPages(IWebDriver dr, List<string> CList)
        {
            try
            {
                bool hasNext = dr.FindElement(By.Name("btnNext")).Displayed;
                while (hasNext)
                {
                    System.Threading.Thread.Sleep(1000);
                    hasNext = EachPage(dr, CList);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public bool EachPage(IWebDriver dr, List<string> C1_List)
        {
            SurveyPage_TGWItems PItem = new SurveyPage_TGWItems();

            PItem.getRadioButtons(dr);

            PItem.SelectList(dr);

            if (dr.Title.Equals("Vehicle Concerns / Things Gone Wrong"))
            {
                PItem.getTargetCheckBoxes(dr, C1_List);
                }
            else { PItem.getCheckBoxes(dr);
            }

            PItem.Single_TextBox(dr);

            PItem.Muti_TextBox(dr);

            PItem.Scales(dr);

            while (dr.FindElements(By.Name("btnNext")).Count > 0)
            {
                dr.FindElement(By.Name("btnNext")).Click();
                return true;
            }
            return false;
        }
    }
}