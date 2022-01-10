
// Builder
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IOperationTransient, Operation>();
builder.Services.AddScoped<IOperationScoped, Operation>();
builder.Services.AddSingleton<IOperationSingleton, Operation>();

// App
var app = builder.Build();

app.MapGet("/getservices", 
    (IOperationTransient opTransient, 
    IOperationSingleton opSingleton, 
    IOperationScoped opScoped) => {

        return $"Singleton - {opSingleton.OperationId} | Transient - {opTransient.OperationId} | Scoped - {opScoped.OperationId}";
    }
);

app.Run();
