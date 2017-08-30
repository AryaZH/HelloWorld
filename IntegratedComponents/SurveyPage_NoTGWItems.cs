using System;
using OpenQA.Selenium;

namespace SurveyWebUIAuto
{
    public class SurveyPage_NoTGWItems
    {
        public static IWebDriver dr;
        public static bool NoTGW_CheckBox(IWebElement CB)
        {
            string text = dr.FindElement(By.ClassName("checkBoxLabel unselectable CheckBoxLabel_Color")).Text;
            bool flag = false;
            switch(text)
            {
                case "I have not experienced any usability issues":
                    flag = true;
                    break;
                case "No Concern":
                    flag = true;
                    break;
                default:
                    return false;
            }

            return flag;
        }
    }
}
