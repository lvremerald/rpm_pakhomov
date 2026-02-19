using System;
using System.Diagnostics;

namespace lr4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Получение информации о запущенных процессах...");
            // Получение информации о запущенных процессах
            foreach (Process p in Process.GetProcesses())
            {
                Console.WriteLine($"ID: {p.Id}, название: {p.ProcessName}");
            }
            Console.WriteLine("Нажмите любую клавишу для продолжения.");
            Console.ReadKey();

            Console.WriteLine("Получение информации о процессах Visual Studio...");
            // Получение информации о процессах Visual Studio
            Process proc = Process.GetProcessesByName("devenv")[0];
            ProcessThreadCollection threads = proc.Threads;
            foreach (ProcessThread thread in threads)
            {
                Console.WriteLine($"ID: {thread.Id}");
            }
            Console.WriteLine("Нажмите любую клавишу для продолжения.");
            Console.ReadKey();
            
            Console.WriteLine("Запуск сторонних процессов...");
            // Запуск сторонних процессов
            Process.Start(@"chrome.exe", "https://learn.microsoft.com/ru-ru/dotnet/api/system.diagnostics.process?view=net-8.0");
            Process.Start("cmd.exe");
            Process.Start("mspaint.exe");
        }
    }
}
