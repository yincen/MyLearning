using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThread
{
    class ProgramDelegate
    {
        public delegate string MyDelegate(object data);

        static void Main(string[] args)
        {
            MyDelegate mydelegate = TestMethod;
            IAsyncResult result = mydelegate.BeginInvoke("Thread Param", TestCallback, "Callback Param");

            //异步执行完成
            string resultstr = mydelegate.EndInvoke(result);
            Console.WriteLine("Result str = " + resultstr);
            Console.ReadKey();
        }

        //线程函数
        public static string TestMethod(object data)
        {
            string datastr = data as string;
            return datastr;
        }

        //异步回调函数
        public static void TestCallback(IAsyncResult data)
        {
            Console.WriteLine(data.AsyncState);
        }
    }
}