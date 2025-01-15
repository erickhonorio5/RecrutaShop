namespace Basket.API.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection DependencyInjections(this IServiceCollection services)
    {
        services.AddScoped<IBasketRepository, BasketRepository>();
        services.Decorate<IBasketRepository, CachedBasketRepository>();

        return services;
    }
}
