using System;
using System.Threading;

namespace progr12
{

    class Program
    {
        static void Main()
        {
            Console.Title = "Информация о главном потоке программы";
            Thread thread = Thread.CurrentThread;
            thread.Name = "MyThread";
            Console.WriteLine(@"Имя домена приложения: {0}
            ID контекста: {1}
            Имя потока: {2}
            Запущен ли поток? {3}
            Приоритет потока: {4}
            Состояние потока: {5}",
            Thread.GetDomain().FriendlyName, Thread.CurrentThread.ManagedThreadId, thread.Name, thread.IsAlive, thread.Priority, thread.ThreadState);
            Console.ReadLine();
        }
    }
}
