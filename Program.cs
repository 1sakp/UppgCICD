var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/add", (int num1, int num2) => AddNumbers(num1, num2));

app.Run();

string AddNumbers(int num1, int num2)
{
    
    return($"sum of {num1} and {num2} is {num1 + num2}");
}