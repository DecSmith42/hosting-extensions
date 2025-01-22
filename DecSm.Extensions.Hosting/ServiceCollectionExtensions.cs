namespace DecSm.Extensions.Hosting;

/// <summary>
///     Provides extension methods for <see cref="IServiceCollection" /> to support multiple service registration.
/// </summary>
[PublicAPI]
public static class ServiceCollectionExtensions
{
    /// <summary>
    ///     Adds a singleton service of the types specified in <typeparamref name="TService1" />, <typeparamref name="TService2" />
    ///     with an implementation type specified in <typeparamref name="TImplementation" /> to the specified <see cref="IServiceCollection" />.
    /// </summary>
    /// <typeparam name="TService1">The first type of the service to add.</typeparam>
    /// <typeparam name="TService2">The second type of the service to add.</typeparam>
    /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection" /> to add the service to.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    /// <remarks>All service registrations will share the same instance of the implementation type.</remarks>
    /// <seealso cref="ServiceLifetime.Singleton" />
    public static IServiceCollection AddSingleton<TService1, TService2,
        #if NET8_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
        #endif
        TImplementation>(this IServiceCollection services)
        where TService1 : class
        where TService2 : class
        where TImplementation : class, TService1, TService2 =>
        services
            .AddSingleton<TImplementation>()
            .AddSingleton<TService1, TImplementation>(serviceProvider => serviceProvider.GetRequiredService<TImplementation>())
            .AddSingleton<TService2, TImplementation>(serviceProvider => serviceProvider.GetRequiredService<TImplementation>());

    /// <summary>
    ///     Adds a singleton service of the types specified in <typeparamref name="TService1" />, <typeparamref name="TService2" />,
    ///     <typeparamref name="TService3" />
    ///     with an implementation type specified in <typeparamref name="TImplementation" /> to the specified <see cref="IServiceCollection" />.
    /// </summary>
    /// <typeparam name="TService1">The first type of the service to add.</typeparam>
    /// <typeparam name="TService2">The second type of the service to add.</typeparam>
    /// <typeparam name="TService3">The third type of the service to add.</typeparam>
    /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection" /> to add the service to.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    /// <remarks>All service registrations will share the same instance of the implementation type.</remarks>
    /// <seealso cref="ServiceLifetime.Singleton" />
    public static IServiceCollection AddSingleton<TService1, TService2, TService3,
        #if NET8_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
        #endif
        TImplementation>(this IServiceCollection services)
        where TService1 : class
        where TService2 : class
        where TService3 : class
        where TImplementation : class, TService1, TService2, TService3 =>
        services
            .AddSingleton<TImplementation>()
            .AddSingleton<TService1, TImplementation>(serviceProvider => serviceProvider.GetRequiredService<TImplementation>())
            .AddSingleton<TService2, TImplementation>(serviceProvider => serviceProvider.GetRequiredService<TImplementation>())
            .AddSingleton<TService3, TImplementation>(serviceProvider => serviceProvider.GetRequiredService<TImplementation>());

    /// <summary>
    ///     Adds a singleton service of the types specified in <typeparamref name="TService1" />, <typeparamref name="TService2" />,
    ///     <typeparamref name="TService3" />, <typeparamref name="TService4" />
    ///     with an implementation type specified in <typeparamref name="TImplementation" /> to the specified <see cref="IServiceCollection" />.
    /// </summary>
    /// <typeparam name="TService1">The first type of the service to add.</typeparam>
    /// <typeparam name="TService2">The second type of the service to add.</typeparam>
    /// <typeparam name="TService3">The third type of the service to add.</typeparam>
    /// <typeparam name="TService4">The fourth type of the service to add.</typeparam>
    /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection" /> to add the service to.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    /// <remarks>All service registrations will share the same instance of the implementation type.</remarks>
    /// <seealso cref="ServiceLifetime.Singleton" />
    public static IServiceCollection AddSingleton<TService1, TService2, TService3, TService4,
        #if NET8_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
        #endif
        TImplementation>(this IServiceCollection services)
        where TService1 : class
        where TService2 : class
        where TService3 : class
        where TService4 : class
        where TImplementation : class, TService1, TService2, TService3, TService4 =>
        services
            .AddSingleton<TImplementation>()
            .AddSingleton<TService1, TImplementation>(serviceProvider => serviceProvider.GetRequiredService<TImplementation>())
            .AddSingleton<TService2, TImplementation>(serviceProvider => serviceProvider.GetRequiredService<TImplementation>())
            .AddSingleton<TService3, TImplementation>(serviceProvider => serviceProvider.GetRequiredService<TImplementation>())
            .AddSingleton<TService4, TImplementation>(serviceProvider => serviceProvider.GetRequiredService<TImplementation>());

