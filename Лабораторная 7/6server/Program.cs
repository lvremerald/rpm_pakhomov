List<string> list1 = new List<string>
{
    "1",
    "2",
    "3",
    "0",
    "0.69",
    "apple",
    "ananab",
    "0-zfc2jk9mnjv"
};

var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.MapGet("", () => "Go to /api/items");

app.MapGet("/api/items", () => list1);
app.MapGet("/api/items/{id}", (int id) =>
{
    var item = list1.FirstOrDefault(i => list1.IndexOf(i) == id);
    if (item == null) return Results.NotFound(new
    {
        message = "Item not found"
    });
    return Results.Json(item);
});

app.MapDelete("/api/items/{id}", (int id) =>
{
    var item = list1.FirstOrDefault(i => list1.IndexOf(i) == id);
    if (item == null) return Results.NotFound(new
    {
        message = "Item not found"
    });
    list1.Remove(item);
    return Results.Json(item);
});

app.MapPost("/api/items", (Args obj) =>
{
    list1.Add(obj.str);
    return obj.str;
});

app.MapPut("/api/items", (Args obj) =>
{
    var item = list1.FirstOrDefault(i => list1.IndexOf(i) == obj.id);
    if (item == null) return Results.NotFound(new {message = "Item not found"});
    list1[obj.id] = obj.str;
    return Results.Json(list1[obj.id]);
});

app.Run();

class Args
{
    public int id { get; set; }
    public string str { get; set; } = "";
}