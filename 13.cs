using System;
using System.Threading;

namespace progr13
{
    class PriorityTesting
    {
        static long[] counts;
        static bool finish;
        static void ThreadFunc(object iThread)
        {
            while (true)
            {
                if (finish)
                    break;
                counts[(int)iThread]++;
            }
        }
        static void Main()
        {
            counts = new long[5];
            Thread[] t = new Thread[5];
            for (int i = 0; i < t.Length; i++)
            {
                t[i] = new Thread(ThreadFunc);
                t[i].Priority = (ThreadPriority)i;
            }
            // Запускаем потоки 
            for (int i = 0; i < t.Length; i++)
                t[i].Start(i);

            // Даём потокам возможность поработать 10 c 
            Thread.Sleep(10000);

            // Сигнал о завершении 
            finish = true;

            // Ожидаем завершения всех потоков 
            for (int i = 0; i < t.Length; i++)
                t[i].Join();
            // Вывод результатов 
            for (int i = 0; i < t.Length; i++)
                Console.WriteLine("Thread with priority {0}, Counts: {1}", (ThreadPriority)i, counts[i]);
        }
    }

}
