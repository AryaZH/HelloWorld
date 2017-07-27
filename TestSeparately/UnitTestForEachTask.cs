using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumElementsOperate;
using System.Web;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;

namespace TestSeparately
{
    [TestClass]
    public class UnitTestForEachTask
    {
        public static IWebDriver driver;
        //public string SurveyURL;

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            Console.WriteLine("Initial webdriver we used to test");
        }

        [TestInitialize]
        public static void TestInit(string url)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
        }

        [TestMethod]
        public static void RadioButtonTest()
        {
            string SurveyURL = @"http://vmchnqafull01/chrysler/GenSurvey.aspx?guid=j5KjbURxd1CTDQoSQVQppg%3d%3d";
            TestInit(SurveyURL);
            radio = new Task1_RadioButton();

        }

        [TestMethod]
        public static void CheckBox()
        {

        }
        [TestMethod]
        public static void TextBox()
        {

        }
        [TestMethod]
        public static void SelectList()
        {

        }

        [TestCleanup]
        public static void TestClean()
        {

        }

        [ClassCleanup]
        public static void Clean()
        {

        }

    }
}