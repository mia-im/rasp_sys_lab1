using System;
using System.Threading;

namespace progr5
{
    class Program
    {
        static long Factorial(long n)
        {
            long res = 1;
            do
            {
                res = res * n;
            } while (--n > 0);
            return res;
        }
        static void Main()
        {
            long res1 = 0;
            long res2 = 0;
            long n1 = 25, n2 = 10;
            Thread t1 = new Thread(() => { res1 = Factorial(n1); });
            Thread t2 = new Thread(() => { res2 = Factorial(n2); });
            // Запускаем потоки 
            t1.Start();
            t2.Start();
            // Ожидаем завершения потоков 
            t1.Join(); t2.Join();
            Console.WriteLine("Factorial of {0} equals {1}", n1, res1);
            Console.WriteLine("Factorial of {0} equals {1}", n2, res2);
        }
    }
}
