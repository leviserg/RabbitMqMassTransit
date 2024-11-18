using MassTransit;
using MessageContract;
using Microsoft.AspNetCore.Mvc;
using Sender.Services;

var builder = WebApplication.CreateBuilder();

builder.Services.AddSingleton<ICustomSenderService, CustomSenderService>();

builder.Services.AddMassTransit(options => {

    /*
    options.AddConsumers(typeof(Program).Assembly); // find all IConsumer imp;lementations within current assembly
    options.UsingInMemory((ctx, cfg) =>
    {
        cfg.ConfigureEndpoints(ctx);
    });
    */

    options.SetKebabCaseEndpointNameFormatter();

    options.UsingRabbitMq((ctx, cfg) =>
    {
        // "/" - rabbitmq virtual host -> "/" by default (rabbitmq.conf)
        cfg.Host("localhost", "/", cred =>
        {
            cred.Username(Environment.GetEnvironmentVariable("RABBITMQ_USERNAME") ?? string.Empty);
            cred.Password(Environment.GetEnvironmentVariable("RABBITMQ_USERPASS") ?? string.Empty);
        });
        cfg.ConfigureEndpoints(ctx);
    });

});


var app = builder.Build();

//app.MapGet("/sendMessage", () => "Hello, World!");

app.MapPost("/sendmessage", async ([FromBody] string title, ICustomSenderService senderService) =>
{
    var customMessage = new CustomMessage(title);
    await senderService.SendMessageAsync(customMessage);
    return Results.Ok(customMessage);
});


app.Run();
