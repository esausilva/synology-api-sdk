using Synology.Api.Sdk.Extensions;
using TUnit.Assertions.AssertConditions.Throws;

namespace Synology.Api.Sdk.Tests.UnitTests.ExtensionsTests;

public class IntegerExtensionsTests
{
    [Test]
    [Arguments(-1)]
    [Arguments(0)]
    public async Task Assert_ThrowIfZeroOrNegative_Throws(int value)
    {
        await Assert
            .That(() => value.ThrowIfZeroOrNegative(nameof(value)))
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    [Arguments(1)]
    [Arguments(2)]
    public async Task Assert_ThrowIfZeroOrNegative_Does_Not_Throw(int value)
    {
        await Assert
            .That(() => value.ThrowIfZeroOrNegative(nameof(value)))
            .ThrowsNothing();
    }
    
    [Test]
    [Arguments(-1)]
    [Arguments(-2)]
    public async Task Assert_ThrowIfNegative_Throws(int value)
    {
        await Assert
            .That(() => value.ThrowIfNegative(nameof(value)))
            .ThrowsExactly<ArgumentException>();
    }

    [Test]
    [Arguments(0)]
    [Arguments(1)]
    [Arguments(2)]
    public async Task Assert_ThrowIfNegative_Does_Not_Throw(int value)
    {
        await Assert
            .That(() => value.ThrowIfNegative(nameof(value)))
            .ThrowsNothing();
    }
}