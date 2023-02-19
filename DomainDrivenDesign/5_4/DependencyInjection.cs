using DomainDrivenDesign.List5_4.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DomainDrivenDesign.List5_4;

public class DependencyInjection
{
    private static readonly Lazy<IServiceProvider> _service = new(()=>
    {
        var services = new ServiceCollection();
        services.AddSingleton<IUserIdFactory, UserIdFactory>();
        services.AddSingleton<IUserNameFactory, UserNameFactory>();
        services.AddSingleton<IUserRepositoryFactory, UserRepositoryFactory>();
        services.AddSingleton<IUserFactory, UserFactory>();
        return services.BuildServiceProvider();
    });

    public static IServiceProvider Services => _service.Value;
}