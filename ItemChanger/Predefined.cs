using Collections = System.Collections.Generic;

namespace DDoorItemChanger;

public static class Predefined
{
    private static readonly Collections.Dictionary<string, Location> predefinedLocations = new()
    {
        {"Discarded_Umbrella", new DropLocation { UniqueId = "umbrella" }},
        {"100_Souls-Hall_of_Doors_(Hookshot_Secret)", new DropLocation { UniqueId = "dropsoul_hodhookshotsecret" }},

        {"Betty", new CutsceneItemLocation { ItemId = "soul_yeti" }},
        {"Frog_King", new CutsceneItemLocation { ItemId = "soul_frog" }},
        {"Grandma", new CutsceneItemLocation { ItemId = "soul_gran" }},

        {"Fire_Avarice", new AvariceLocation { PowerId = "fire" }},
        {"Bomb_Avarice", new AvariceLocation { PowerId = "bombs" }},
        {"Hookshot_Avarice", new AvariceLocation { PowerId = "hookshot" }},

        {"Magic_Shrine_(Forest_Turn_Cam)", new ShrineLocation { UniqueId = "shrine_forestturncam" }},
    };

    public static Location Location(string name)
    {
        return predefinedLocations[name];
    }

    private static readonly Collections.Dictionary<string, Item> predefinedItems = new()
    {
        {"Hookshot", HookshotItem.Instance},
        {"Giant_Soul_of_The_Urn_Witch", new GiantSoulItem {
            DisplayName = "Giant Soul of The Urn Witch", ItemId = "soul_gran"
        }},
        {"Giant_Soul_of_The_Frog_King", new GiantSoulItem {
            DisplayName = "Giant Soul of The Frog King", ItemId = "soul_frog"
        }},
        {"Giant_Soul_of_Betty", new GiantSoulItem {
            DisplayName = "Giant Soul of Betty", ItemId = "soul_yeti"
        }},
    };

    public static Item Item(string name)
    {
        return predefinedItems[name];
    }
}