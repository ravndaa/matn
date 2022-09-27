// #pragma warning disable CA1852

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//var secretKey = "SuperSecretKEY"; //pragma: allowlist secret

app.MapGet("/", () => "Hello World!");

app.Run();
