using System;
using DomainDrivenDesign.List5_4.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DomainDrivenDesign.List5_4;

public class DependencyInjection
{
    private static Lazy<IServiceProvider> _service = new(()=>
    {
        var services = new ServiceCollection();
        services.AddSingleton<IUserNameFactory, UserNameFactory>();
        return services.BuildServiceProvider();
    });

    public static IServiceProvider Services => _service.Value;
}