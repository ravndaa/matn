
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// this should fail when running actions.
var secretKey = "SuperSecretEY"; //pragma: allowlist secret

app.MapGet("/", () => "Hello World!");

app.Run();
