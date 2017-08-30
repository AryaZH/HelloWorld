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
            SBus.WalkSurvey(DR, "http://localhost/TMS/GenSurvey.aspx?guid=h%2fGLzUzjS5U%3d");
        }
    }
}
