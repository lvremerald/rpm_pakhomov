using System.Net;
using System.Net.Http.Json;

class Program
{
    static HttpClient httpClient = new HttpClient();
    static async Task Main()
    {
        List<string>? list1 = await httpClient.GetFromJsonAsync<List<string>>("https://localhost:7287/api/items");
        if (list1 != null)
        {
            foreach (var item in list1)
            {
                Console.WriteLine(item);
            }
        }
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine("Напишите новую строку, которая заменит 2-й элемент");
        Args obj = new Args();
        obj.id = 1;
        obj.str = Console.ReadLine();
        using var response = await httpClient.PutAsJsonAsync("https://localhost:7287/api/items", obj);
        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            Error? error = await response.Content.ReadFromJsonAsync<Error>();
            Console.WriteLine(error?.Message);
        }
        else if (response.StatusCode == HttpStatusCode.OK)
        {
            Console.WriteLine("Элемент изменён");
        }
        list1 = await httpClient.GetFromJsonAsync<List<string>>("https://localhost:7287/api/items");
        if (list1 != null)
        {
            foreach (var item in list1)
            {
                Console.WriteLine(item);
            }
        }
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine("Напишите новую строку.");
        obj.str = Console.ReadLine();
        using var response1 = await httpClient.PostAsJsonAsync("https://localhost:7287/api/items", obj);
        if (response1.StatusCode == HttpStatusCode.OK)
        {
            Console.WriteLine("Элемент добавлен");
        }
        list1 = await httpClient.GetFromJsonAsync<List<string>>("https://localhost:7287/api/items");
        if (list1 != null)
        {
            foreach (var item in list1)
            {
                Console.WriteLine(item);
            }
        }
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine("Выберите элемент, который будет удалён.");
        try
        {
            obj.id = Convert.ToInt32(Console.ReadLine());
            using var response2 = await httpClient.DeleteAsync($"https://localhost:7287/api/items/{obj.id}");
            if (response2.StatusCode == HttpStatusCode.NotFound)
            {
                Error? error = await response.Content.ReadFromJsonAsync<Error>();
                Console.WriteLine(error?.Message);
            }
            else if (response2.StatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine("Элемент удалён");
                list1 = await httpClient.GetFromJsonAsync<List<string>>("https://localhost:7287/api/items");
                if (list1 != null)
                {
                    foreach (var item in list1)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
        }
        catch
        {
            Console.WriteLine("Введено не число");
        }
    }
}
record Error(string Message);
class Args
{
    public int id { get; set; }
    public string str { get; set; } = "";
}