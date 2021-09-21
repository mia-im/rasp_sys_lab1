using System;
using System.Threading;

namespace progr14
{
    public class Data
    {
        public static int sharedVar;
        [ThreadStatic] public static int localVar;
    }
    class Program
    {
        static void threadFunc(object i)
        {
            Console.WriteLine("Thread {0}: Before changing.. Shared: {1}, local: {2}", i, Data.sharedVar, Data.localVar);
            Data.sharedVar = (int)i;
            Data.localVar = (int)i;
            Console.WriteLine("Thread {0}: After changing..  Shared: {1}, local: {2}", i, Data.sharedVar, Data.localVar);
        }
        static void Main()
        {
            Thread t1 = new Thread(threadFunc);
            Thread t2 = new Thread(threadFunc);

            Data.sharedVar = 3;
            Data.localVar = 3;

            t1.Start(1);
            t2.Start(2);

            t1.Join();
            t2.Join();
        }

    }

}

