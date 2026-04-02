using System;
using System.IO;
using System.IO.Pipes;

namespace NamedPipeStreamClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var s = new NamedPipeClientStream("Message_pipe"))
            {
                Console.WriteLine("Ожидание сервера...");
                s.Connect();
                Console.Clear();
                StreamReader sr = new StreamReader(s);
                StreamWriter sw = new StreamWriter(s);
                Console.WriteLine("Напишите сообщение. Напишите \"СТОП\" для выхода.");
                string msg = Console.ReadLine();
                bool flag = false;
                while (msg.ToLower() != "стоп")
                {
                    if (!flag)
                    {
                        sw.WriteLine(msg);
                        sw.Flush();
                        flag = true;
                    }
                    else
                    {
                        msg = sr.ReadLine();
                        Console.WriteLine("> " + msg);
                        Console.WriteLine("Напишите сообщение.");
                        msg = Console.ReadLine();
                        flag = false;
                    }
                }
                sw.WriteLine("СТОП");
                sw.Flush();
                sw.Close();
                sr.Close();
                s.Close();
            }
            Console.WriteLine("Сеанс клиента закончен");
            Console.ReadLine();
        }
    }
}
