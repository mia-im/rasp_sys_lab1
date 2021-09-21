using System;
using System.Threading;

namespace progr6
{
    class Program
    {

        static double res;

        static void ThreadWork(object state)
        {
            string sTitle = ((object[])state)[0] as string;
            double d = (double)(((object[])state)[1]);
            Console.WriteLine(sTitle);
            res = SomeMathOperation(d);
        }

        private static double SomeMathOperation(double d)
        {
            return d;
        }

        static void Main()
        {
            Thread thr1 = new Thread(ThreadWork);
            thr1.Start(new object[] { "Thread #1", 3.14 });
            thr1.Join();
            Console.WriteLine("Result: {0}", res);

        }
    }
}

