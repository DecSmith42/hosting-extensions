namespace DecSm.Extensions.Hosting.Service;

/// <summary>
///     A <see cref="BackgroundService" /> that performs work in cycles in the background.
///     This abstract class provides a framework for defining services that
///     need to perform some work on a regular cycle (defined by CycleCadenceMs)
///     while also responding to a cancellation token.
/// </summary>
/// <remarks>
///     Derive from this class to implement long-running <see cref="Microsoft.Extensions.Hosting.IHostedService" />.
///     The services will start and stop with the <see cref="Microsoft.Extensions.Hosting.IHost" />.
/// </remarks>
[PublicAPI]
public abstract class CycleBackgroundService : BackgroundService
{
    private long _nextCheckTime = Stopwatch.GetTimestamp();

    /// <summary>
    ///     The time interval in milliseconds at which the service should cycle.
    /// </summary>
    protected abstract int CycleCadenceMs { get; }

    /// <inheritdoc />
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await WaitForNextCycle(stoppingToken);

            if (stoppingToken.IsCancellationRequested)
                break;

            await ExecuteCycleAsync(stoppingToken);
        }
    }

    private async Task WaitForNextCycle(CancellationToken stoppingToken)
    {
        var currentTime = Stopwatch.GetTimestamp();
        var timeToWaitMs = (_nextCheckTime - currentTime) * 1000 / Stopwatch.Frequency;
        _nextCheckTime += CycleCadenceMs * Stopwatch.Frequency / 1000;

        if (timeToWaitMs > 0)
        {
            try
            {
                await Task.Delay((int)timeToWaitMs, stoppingToken);
            }
            catch (TaskCanceledException)
            {
                // Ignore
            }
        }
    }

    /// <summary>
    ///     Performs the work of the service. Called once per cycle.
    /// </summary>
    /// <param name="stoppingToken">
    ///     Triggered when
    ///     <see cref="Microsoft.Extensions.Hosting.IHostedService.StopAsync(System.Threading.CancellationToken)" /> is called.
    /// </param>
    /// <returns>A <see cref="System.Threading.Tasks.Task" /> that represents the work of the service.</returns>
    protected abstract Task ExecuteCycleAsync(CancellationToken stoppingToken);
}
