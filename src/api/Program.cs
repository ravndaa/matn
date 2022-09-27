
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var secretKey = "SuperSecretEY"; //pragma: allowlist secret

app.MapGet("/", () => "Hello World!");

app.Run();
