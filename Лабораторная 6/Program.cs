using System;
using System.Threading;
using Microsoft.Office.Interop.Excel;

namespace lr6
{
    internal class Program
    {
        public static void ReadSheet(Workbook wb, int sheetIndex, bool randomizeDelay)
        {
            Worksheet ws = null;
            try
            {
                ws = wb.Sheets[sheetIndex];
            }
            catch
            {
                Console.WriteLine($"Лист {sheetIndex} не найден.");
                return;
            }
            Range range = ws.UsedRange;
            int x = range.Rows.Count;
            int y = range.Columns.Count;
            string output = "";

            if (!randomizeDelay)
            {
                for (int i = 1; i <= x; i++)
                {
                    for (int j = 1; j <= y; j++)
                    {
                        Thread.Sleep(100);
                        output += range.Cells[i, j].Value + "\t";
                        Console.WriteLine($"Считано значение ячейки ({i}, {j}) листа {sheetIndex}.");
                    }
                    output += "\n";
                }
            }
            else
            {
                Random r = new Random();
                int delay = r.Next(10, 400);
                for (int i = 1; i <= x; i++)
                {
                    for (int j = 1; j <= y; j++)
                    {
                        Thread.Sleep(delay);
                        output += range.Cells[i, j].Value + "\t";
                        Console.WriteLine($"Считано значение ячейки ({i}, {j}) листа {sheetIndex}.");
                        delay = r.Next(10, 400);
                    }
                    output += "\n";
                }
            }

            Console.WriteLine($"Лист {sheetIndex}:\n" + output + "\n");
            return;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите имя файла Excel для открытия");
            string fileName = Console.ReadLine().Trim().Replace("\"", "");
            Application excelApp = new Application();
            if (excelApp == null)
            {
                Console.WriteLine("Excel not installed/Ыксель не установлен");
                return;
            }
            Workbook workBook;
            try
            {
                workBook = excelApp.Workbooks.Open(fileName);
            }
            catch
            {
                Console.WriteLine("Файл не найден");
                return;
            }
            Thread thread1 = new Thread(() => ReadSheet(workBook, 1, false)) ;
            Thread thread2 = new Thread(() => ReadSheet(workBook, 2, true)) ;

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            excelApp.Quit();

            Console.ReadKey();
        }
    }
}
