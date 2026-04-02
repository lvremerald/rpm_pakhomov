using System;
using System.IO;
using System.IO.Pipes;

namespace NamedPipeStream
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var s = new NamedPipeServerStream("Message_pipe"))
                {
                    Console.WriteLine("Ожидание клиента...");
                    s.WaitForConnection();
                    Console.Clear();
                    Console.WriteLine("Ожидание сообщения от клиента");
                    StreamReader sr = new StreamReader(s);
                    StreamWriter sw = new StreamWriter(s);
                    string msg = sr.ReadLine();
                    while (msg.ToLower() != "стоп")
                    {
                        Console.WriteLine("> " + msg);
                        string buf = "";
                        foreach (char c in msg)
                        {
                            buf += Convert.ToInt32(c).ToString() + " ";
                        }
                        msg = buf;
                        sw.WriteLine(msg);
                        sw.Flush();
                        Console.WriteLine(msg);
                        Console.WriteLine("Ожидание сообщения от клиента");
                        msg = sr.ReadLine();
                    }
                    sw.Close();
                    sr.Close();
                    s.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Сеанс сервера закончен");
            Console.ReadLine();
        }
    }
}
