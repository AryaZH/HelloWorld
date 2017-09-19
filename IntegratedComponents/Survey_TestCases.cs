using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using CampaignCreateCheck;

namespace SurveyWebUIAuto
{
    [TestClass]
    public class Survey_TestCases
    {
        private string baseURL;
        public IWebDriver DR;

        [TestMethod]
        public void TMSSurvey()
        {
            WholeSurvey_Flow SBus = new WholeSurvey_Flow();
            SBus.WalkSurvey(DR, "http://localhost/TMS/GenSurvey.aspx?guid=h%2fGLzUzjS5U%3d");
        }

        [TestMethod]

        public void DB()
        {
            Test a = new Test();
            a.Connect();
        }
    }
}