    /// <summary>
    ///     Adds a singleton service of the types specified in <typeparamref name="TService1" />, <typeparamref name="TService2" />,
    ///     <typeparamref name="TService3" />, <typeparamref name="TService4" />, <typeparamref name="TService5" />
    ///     with an implementation type specified in <typeparamref name="TImplementation" /> to the specified <see cref="IServiceCollection" />.
    /// </summary>
    /// <typeparam name="TService1">The first type of the service to add.</typeparam>
    /// <typeparam name="TService2">The second type of the service to add.</typeparam>
    /// <typeparam name="TService3">The third type of the service to add.</typeparam>
    /// <typeparam name="TService4">The fourth type of the service to add.</typeparam>
    /// <typeparam name="TService5">The fifth type of the service to add.</typeparam>
    /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection" /> to add the service to.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    /// <remarks>All service registrations will share the same instance of the implementation type.</remarks>
    /// <seealso cref="ServiceLifetime.Singleton" />
    public static IServiceCollection AddSingleton<TService1, TService2, TService3, TService4, TService5,
        #if NET8_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
        #endif
        TImplementation>(this IServiceCollection services)
        where TService1 : class
        where TService2 : class
        where TService3 : class
        where TService4 : class
        where TService5 : class
        where TImplementation : class, TService1, TService2, TService3, TService4, TService5 =>
        services
            .AddSingleton<TImplementation>()
            .AddSingleton<TService1, TImplementation>(serviceProvider => serviceProvider.GetRequiredService<TImplementation>())
            .AddSingleton<TService2, TImplementation>(serviceProvider => serviceProvider.GetRequiredService<TImplementation>())
            .AddSingleton<TService3, TImplementation>(serviceProvider => serviceProvider.GetRequiredService<TImplementation>())
            .AddSingleton<TService4, TImplementation>(serviceProvider => serviceProvider.GetRequiredService<TImplementation>())
            .AddSingleton<TService5, TImplementation>(serviceProvider => serviceProvider.GetRequiredService<TImplementation>());

    /// <summary>
    ///     Adds a scoped service of the types specified in <typeparamref name="TService1" />, <typeparamref name="TService2" />
    ///     with an implementation type specified in <typeparamref name="TImplementation" /> to the specified <see cref="IServiceCollection" />.
    /// </summary>
    /// <typeparam name="TService1">The first type of the service to add.</typeparam>
    /// <typeparam name="TService2">The second type of the service to add.</typeparam>
    /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection" /> to add the service to.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    /// <remarks>All service registrations will share the same instance of the implementation type within a scope.</remarks>
    /// <seealso cref="ServiceLifetime.Scoped" />
    public static IServiceCollection AddScoped<TService1, TService2,
        #if NET8_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
        #endif
        TImplementation>(this IServiceCollection services)
        where TService1 : class
        where TService2 : class
        where TImplementation : class, TService1, TService2 =>
        services
            .AddScoped<TImplementation>()
            .AddScoped<TService1, TImplementation>(serviceProvider => serviceProvider.GetRequiredService<TImplementation>())
            .AddScoped<TService2, TImplementation>(serviceProvider => serviceProvider.GetRequiredService<TImplementation>());

