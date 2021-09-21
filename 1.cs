using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading;
namespace progr
{
    public class MyThread
    {
        public void ThreadNumbers()
        {
            // Информация о потоке
            Console.WriteLine("{0} поток использует метод ThreadNumbers", Thread.CurrentThread.Name);
            // Выводим числа
            Console.Write("Числа: ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(i + ", ");
                // Используем задержку
                Thread.Sleep(3000);
            }
            Console.WriteLine();
        }
    }

    class Program
    {


        static void Main()
        {
            Console.Write("Сколько использовать потоков (1 или 2)?");
            string number = Console.ReadLine();

            Thread mythread = Thread.CurrentThread;
            mythread.Name = "Первичный";

            // Выводим информацию о потоке
            Console.WriteLine("--> {0} главный поток", Thread.CurrentThread.Name);
            MyThread mt = new MyThread();

            switch (number)
            {
                case "1":
                    mt.ThreadNumbers();
                    break;
                case "2":
                    // Создаем поток
                    Thread backgroundThread = new Thread(new ThreadStart(mt.ThreadNumbers));
                    backgroundThread.Name = "Вторичный";
                    backgroundThread.Start();
                    // используем 1-й поток
                    mt.ThreadNumbers();
                    break;
                default:
                    Console.WriteLine("использую 1 поток");
                    goto case "1";
            }
            Console.ReadLine();
        }
    }
}