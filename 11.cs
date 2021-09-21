using System;
using System.Reflection;
using System.Threading;
class ThreadInfo
{
    static void Main()
    {
        Thread t = Thread.CurrentThread;
        t.Name = "MAIN THREAD";
        foreach (PropertyInfo p in t.GetType().GetProperties())
        {
            Console.WriteLine("{0}:{1}",
                p.Name, p.GetValue(t, null));
        }

    }
}
