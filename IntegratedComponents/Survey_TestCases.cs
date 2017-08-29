using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

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
            SurveyBussiness_Flow SBus = new SurveyBussiness_Flow();
            SBus.WalkSurvey(DR, "http://localhost/tms/GenSurvey.aspx?guid=4FUpOgyOig4%3d");
        }
    }
}
