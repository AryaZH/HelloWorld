using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyWebAuto
{
    class 几种注释方式
    {


        /// <summary>
        /// 类说明
        /// </summary>
        class Task2_CheckBox
        {
            /// <summary>
            /// 属性说明
            /// </summary>
            public int NodesCount { get; private set; }
            /// <summary>
            /// 方法说明
            /// </summary>
            /// <param name="a">参数说明</param>
            /// <param name="b">参数说明</param>
            /// <returns>返回值说明</returns>
            public static int explain(int a, int b)
            {
                return a + b;
                //单行注释
            }

            /* test 多行注释
             * test
             * test
             * test
             * test*/

     
        }
    }
}
