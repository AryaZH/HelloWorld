using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;


namespace SeleniumElementsOperate
{
    class Program
    {
        static void Main(string[] args)
        {       
            
           // Task1_RadioButton.RadioButtonSelect("http://enprecis.net/mascomp/GenSurvey.aspx?guid=N8d3IJvxW%2fE%3d");

            Task2_CheckBox.CheckBoxSelect("http://enprecis.net/mascomp/GenSurvey.aspx?guid=h4NynjQoCxk%3d");

            //Task4_SelectList.DropDowList("http://enprecis.net/mascomp/GenSurvey.aspx?guid=KvEVqorJCh4%3d");


        }
    }
}
