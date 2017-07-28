using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public static void getCheckBoxes()
        {
            ReadOnlyCollection<IWebElement> CBlist = DR.FindElements(By.XPath("//div[@class='checkBoxWithLabels']/div"));

            foreach (IWebElement CB in CBlist)
            {
                if (!CB.FindElement(By.TagName("input")).GetAttribute("value").Equals("checked")
                && !CB.FindElement(By.XPath("//div[@class='checkBoxWithLabels']/div/div/span")).Text.Equals("No Concerns"))
                {
                    CB.FindElement(By.CssSelector(".checkBoxLabel.unselectable.CheckBoxLabel_Color")).Click();
                }
            }
        }
    }
}