    /// <summary>
    ///     Adds a scoped service of the types specified in <typeparamref name="TService1" />, <typeparamref name="TService2" />,
    ///     <typeparamref name="TService3" />
    ///     with an implementation type specified in <typeparamref name="TImplementation" /> to the specified <see cref="IServiceCollection" />.
    /// </summary>
    /// <typeparam name="TService1">The first type of the service to add.</typeparam>
    /// <typeparam name="TService2">The second type of the service to add.</typeparam>
    /// <typeparam name="TService3">The third type of the service to add.</typeparam>
    /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection" /> to add the service to.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    /// <remarks>All service registrations will share the same instance of the implementation type within a scope.</remarks>
    /// <seealso cref="ServiceLifetime.Scoped" />
    public static IServiceCollection AddScoped<TService1, TService2, TService3,
        #if NET8_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
        #endif
        TImplementation>(this IServiceCollection services)
        where TService1 : class
        where TService2 : class
        where TService3 : class
        where TImplementation : class, TService1, TService2, TService3 =>
        services
            .AddScoped<TImplementation>()
            .AddScoped<TService1, TImplementation>(serviceProvider => serviceProvider.GetRequiredService<TImplementation>())
            .AddScoped<TService2, TImplementation>(serviceProvider => serviceProvider.GetRequiredService<TImplementation>())
            .AddScoped<TService3, TImplementation>(serviceProvider => serviceProvider.GetRequiredService<TImplementation>());

    /// <summary>
    ///     Adds a scoped service of the types specified in <typeparamref name="TService1" />, <typeparamref name="TService2" />,
    ///     <typeparamref name="TService3" />, <typeparamref name="TService4" />
    ///     with an implementation type specified in <typeparamref name="TImplementation" /> to the specified <see cref="IServiceCollection" />.
    /// </summary>
    /// <typeparam name="TService1">The first type of the service to add.</typeparam>
    /// <typeparam name="TService2">The second type of the service to add.</typeparam>
    /// <typeparam name="TService3">The third type of the service to add.</typeparam>
    /// <typeparam name="TService4">The fourth type of the service to add.</typeparam>
    /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection" /> to add the service to.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    /// <remarks>All service registrations will share the same instance of the implementation type within a scope.</remarks>
    /// <seealso cref="ServiceLifetime.Scoped" />
    public static IServiceCollection AddScoped<TService1, TService2, TService3, TService4,
        #if NET8_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
        #endif
        TImplementation>(this IServiceCollection services)
        where TService1 : class
        where TService2 : class
        where TService3 : class
        where TService4 : class
        where TImplementation : class, TService1, TService2, TService3, TService4 =>
        services
            .AddScoped<TImplementation>()
            .AddScoped<TService1, TImplementation>(serviceProvider => serviceProvider.GetRequiredService<TImplementation>())
            .AddScoped<TService2, TImplementation>(serviceProvider => serviceProvider.GetRequiredService<TImplementation>())
            .AddScoped<TService3, TImplementation>(serviceProvider => serviceProvider.GetRequiredService<TImplementation>())
            .AddScoped<TService4, TImplementation>(serviceProvider => serviceProvider.GetRequiredService<TImplementation>());

    /// <summary>
    ///     Adds a scoped service of the types specified in <typeparamref name="TService1" />, <typeparamref name="TService2" />,
    ///     <typeparamref name="TService3" />, <typeparamref name="TService4" />, <typeparamref name="TService5" />
    ///     with an implementation type specified in <typeparamref name="TImplementation" /> to the specified <see cref="IServiceCollection" />.
    /// </summary>
    /// <typeparam name="TService1">The first type of the service to add.</typeparam>
    /// <typeparam name="TService2">The second type of the service to add.</typeparam>
    /// <typeparam name="TService3">The third type of the service to add.</typeparam>
    /// <typeparam name="TService4">The fourth type of the service to add.</typeparam>
    /// <typeparam name="TService5">The fifth type of the service to add.</typeparam>
    /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection" /> to add the service to.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    /// <remarks>All service registrations will share the same instance of the implementation type within a scope.</remarks>
    /// <seealso cref="ServiceLifetime.Scoped" />
    public static IServiceCollection AddScoped<TService1, TService2, TService3, TService4, TService5,
        #if NET8_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
        #endif
        TImplementation>(this IServiceCollection services)
        where TService1 : class
        where TService2 : class
        where TService3 : class
        where TService4 : class
        where TService5 : class
        where TImplementation : class, TService1, TService2, TService3, TService4, TService5 =>
        services
            .AddScoped<TImplementation>()
            .AddScoped<TService1, TImplementation>(serviceProvider => serviceProvider.GetRequiredService<TImplementation>())
            .AddScoped<TService2, TImplementation>(serviceProvider => serviceProvider.GetRequiredService<TImplementation>())
            .AddScoped<TService3, TImplementation>(serviceProvider => serviceProvider.GetRequiredService<TImplementation>())
            .AddScoped<TService4, TImplementation>(serviceProvider => serviceProvider.GetRequiredService<TImplementation>())
            .AddScoped<TService5, TImplementation>(serviceProvider => serviceProvider.GetRequiredService<TImplementation>());

