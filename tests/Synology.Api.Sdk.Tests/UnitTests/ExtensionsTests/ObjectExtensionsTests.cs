using Synology.Api.Sdk.Extensions;

namespace Synology.Api.Sdk.Tests.UnitTests.ExtensionsTests;

public class ObjectExtensionsTests
{
    [Test]
    [Arguments(null)]
    [Arguments("test string")]
    public async Task Assert_IsEnumerable_Returns_False(object? value)
    {
        await Assert
            .That(value.IsEnumerable())
            .IsFalse();
    }
    
    [Test]
    [Arguments(new[] { 1, 2, 3 })]
    public async Task Assert_IsEnumerable_Returns_True(object value)
    {
        await Assert
            .That(value.IsEnumerable())
            .IsTrue();
    }
}