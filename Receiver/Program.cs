using MassTransit;

var builder = WebApplication.CreateBuilder();

builder.Services.AddMassTransit(options => {

    options.SetKebabCaseEndpointNameFormatter();
    options.SetInMemorySagaRepositoryProvider();

    var assembly = typeof(Program).Assembly;
    options.AddConsumers(assembly);

    options.AddSagaStateMachines(assembly);
    options.AddSagas(assembly);
    options.AddActivities(assembly);

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

app.Run();