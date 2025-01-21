namespace DecSm.Extensions.Hosting.Control;

/// <summary>
///     Provides control over the host.
/// </summary>
/// <remarks>
///     This can be added to the DI container and injected in place of <see cref="IHostApplicationLifetime" /> to provide additional control
///     over the host.
/// </remarks>
[PublicAPI]
public interface IHostControl : IHostApplicationLifetime
{
    /// <summary>Requests termination of the current application.</summary>
    /// <param name="exitCode">The exit code that will be returned to the operating system when the application exits.</param>
    void StopApplication(int exitCode = 0);
}
