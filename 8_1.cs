using System;
using System.Threading;

namespace progr8_1
{
    class Program
    {
        static void ThreadFunc(object o)
        {
            for (int i = 0; i < 20; i++)
            {
                Console.Write(o);
                Thread.Sleep(0);
            }
        }

        static void Main()
        {
            Thread[] t = new Thread[4];
            for (int i = 0; i < 4; i++)
                t[i] = new Thread(ThreadFunc);

            t[0].Start("A");
            t[1].Start("B");
            t[2].Start("C");
            t[3].Start("D");

            for (int i = 0; i < 4; i++)
                t[i].Join();
        }

    }
}

