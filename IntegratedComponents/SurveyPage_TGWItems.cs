using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace SurveyWebUIAuto
{
    class SurveyPage_TGWItems
    {
        /// <summary>
        /// Select all unchecked CheckBox 
        /// </summary>
        /// <param name="DR">Web driver</param>
        public void getCheckBoxes(IWebDriver DR)
        {
            ReadOnlyCollection<IWebElement> CBlist = DR.FindElements(By.XPath("//div[@class='checkBoxWithLabels']/div"));

            foreach (IWebElement CB in CBlist)
            {
                if (CB.FindElement(By.TagName("input")).GetAttribute("value").Equals("checked"))
                    continue;

                IWebElement CategoryLevel1 = CB.FindElement(By.CssSelector(".checkBoxLabel.unselectable.CheckBoxLabel_Color"));
                string SurveyDisplayText = CategoryLevel1.Text;
                switch (SurveyDisplayText)
                {
                    //Skip NoTGW items 
                    case "No Concerns":
                    case "I have not experienced any usability issues":
                        break;
                    default:
                        CategoryLevel1.Click();
                        break;
                }

            }
        }

        /// <summary>
        /// Select target unchecked CheckBox , Filter CategoryLevel1
        /// </summary>
        /// <param name="DR">Web driver</param>
        /// <param name="CategoryLevel1List">CategoryLevelList</param>
        public void getTargetCheckBoxes(IWebDriver DR, List<string> CategoryLevel1List)
        {
            ReadOnlyCollection<IWebElement> CBlist = DR.FindElements(By.XPath("//div[@class='checkBoxWithLabels']/div"));

            foreach (string C1 in CategoryLevel1List)
            {
                foreach (IWebElement CB in CBlist)
                {
                    IWebElement CategoryLevel1 = CB.FindElement(By.CssSelector(".checkBoxLabel.unselectable.CheckBoxLabel_Color"));
                    string SurveyDisplayText = CategoryLevel1.Text;

                    if (SurveyDisplayText != C1)
                        continue;

                    if (CB.FindElement(By.TagName("input")).GetAttribute("value").Equals("checked"))
                        continue;

                    switch (SurveyDisplayText)
                    {
                        //Skip NoTGW items 
                        case "No Concerns":
                        case "I have not experienced any usability issues":
                            break;
                        default:
                            CategoryLevel1.Click();
                            break;
                    }
                }
            }
        }
   
        /// <summary>
        /// Radio button 
        /// </summary>
        /// <param name="DR"></param>
        public void getRadioButtons(IWebDriver DR)
        {
            ReadOnlyCollection<IWebElement> RadioButtonsC = DR.FindElements(By.XPath("//div[contains(@class,'customRadioButtonsList')]/div[last()-1]/span"));
            foreach (IWebElement RadioButton in RadioButtonsC)
            {
                RadioButton.Click();
            }
        }

        /// <summary>
        /// single line text
        /// </summary>
        /// <param name="DR"></param>
        public void Single_TextBox(IWebDriver DR)
        {
            ReadOnlyCollection<IWebElement> SingleTextList = DR.FindElements(By.XPath("//div[@class='singleLineTextBox']/input"));
            foreach (IWebElement St in SingleTextList)
            {
                St.SendKeys("Single Text Testing");
            }
        }
        /// <summary>
        /// 
        //Mutis line text
        /// </summary>
        /// <param name="DR"></param>
        public void Muti_TextBox(IWebDriver DR)
        {
            ReadOnlyCollection<IWebElement> MutiTextList = DR.FindElements(By.ClassName("multilineTextBox"));

            foreach (IWebElement St in MutiTextList)
            {
                St.SendKeys("Muti Text Testing");
            }
        }

        /// <summary>
        /// select list
        /// </summary>
        /// <param name="DR"></param>
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

        /// <summary>
        /// scale roll
        /// </summary>
        /// <param name="DR"></param>
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
