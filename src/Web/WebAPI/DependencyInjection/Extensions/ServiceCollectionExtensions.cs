using Contracts.Abstractions.Messages;
using Contracts.JsonConverters;
using CorrelationId.Abstractions;
using CorrelationId.HttpClient;
using MassTransit;
using MassTransit.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WebAPI.DependencyInjection.Options;
using WebAPI.PipeObservers;

namespace WebAPI.DependencyInjection.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMessageBus(this IServiceCollection services)
        => services.AddMassTransit(cfg =>
        {
            cfg.SetKebabCaseEndpointNameFormatter();

            cfg.UsingRabbitMq((context, bus) =>
            {
                var options = context.GetRequiredService<IOptionsMonitor<MessageBusOptions>>().CurrentValue;

                bus.Host(options.ConnectionString);

                bus.UseMessageRetry(retry
                    => retry.Incremental(
                        retryLimit: options.RetryLimit,
                        initialInterval: options.InitialInterval,
                        intervalIncrement: options.IntervalIncrement));

                bus.UseNewtonsoftJsonSerializer();

                bus.ConfigureNewtonsoftJsonSerializer(settings =>
                {
                    settings.Converters.Add(new TypeNameHandlingConverter(TypeNameHandling.Objects));
                    settings.Converters.Add(new DateOnlyJsonConverter());
                    settings.Converters.Add(new ExpirationDateOnlyJsonConverter());
                    return settings;
                });

                bus.ConfigureNewtonsoftJsonDeserializer(settings =>
                {
                    settings.Converters.Add(new TypeNameHandlingConverter(TypeNameHandling.Objects));
                    settings.Converters.Add(new DateOnlyJsonConverter());
                    settings.Converters.Add(new ExpirationDateOnlyJsonConverter());
                    return settings;
                });

                bus.ConnectReceiveObserver(new LoggingReceiveObserver());
                bus.ConnectConsumeObserver(new LoggingConsumeObserver());
                bus.ConnectSendObserver(new LoggingSendObserver());
                bus.ConfigureEndpoints(context);
                
                //bus.ConfigureSend(pipe => pipe.AddPipeSpecification(
                //    new DelegatePipeSpecification<SendContext<ICommand>>(ctx =>
                //    {
                //        var accessor = context.GetRequiredService<ICorrelationContextAccessor>();
                //        ctx.CorrelationId = new(accessor.CorrelationContext.CorrelationId);
                //    })));
            });
        });

    public static OptionsBuilder<MessageBusOptions> ConfigureMessageBusOptions(this IServiceCollection services, IConfigurationSection section)
        => services
            .AddOptions<MessageBusOptions>()
            .Bind(section)
            .ValidateDataAnnotations()
            .ValidateOnStart();

    public static OptionsBuilder<MassTransitHostOptions> ConfigureMassTransitHostOptions(this IServiceCollection services, IConfigurationSection section)
        => services
            .AddOptions<MassTransitHostOptions>()
            .Bind(section)
            .ValidateDataAnnotations()
            .ValidateOnStart();

    public static OptionsBuilder<RabbitMqTransportOptions> ConfigureRabbitMqTransportOptions(this IServiceCollection services, IConfigurationSection section)
        => services
            .AddOptions<RabbitMqTransportOptions>()
            .Bind(section)
            .ValidateDataAnnotations()
            .ValidateOnStart();

}