    /// <summary>
    ///     Adds a hosted service of the types specified in <typeparamref name="TService" />, with an
    ///     implementation type specified in <typeparamref name="TImplementation" /> to the specified <see cref="IServiceCollection" />.
    /// </summary>
    /// <typeparam name="TService">The type of the service to add.</typeparam>
    /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
    /// <param name="serviceCollection">The <see cref="IServiceCollection" /> to add the service to.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    /// <remarks>The service is registered as a singleton and as a hosted service.</remarks>
    public static IServiceCollection AddHostedService<TService,
        #if NET8_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
        #endif
        TImplementation>(this IServiceCollection serviceCollection)
        where TService : class
        where TImplementation : class, TService, IHostedService =>
        serviceCollection
            .AddSingleton<TImplementation>()
            .AddSingleton<TService>(serviceProvider => serviceProvider.GetRequiredService<TImplementation>())
            .AddHostedService(serviceProvider => serviceProvider.GetRequiredService<TImplementation>());

    /// <summary>
    ///     Adds a hosted service of the types specified in <typeparamref name="TService1" />, <typeparamref name="TService2" />, with an
    ///     implementation type specified in <typeparamref name="TImplementation" /> to the specified <see cref="IServiceCollection" />.
    /// </summary>
    /// <typeparam name="TService1">The first type of the service to add.</typeparam>
    /// <typeparam name="TService2">The second type of the service to add.</typeparam>
    /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
    /// <param name="serviceCollection">The <see cref="IServiceCollection" /> to add the service to.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    /// <remarks>The service is registered as a singleton and as a hosted service.</remarks>
    public static IServiceCollection AddHostedService<TService1, TService2,
        #if NET8_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
        #endif
        TImplementation>(this IServiceCollection serviceCollection)
        where TService1 : class
        where TService2 : class
        where TImplementation : class, TService1, TService2, IHostedService =>
        serviceCollection
            .AddSingleton<TImplementation>()
            .AddSingleton<TService1, TImplementation>(serviceProvider => serviceProvider.GetRequiredService<TImplementation>())
            .AddSingleton<TService2, TImplementation>(serviceProvider => serviceProvider.GetRequiredService<TImplementation>())
            .AddHostedService(serviceProvider => serviceProvider.GetRequiredService<TImplementation>());

    /// <summary>
    ///     Adds a hosted service of the types specified in <typeparamref name="TService1" />, <typeparamref name="TService2" />,
    ///     <typeparamref name="TService3" />,
    ///     with an implementation type specified in <typeparamref name="TImplementation" /> to the specified <see cref="IServiceCollection" />.
    /// </summary>
    /// <typeparam name="TService1">The first type of the service to add.</typeparam>
    /// <typeparam name="TService2">The second type of the service to add.</typeparam>
    /// <typeparam name="TService3">The third type of the service to add.</typeparam>
    /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
    /// <param name="serviceCollection">The <see cref="IServiceCollection" /> to add the service to.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    /// <remarks>The service is registered as a singleton and as a hosted service.</remarks>
    public static IServiceCollection AddHostedService<TService1, TService2, TService3,
        #if NET8_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
        #endif
        TImplementation>(this IServiceCollection serviceCollection)
        where TService1 : class
        where TService2 : class
        where TService3 : class
        where TImplementation : class, TService1, TService2, TService3, IHostedService =>
        serviceCollection
            .AddSingleton<TImplementation>()
            .AddSingleton<TService1, TImplementation>(serviceProvider => serviceProvider.GetRequiredService<TImplementation>())
            .AddSingleton<TService2, TImplementation>(serviceProvider => serviceProvider.GetRequiredService<TImplementation>())
            .AddSingleton<TService3, TImplementation>(serviceProvider => serviceProvider.GetRequiredService<TImplementation>())
            .AddHostedService(serviceProvider => serviceProvider.GetRequiredService<TImplementation>());

