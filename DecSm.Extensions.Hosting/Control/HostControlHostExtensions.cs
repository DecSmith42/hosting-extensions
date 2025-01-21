namespace DecSm.Extensions.Hosting.Control;

/// <summary>
///     Provides extension methods for <see cref="IServiceCollection" /> to add host control capabilities.
/// </summary>
[PublicAPI]
public static class HostControlHostExtensions
{
    /// <summary>
    ///     Adds host control capabilities to the <see cref="IServiceCollection" />.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection" /> to add the <see cref="IHostControl" /> service to.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    /// <remarks>
    ///     Adds the <see cref="IHostControl" /> service to the service collection as a singleton.
    /// </remarks>
    public static IServiceCollection AddHostControl(this IServiceCollection services) =>
        services.AddSingleton<IHostControl, HostControl>();
}
