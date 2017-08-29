using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SurveyWebUIAuto
{
    class SurveyPage_TGWItems
    {
        //Checkbox 
        public void getCheckBoxes(IWebDriver DR)
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

        //Radio button 
        public void getRadioButtons(IWebDriver DR)
        {
            ReadOnlyCollection<IWebElement> RadioButtonsC = DR.FindElements(By.XPath("//div[contains(@class,'customRadioButtonsList')]/div[last()-1]/span"));
            foreach (IWebElement RadioButton in RadioButtonsC)
            {
                RadioButton.Click();
            }
        }

        //single line text
        public void Single_TextBox(IWebDriver DR)
        {
            ReadOnlyCollection<IWebElement> SingleTextList = DR.FindElements(By.XPath("//div[@class='singleLineTextBox']/input"));
            foreach (IWebElement St in SingleTextList)
            {
                St.SendKeys("Single Testing");
            }
        }

        //Mutis line text
        public void Muti_TextBox(IWebDriver DR)
        {
            ReadOnlyCollection<IWebElement> MutiTextList = DR.FindElements(By.ClassName("multilineTextBox"));

            foreach (IWebElement St in MutiTextList)
            {
                St.SendKeys("Muti Text Testing");
            }
        }

        //select list
        public void SelectList(IWebDriver DR)
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

        //scale roll

        public void Scales(IWebDriver DR)
        {
            ReadOnlyCollection<IWebElement> ScaleList = DR.FindElements(By.XPath("//div[contains(@class,'slider')]/div[contains(@class,'ticks')]"));

            foreach (IWebElement St in ScaleList)
            {
                St.Click();
            }
        }

    }
}
