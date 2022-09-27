var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var secretKey = "SuperSecretKEY"; //pragma: allowlist secret

app.MapGet("/", () => "Hello World!");

app.Run();
