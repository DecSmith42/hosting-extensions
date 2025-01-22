# Dec's Hosting Extensions

`DecSm.Extensions.Hosting`

A collection of extensions for the `Microsoft.Extensions.Hosting` namespace.

## Getting Started

### HostControl

`IHostControl` (backed by a `HostControl` implementation) is a wrapper for IHostApplicationLifetime that provides an optional exit code
argument.

**Example:**

```csharp
var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHostControl();
builder.Services.AddHostedService<MyService>();

builder.Build().Run();

class MyService(IHostControl hostControl) : BackgroundService
{
    public override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await Task.Delay(1000, stoppingToken);
        
        try
        {
            // Do critical work
            
            // Exit with code 0
            _hostControl.StopApplication();
        }
        catch
        {
            // Exit with code 1
            _hostControl.StopApplication(1);
        }
    }
}
```

### CycleBackgroundService

`CycleBackgroundService` is a `BackgroundService` that executes on a cycle defined by a `CycleCadenceMs` interval.

**Example:**

```csharp
var builder = Host.CreateApplicationBuilder(args);
  
builder.Services.AddHostedService<MyService>();
  
builder.Build().Run();
  
class MyService : CycleBackgroundService
{
    protected int CycleCadenceMs => 1000;
  
    protected override async Task ExecuteCycleAsync(CancellationToken stoppingToken)
    {
        // Called every 1000ms
    }
}
```

> Note: `CycleBackgroundService` will attempt to adhere to the cycle timing it is provided, adjusting for the execution time of the
`ExecuteCycleAsync` method.
> This means that if the cycle is 1000ms and `ExecuteCycleAsync` takes 500ms to execute, the next cycle will begin 500ms after the previous
> cycle ends, rather than 1000ms after the previous cycle ends.
> If the cycle is 1000ms and `ExecuteCycleAsync` takes 1500ms to execute, the next cycle will begin immediately.

### ServiceCollectionExtensions

#### AddSingleton / AddScoped / AddHostedService <TService1, TService2, TImplementation>

Adds a singleton service of the types specified in `TService1`, `TService2`, and `TImplementation` with an implementation type specified in
`TImplementation` to the specified `IServiceCollection`.

**Example:**

```csharp
var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddSingleton<IService1, IService2, Service>();

var app = builder.Build();

// Service can be resolved as IService1, IService2, or Service
var serviceAsInterface1 = app.Services.GetRequiredService<IService1>();
var serviceAsInterface2 = app.Services.GetRequiredService<IService2>();
var serviceAsImplementation = app.Services.GetRequiredService<Service>();

interface Interface1
{
    void Method1();
}

interface Interface2
{
    void Method2();
}

class Service : IService1, IService2
{
    public void Method1() { /* Implementation */ }
    public void Method2() { /* Implementation */ }
}

```

There are also variations of the methods for Scoped and HostedService dependencies.
Each variation has overloads that can be used with up to 4 interface implementations for the implementing type.

## License

Hosting Extensions is released under the MIT License. See the [LICENSE](LICENSE.txt) file for details.
