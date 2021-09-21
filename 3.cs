using System;
using System.Threading;

namespace progr3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Создаем объекта потока
            Thread thread = new Thread(ThreadFunction);
            //Запускаем поток
            thread.Start();
            //Просто выводим 3 раза на экран заданный текст
            int count = 3;
            while (count > 0)
            {
                Console.WriteLine("Это главный поток программы!");
                --count;
            }
            //Ждем ввода от пользователя, что бы окно консоли не закрылось автоматически
            Console.Read();
        }
        static void ThreadFunction()
        {
            //Аналогично главному потоку выводим три раза текст
            int count = 3;
            while (count > 0)
            {
                Console.WriteLine("Это дочерний поток программы!");
                --count;
            }
        }
    }
}

