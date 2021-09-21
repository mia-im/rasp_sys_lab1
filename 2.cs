using System;
using System.Threading;

namespace progr2
{
    class Program
    {
        static void LocalWorkItem()
        {
            Console.WriteLine("Hello from static method");
        }
        static void Main()
        {
            Thread thr1 = new Thread(LocalWorkItem);
            thr1.Start();

            Thread thr2 = new Thread(() =>
            {
                Console.WriteLine("Hello from lambda - expression");
            });
            thr2.Start();

            ThreadClass thrClass = new ThreadClass("Hello from thread-class");
            Thread thr3 = new Thread(thrClass.Run);
            thr3.Start();
        }
    }
    class ThreadClass
    {
        private string greeting;
        public ThreadClass(string sGreeting)
        {
            greeting = sGreeting;
        }
        public void Run()
        {
            Console.WriteLine(greeting);
        }
    }

}

