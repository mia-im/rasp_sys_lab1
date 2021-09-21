using System;
using System.Threading;

namespace progr7
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                int i_copy = i;
                Thread t = new Thread(() =>
                    Console.Write("ABCDEFGHIJK"[i_copy]));
                t.Start();
            }

        }
    }
}
