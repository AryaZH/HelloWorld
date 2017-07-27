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
    public static class Task2_CheckBox
    {
        public static IWebDriver driver;

        public static void CheckBoxSelect(string URL)
        {

            driver = new ChromeDriver();
        //    driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(URL);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            //跳过welcome到首页的TGW
          
                //Second Skip required DropDownList

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


                    //first Skip required question RadioButton
                    ReadOnlyCollection<IWebElement> RadioButtonSelected = driver.FindElements(By.XPath("//div[contains(@class,'customRadioButtonsList')]/div[last()-1]/span"));

                    int RadioButtonCount = RadioButtonSelected.Count();
                    if (RadioButtonCount > 0)
                    {
                        foreach (IWebElement Rb in RadioButtonSelected)
                        {
                            Rb.Click();
                            Console.WriteLine(Rb.Text);
                        }


                //Click the next button
                  
                    IWebElement BtNext =  driver.FindElement(By.XPath("//div[@class='bottomButtons']/input"));
                    BtNext.Click();


               //Click the checkBOX
                    ReadOnlyCollection<IWebElement> CheckBoxesList = driver.FindElements(By.XPath("//div[@class='checkBoxWithLabels']/div/span[position() mod 2 = 1]"));
                    ////div[@class='checkBoxWithLabels']/div//span[position() mod 2 = 1] --- BOX + Categoryname

                    int CheckBoxCount = CheckBoxesList.Count();
                    if (CheckBoxCount > 0)
                    {
                        foreach (IWebElement Cb in CheckBoxesList)
                        {
                            if (Cb.Text == "Other" || Cb.Text == "Concern")
                                continue;
                            Cb.Click();
                            //Console.WriteLine(Cb.Text);
                        }
                    }

                    //driver.Quit();

                    //找到整个页面的checkbox,全部勾选
                    //其中有含Commentbox的


             }

            }
        }
    }
}