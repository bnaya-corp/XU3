using DotNet.Testcontainers.Builders;
using XU3;
using Xunit.Sdk;
using Xunit.v3;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;

[assembly: TestPipelineStartup(typeof(Tests.Setup))]

namespace Tests;


public class Setup : ITestPipelineStartup
{
    public IContainer Container { get; private set; }

    public async ValueTask StartAsync(IMessageSink diagnosticMessageSink)
    {
        //Container = new ContainerBuilder()
        //    .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
        //    .WithEnvironment("ACCEPT_EULA", "Y")
        //    .WithEnvironment("SA_PASSWORD", "MasadNetunim12!@")
        //    .WithPortBinding(1433, 1433)
        //    .WithWaitStrategy(Wait.ForUnixContainer().UntilPortIsAvailable(1433))
        //    .Build();
        //await Container.StartAsync();
        TestContext.Current.AddWarning("@@ Container started!");
        //TestContext.Current.SendDiagnosticMessage("@@ Container started!");
    }

    public async ValueTask StopAsync()
    {
        await Container.DisposeAsync();
    }
}

public class Bar
{
    public static TheoryData<int, string> MyData =
      new MatrixTheoryData<int, string>(
          [42, 2112, 2600],
          ["Hello", "World"]
      );

    [Theory]
    [MemberData(nameof(MyData))]
    public void TestAddition(int a, string b)
    {
        Assert.NotNull(b);
    }
}

public class FooTests
{
    private readonly Foo _foo;

    public FooTests()
    {
        _foo = new Foo();
    }

    [Fact]
    public void Test1()
    {
        TestContext.Current.CancellationToken.ThrowIfCancellationRequested();
        TestContext.Current.SendDiagnosticMessage("@@ Test!");

        Assert.True(_foo.True);
    }

    [Fact]
    public void Test2()
    {
        TestContext.Current.CancellationToken.ThrowIfCancellationRequested();
        TestContext.Current.SendDiagnosticMessage("@@ Test!");

        Assert.True(_foo.True);
    }
}
