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
       public static IWebDriver driver;

        public static void RadioButtonSelect(string URL)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(URL);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

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

            driver.Quit();

            //找到整个页面的Radiobutton,当前设置选取倒数第二个选项
            //考虑设置为随机选中一个
        }

    }
}
