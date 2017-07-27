using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;

namespace SeleniumElementsOperate
{
   public static class Task1_RadioButton
    {
        public static void RadioButtonSelect(IWebDriver driver , string URL)
        {

            ReadOnlyCollection<IWebElement> RadioButtonSelected = driver.FindElements(By.XPath("//div[contains(@class,'customRadioButtonsList')]/div[last()-1]/span"));

            int RadioButtonCount = RadioButtonSelected.Count();
            if (RadioButtonCount > 0)
            {
                foreach (IWebElement Rb in RadioButtonSelected)
                {
                    Rb.Click();
                    //Console.WriteLine(Rb.Text);
                }
            }
        }

    }
}
