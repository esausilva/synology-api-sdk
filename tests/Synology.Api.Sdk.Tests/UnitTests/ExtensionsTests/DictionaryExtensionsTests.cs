using Synology.Api.Sdk.Extensions;

namespace Synology.Api.Sdk.Tests.UnitTests.ExtensionsTests;

public class DictionaryExtensionsTests
{
    private static readonly Dictionary<string, string> Dictionary = new();

    [Before(Test)]
    public  void Setup_Dictionary_To_Test()
    {
        Dictionary.Clear();
        Dictionary.Add("key1", "value1");
        Dictionary.Add("key2", "value2");
        Dictionary.Add("key3", "value3");
    }

    [Test]
    [NotInParallel]
    public async Task Assert_Merge_Dictionary_Count_Is_Correct()
    {
        var additionalItems = new Dictionary<string, string>
        {
            { "key4", "value4" },
            { "key5", "value5" },
        };

        Dictionary.Merge(additionalItems);
        
        await Assert
            .That(Dictionary)
            .HasCount(5);
    }
    
    [Test]
    [NotInParallel]
    public async Task Assert_Merge_Dictionary_Contains_Additional_Items()
    {
        var additionalItems = new Dictionary<string, string>
        {
            { "key4", "value4" },
            { "key5", "value5" },
        };

        Dictionary.Merge(additionalItems);
        
        await Assert
            .That(Dictionary)
            .ContainsKey("key4")
            .And
            .ContainsValue("value4");
        
        await Assert
            .That(Dictionary)
            .ContainsKey("key5")
            .And
            .ContainsValue("value5");
    }
}