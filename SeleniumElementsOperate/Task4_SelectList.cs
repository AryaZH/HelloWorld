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
using OpenQA.Selenium.Support.UI;

namespace SeleniumElementsOperate
{
    public static class Task4_SelectList
    {
        public static IWebDriver driver;

        public static void DropDowList(string URL)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(URL);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            ReadOnlyCollection<IWebElement> DropDownList = driver.FindElements(By.XPath("//select"));

            int DropdownCount = DropDownList.Count();
            if (DropdownCount > 0)
            {
                foreach (IWebElement Dd in DropDownList)
                {
                    SelectElement SE = new SelectElement(Dd);
                    SE.SelectByIndex(4);
                    //Console.WriteLine(SE.Options);
                }
            }

        }
    }
}