﻿using System;
using System.Threading;

namespace progr16
{
    public class ThreadWork
    {
        private string sharedWord;
        public void Run(string secretWord)
        {
            sharedWord = secretWord;
            Save(secretWord);
            Thread.Sleep(500);
            Show();
        }
        private void Save(string s)
        {
            // Получаем идентификатор слота по имени 
            LocalDataStoreSlot slot = Thread.GetNamedDataSlot("Secret");
            // Сохраняем данные 
            Thread.SetData(slot, s);
        }
        private void Show()
        {
            LocalDataStoreSlot slot =
              Thread.GetNamedDataSlot("Secret");
            string secretWord = (string)Thread.GetData(slot);
            Console.WriteLine("Thread {0}, secret word: {1},  shared word: {2}", Thread.CurrentThread.ManagedThreadId, secretWord, sharedWord);
        }
    }
    class Program
    {
        static void Main()
        {
            ThreadWork thr = new ThreadWork();
            new Thread(() => thr.Run("one")).Start();
            new Thread(() => thr.Run("two")).Start();
            new Thread(() => thr.Run("three")).Start();
            Thread.Sleep(1000);
        }
    }

}