    /// <summary>
    ///     Adds a hosted service of the types specified in <typeparamref name="TService1" />, <typeparamref name="TService2" />,
    ///     <typeparamref name="TService3" />, <typeparamref name="TService4" />,
    ///     with an implementation type specified in <typeparamref name="TImplementation" /> to the specified <see cref="IServiceCollection" />.
    /// </summary>
    /// <typeparam name="TService1">The first type of the service to add.</typeparam>
    /// <typeparam name="TService2">The second type of the service to add.</typeparam>
    /// <typeparam name="TService3">The third type of the service to add.</typeparam>
    /// <typeparam name="TService4">The fourth type of the service to add.</typeparam>
    /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
    /// <param name="serviceCollection">The <see cref="IServiceCollection" /> to add the service to.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    /// <remarks>The service is registered as a singleton and as a hosted service.</remarks>
    public static IServiceCollection AddHostedService<TService1, TService2, TService3, TService4,
        #if NET8_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
        #endif
        TImplementation>(this IServiceCollection serviceCollection)
        where TService1 : class
        where TService2 : class
        where TService3 : class
        where TService4 : class
        where TImplementation : class, TService1, TService2, TService3, TService4, IHostedService =>
        serviceCollection
            .AddSingleton<TImplementation>()
            .AddSingleton<TService1, TImplementation>(serviceProvider => serviceProvider.GetRequiredService<TImplementation>())
            .AddSingleton<TService2, TImplementation>(serviceProvider => serviceProvider.GetRequiredService<TImplementation>())
            .AddSingleton<TService3, TImplementation>(serviceProvider => serviceProvider.GetRequiredService<TImplementation>())
            .AddSingleton<TService4, TImplementation>(serviceProvider => serviceProvider.GetRequiredService<TImplementation>())
            .AddHostedService(serviceProvider => serviceProvider.GetRequiredService<TImplementation>());

    /// <summary>
    ///     Adds a hosted service of the types specified in <typeparamref name="TService1" />, <typeparamref name="TService2" />,
    ///     <typeparamref name="TService3" />, <typeparamref name="TService4" />, <typeparamref name="TService5" />,
    ///     with an implementation type specified in <typeparamref name="TImplementation" /> to the specified <see cref="IServiceCollection" />.
    /// </summary>
    /// <typeparam name="TService1">The first type of the service to add.</typeparam>
    /// <typeparam name="TService2">The second type of the service to add.</typeparam>
    /// <typeparam name="TService3">The third type of the service to add.</typeparam>
    /// <typeparam name="TService4">The fourth type of the service to add.</typeparam>
    /// <typeparam name="TService5">The fifth type of the service to add.</typeparam>
    /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
    /// <param name="serviceCollection">The <see cref="IServiceCollection" /> to add the service to.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    /// <remarks>The service is registered as a singleton and as a hosted service.</remarks>
    public static IServiceCollection AddHostedService<TService1, TService2, TService3, TService4, TService5,
        #if NET8_0_OR_GREATER
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
        #endif
        TImplementation>(this IServiceCollection serviceCollection)
        where TService1 : class
        where TService2 : class
        where TService3 : class
        where TService4 : class
        where TService5 : class
        where TImplementation : class, TService1, TService2, TService3, TService4, TService5, IHostedService =>
        serviceCollection
            .AddSingleton<TImplementation>()
            .AddSingleton<TService1, TImplementation>(serviceProvider => serviceProvider.GetRequiredService<TImplementation>())
            .AddSingleton<TService2, TImplementation>(serviceProvider => serviceProvider.GetRequiredService<TImplementation>())
            .AddSingleton<TService3, TImplementation>(serviceProvider => serviceProvider.GetRequiredService<TImplementation>())
            .AddSingleton<TService4, TImplementation>(serviceProvider => serviceProvider.GetRequiredService<TImplementation>())
            .AddSingleton<TService5, TImplementation>(serviceProvider => serviceProvider.GetRequiredService<TImplementation>())
            .AddHostedService(serviceProvider => serviceProvider.GetRequiredService<TImplementation>());
}
