using OpenQA.Selenium;

namespace SurveyWebUIAuto
{
    class SurveyPage_NoTGWItems
    {
        public bool TMS_NoTGW(IWebDriver driver)
        {
            IWebElement CheckBoxNo = driver.FindElement(By.ClassName("checkBoxLabel unselectable CheckBoxLabel_Color"));
            if (CheckBoxNo.GetAttribute("text").Equals("I have not experienced any usability issues"))
            { return true;
            }
        }
    }
}
