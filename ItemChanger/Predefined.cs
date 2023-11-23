using Collections = System.Collections.Generic;

namespace DDoorItemChanger;

public static class Predefined
{
    private static readonly Collections.Dictionary<string, Location> predefinedLocations = new()
    {
        {"Discarded_Umbrella", new DropLocation { UniqueId = "umbrella" }},
        {"100_Souls-Hall_of_Doors_(Hookshot_Secret)", new DropLocation { UniqueId = "dropsoul_hodhookshotsecret" }},
        {"Seed-Stranded_Sailor_(Cave)", new DropLocation { UniqueId = "seed_cavescrate" }},
        {"Seed-Stranded Sailor_(Mountain)", new DropLocation { UniqueId = "seed_sailormountain" }},

        {"Betty", new CutsceneItemLocation { ItemId = "soul_yeti" }},
        {"Frog_King", new CutsceneItemLocation { ItemId = "soul_frog" }},
        {"Grandma", new CutsceneItemLocation { ItemId = "soul_gran" }},

        {"Fire_Avarice", new AvariceLocation { PowerId = "fire" }},
        {"Bomb_Avarice", new AvariceLocation { PowerId = "bombs" }},
        {"Hookshot_Avarice", new AvariceLocation { PowerId = "hookshot" }},

        {"Hookshot_Silent_Servant", new SpellUpgradeLocation { UpgradeKey = "hookshot" }},

        {"Magic_Shrine_(Forest_Turn_Cam)", new ShrineLocation { UniqueId = "shrine_forestturncam" }},

        {"Hookshot_Silent_Servant_Lever", new FrogLeverLocation { UniqueId = "lever_connectcave" }},
        {"Greatsword_Lever", new IronLeverLocation { UniqueId = "sailorgate" }},

        {"Grove_of_Spirits_Door", new DoorLocation { KeyId = "sdoor_tutorial" }},
        {"Mushroom_Dungeon_Door", new DoorLocation { KeyId = "sdoor_forest_dung" }},
    };

    public static Location Location(string name)
    {
        return predefinedLocations[name];
    }

    private static readonly Collections.Dictionary<string, Item> predefinedItems = new()
    {
        {"Hookshot", HookshotItem.Instance},
        {"Fire", FireItem.Instance},

        {"Giant_Soul_of_The_Urn_Witch", new GiantSoulItem {
            DisplayName = "Giant Soul of The Urn Witch", ItemId = "soul_gran"
        }},
        {"Giant_Soul_of_The_Frog_King", new GiantSoulItem {
            DisplayName = "Giant Soul of The Frog King", ItemId = "soul_frog"
        }},
        {"Giant_Soul_of_Betty", new GiantSoulItem {
            DisplayName = "Giant Soul of Betty", ItemId = "soul_yeti"
        }},

        {"Hookshot_Silent_Servant_Lever", new KeyItem { UniqueId = "lever_connectcave", DisplayName = "Hookshot Silent Servant Lever" }},
        {"Greatsword_Lever", new KeyItem { UniqueId = "sailorgate", DisplayName = "Greatsword Lever" }},
        {"Stranded_Sailor_Upper_Shrine_Lever", new KeyItem { UniqueId = "lever_sailorturncam1", DisplayName = "Stranded Sailor Upper Shrine Lever" }},

        {"Mushroom_Dungeon_Door", new KeyItem { UniqueId = "sdoor_forest_dung", DisplayName = "Mushroom Dungeon Door" }},
        {"Grove_of_Spirits_Door", new KeyItem { UniqueId = "sdoor_tutorial", DisplayName = "Grove of Spirits Door" }},
    };

    public static Item Item(string name)
    {
        return predefinedItems[name];
    }
}