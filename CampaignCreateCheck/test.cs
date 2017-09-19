using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignCreateCheck
{

    //数据库连接
    public class Test
    {
        private SqlConnection myconnection;
        private string connStr;

        public  void Connect()

        {
            try
            {
                myconnection = new SqlConnection(connStr);

                myconnection.Open();     //打开数据库

                Console.WriteLine("数据库连接成功！");
            }
            catch (Exception ee)
            {
                Console.WriteLine("数据库连接失败！" + ee.ToString());
            }
        }
    }
}
