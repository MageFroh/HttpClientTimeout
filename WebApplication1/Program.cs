var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpLogging();
app.MapGet("/", () => "Hello World!");
app.MapControllers();

app.Run();
