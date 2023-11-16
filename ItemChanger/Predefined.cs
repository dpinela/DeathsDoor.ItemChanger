using Collections = System.Collections.Generic;

namespace DDoorItemChanger;

public static class Predefined
{
    private static readonly Collections.Dictionary<string, Location> predefinedLocations = new()
    {
        {"Discarded_Umbrella", new DropLocation { UniqueId = "umbrella" }}
    };

    public static Location Location(string name)
    {
        return predefinedLocations[name];
    }

    private static readonly Collections.Dictionary<string, Item> predefinedItems = new()
    {
        {"Hookshot", HookshotItem.Instance}
    };

    public static Item Item(string name)
    {
        return predefinedItems[name];
    }
}