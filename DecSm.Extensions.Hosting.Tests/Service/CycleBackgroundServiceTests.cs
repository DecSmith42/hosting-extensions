﻿namespace DecSm.Extensions.Hosting.Tests.Service;

[TestFixture]
[SuppressMessage("ReSharper", "MethodSupportsCancellation")]
[SuppressMessage("Reliability", "CA2016:Forward the \'CancellationToken\' parameter to methods")]
public class CycleBackgroundServiceTests
{
    [Test]
    public async Task ExecuteAsync_ShouldCallExecuteCycleAsync_Immediately()
    {
        // Arrange
        var service = new TestCycleBackgroundService();
        var cts = new CancellationTokenSource();

        // Act
        var task = service.StartAsync(cts.Token);
        await Task.Delay(50); // wait for less than CycleCadenceMs
        await cts.CancelAsync();
        await task; // wait for the service to stop

        // Assert
        service.ExecuteCycleAsyncCallCount.ShouldBe(1);
    }

    [Test]
    public async Task ExecuteAsync_ShouldRepeatExecuteCycleAsync()
    {
        // Arrange
        var service = new TestCycleBackgroundService();
        var cts = new CancellationTokenSource();

        // Act
        var task = service.StartAsync(cts.Token);
        await Task.Delay(250); // wait for less than CycleCadenceMs
        await cts.CancelAsync();
        await task; // wait for the service to stop

        // Assert
        service.ExecuteCycleAsyncCallCount.ShouldBe(3);
    }

    [Test]
    public async Task ExecuteAsync_ShouldNotRepeatExecuteCycleAsync_AfterCancellation()
    {
        // Arrange
        var service = new TestCycleBackgroundService();
        var cts = new CancellationTokenSource();

        // Act
        var task = service.StartAsync(cts.Token);
        await Task.Delay(250); // wait for less than CycleCadenceMs
        await cts.CancelAsync();
        await task; // wait for the service to stop
        await Task.Delay(250); // wait some more

        // Assert
        service.ExecuteCycleAsyncCallCount.ShouldBe(3);
    }

    [Test]
    public async Task ExecuteAsync_DoesNotCatchImmediateExceptions()
    {
        // Arrange
        var service = new TestCycleBackgroundService
        {
            ThrowImmediateException = true,
        };

        var cts = new CancellationTokenSource();

        // Act/Assert
        await Should.ThrowAsync<Exception>(() => service.StartAsync(cts.Token));
    }

    [Test]
    public async Task ExecuteAsync_DoesNotCatchDelayedExceptions()
    {
        // Arrange
        var service = new TestCycleBackgroundService
        {
            ThrowDelayedException = true,
        };

        var cts = new CancellationTokenSource();

        // Act
        await service.StartAsync(cts.Token);
        await service.StopAsync(CancellationToken.None);

        // Assert
        service.ExecuteCycleAsyncCallCount.ShouldBe(0);
    }
}
