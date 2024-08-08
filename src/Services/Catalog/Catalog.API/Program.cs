var builder = WebApplication.CreateBuilder(args);

// Services to the container


var app = builder.Build();

// Request pipeline


app.Run();
