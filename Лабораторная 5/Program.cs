using System;
using System.IO;
using System.Net;
using Microsoft.Office.Interop.Excel;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName = "";
            Console.WriteLine("Введите путь для сохранения .xls файла");
            char[] trimChars = new char[] { ' ', '"' };
            fileName = Console.ReadLine().Trim(trimChars);

            if (File.Exists(fileName))
            {
                Console.WriteLine("Файл {fileName} уже существует. Пропуск скачивания.\n");
            }
            else
            {
                WebClient client = new WebClient();

                try
                {
                    client.DownloadFile("https://download.samplelib.com/xls/sample-simple-1.xls", fileName);
                }
                catch
                {
                    Console.WriteLine("Не удалось скачать файл.");
                    Console.ReadKey();
                    return;
                }
            }

            Application excelApp = new Application();

            if (excelApp == null)
            {
                Console.WriteLine("Excel not installed.");
                Console.ReadKey();
                return;
            }

            Workbook excelBook;
            try
            {
                excelBook = excelApp.Workbooks.Open(fileName, 0, true);
            }
            catch
            {
                Console.WriteLine($"Файл {fileName} не найден.");
                Console.ReadKey();
                return;
            }

            Worksheet excelSheet = excelBook.Sheets[1];
            Range excelRange = excelSheet.UsedRange;

            for (int i = 1; i <= excelRange.Rows.Count; i++)
            {
                for (int j = 1; j <= excelRange.Columns.Count; j++)
                {
                    Console.Write(excelRange.Cells[i, j].Value.ToString() + "\t");
                }
                Console.Write("\n");
            }

            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

            Console.WriteLine("\n\nНажмите любую клавишу для завершения.");
            Console.ReadKey();

        }
    }
}
