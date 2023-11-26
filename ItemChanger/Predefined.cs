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
        // Spells and their upgrades
        {"Hookshot", HookshotItem.Instance},
        {"Fire", FireItem.Instance},
        {"Bomb", BombItem.Instance},
        {"Arrow_Upgrade", ArrowUpgradeItem.Instance},

        // Weapons
        {"Rogue_Daggers", new CountableInventoryItem {
            DisplayName = "Rogue Daggers",
            UniqueId = "daggers",
            CountId = "weapons_count"
        }},
        {"Umbrella", new CountableInventoryItem {
            DisplayName = "Discarded Umbrella",
            UniqueId = "umbrella",
            CountId = "weapons_count"
        }},
        {"Reaper's_Greatsword", new CountableInventoryItem {
            DisplayName = "Reaper's Greatsword",
            UniqueId = "sword_heavy",
            CountId = "weapons_count"
        }},
        {"Thunder_Hammer", new CountableInventoryItem {
            DisplayName = "Thunder Hammer",
            UniqueId = "hammer",
            CountId = "weapons_count"
        }},

        // Giant Souls
        {"Giant_Soul_of_The_Urn_Witch", new CountableInventoryItem {
            DisplayName = "Giant Soul of The Urn Witch",
            UniqueId = "soul_gran", 
            CountId = "boss_souls"
        }},
        {"Giant_Soul_of_The_Frog_King", new CountableInventoryItem {
            DisplayName = "Giant Soul of The Frog King", 
            UniqueId = "soul_frog",
            CountId = "boss_souls"
        }},
        {"Giant_Soul_of_Betty", new CountableInventoryItem {
            DisplayName = "Giant Soul of Betty",
            UniqueId = "soul_yeti",
            CountId = "boss_souls"
        }},

        // Shards
        {"Vitality_Shard", VitalityShardItem.Instance},
        {"Magic_Shard", MagicShardItem.Instance},

        // Shiny Things
        {"Engagement_Ring", new CountableInventoryItem {
            DisplayName = "Engagement Ring",
            UniqueId = "trinket_ring",
            CountId = "trinket_collect_count"
        }},
        {"Old_Compass", new CountableInventoryItem {
            DisplayName = "Old Compass",
            UniqueId = "trinket_compass",
            CountId = "trinket_collect_count"
        }},
        {"Incense", new CountableInventoryItem {
            DisplayName = "Incense",
            UniqueId = "trinket_incense",
            CountId = "trinket_collect_count"
        }},
        {"Undying_Blossom", new CountableInventoryItem {
            DisplayName = "Undying Blossom",
            UniqueId = "trinket_flower",
            CountId = "trinket_collect_count"
        }},
        {"Old_Photograph", new CountableInventoryItem {
            DisplayName = "Old Photograph",
            UniqueId = "trinket_photo",
            CountId = "trinket_collect_count"
        }},
        {"Sludge-Filled_Urn", new CountableInventoryItem {
            DisplayName = "Sludge-Filled Urn",
            UniqueId = "trinket_elixir",
            CountId = "trinket_collect_count"
        }},
        {"Token_of_Death", new CountableInventoryItem {
            DisplayName = "Token of Death",
            UniqueId = "trinket_coin",
            CountId = "trinket_collect_count"
        }},
        {"Rusty_Garden_Trowel", new CountableInventoryItem {
            DisplayName = "Rusty Garden Trowel",
            UniqueId = "trinket_trowel",
            CountId = "trinket_collect_count"
        }},
        {"Captain's_Log", new CountableInventoryItem {
            DisplayName = "Captain's Log",
            UniqueId = "trinket_journal",
            CountId = "trinket_collect_count"
        }},
        {"Giant_Arrowhead", new CountableInventoryItem {
            DisplayName = "Giant Arrowhead",
            UniqueId = "trinket_arrow",
            CountId = "trinket_collect_count"
        }},
        {"Malformed_Seed", new CountableInventoryItem {
            DisplayName = "Malformed Seed",
            UniqueId = "trinket_seed",
            CountId = "trinket_collect_count"
        }},
        {"Corrupted_Antler", new CountableInventoryItem {
            DisplayName = "Corrupted Antler",
            UniqueId = "trinket_antler",
            CountId = "trinket_collect_count"
        }},
        {"Magical_Forest_Horn", new CountableInventoryItem {
            DisplayName = "Magical Forest Horn",
            UniqueId = "trinket_basoon",
            CountId = "trinket_collect_count"
        }},
        {"Ancient_Crown", new CountableInventoryItem {
            DisplayName = "Ancient Crown",
            UniqueId = "trinket_crown",
            CountId = "trinket_collect_count"
        }},
        {"Grunt's_Old_Mask", new CountableInventoryItem {
            DisplayName = "Grunt's Old Mask",
            UniqueId = "trinket_mask",
            CountId = "trinket_collect_count"
        }},
        {"Ancient_Door_Scale_Model", new CountableInventoryItem {
            DisplayName = "Ancient Door Scale Model",
            UniqueId = "trinket_door_old",
            CountId = "trinket_collect_count"
        }},
        {"Modern_Door_Scale_Model", new CountableInventoryItem {
            DisplayName = "Modern Door Scale Model",
            UniqueId = "trinket_door_new",
            CountId = "trinket_collect_count"
        }},
        {"Rusty_Belltower_Key", new CountableInventoryItem {
            DisplayName = "Rusty Belltower Key",
            UniqueId = "trinket_rusty_key",
            CountId = "trinket_collect_count"
        }},
        {"Surveillance_Device", new CountableInventoryItem {
            DisplayName = "Surveillance Device",
            UniqueId = "trinket_surv",
            CountId = "trinket_collect_count"
        }},
        {"Shiny_Medallion", new CountableInventoryItem {
            DisplayName = "Shiny Medallion",
            UniqueId = "trinket_medal",
            CountId = "trinket_collect_count"
        }},
        {"Ink-Covered_Teddy_Bear", new CountableInventoryItem {
            DisplayName = "Ink-Covered Teddy Bear",
            UniqueId = "trinket_teddy",
            CountId = "trinket_collect_count"
        }},
        {"Death's_Contract", new CountableInventoryItem {
            DisplayName = "Death's Contract",
            UniqueId = "trinket_contract",
            CountId = "trinket_collect_count"
        }},
        {"Makeshift_Soul_Key", new CountableInventoryItem {
            DisplayName = "Makeshift Soul Key",
            UniqueId = "trinket_soulkey",
            CountId = "trinket_collect_count"
        }},
        {"Mysterious_Locket", new CountableInventoryItem {
            DisplayName = "Mysterious Locket",
            UniqueId = "trinket_locket",
            CountId = "trinket_collect_count"
        }},

        // Seeds
        {"Life_Seed", SeedItem.Instance},

        // Soul Orbs
        {"100_Souls", new SoulsItem { Amount = 100 }},

        // Tablets
        {"Red_Ancient_Tablet_of_Knowledge", new CountableInventoryItem {
            DisplayName = "Red Ancient Tablet of Knowledge",
            UniqueId = "truthtablet_1",
            CountId = "truth_tablet_count"
        }},
        {"Yellow_Ancient_Tablet_of_Knowledge", new CountableInventoryItem {
            DisplayName = "Yellow Ancient Tablet of Knowledge",
            UniqueId = "truthtablet_2",
            CountId = "truth_tablet_count"
        }},
        {"Green_Ancient_Tablet_of_Knowledge", new CountableInventoryItem {
            DisplayName = "Green Ancient Tablet of Knowledge",
            UniqueId = "truthtablet_3",
            CountId = "truth_tablet_count"
        }},
        {"Cyan_Ancient_Tablet_of_Knowledge", new CountableInventoryItem {
            DisplayName = "Cyan Ancient Tablet of Knowledge",
            UniqueId = "truthtablet_4",
            CountId = "truth_tablet_count"
        }},
        {"Blue_Ancient_Tablet_of_Knowledge", new CountableInventoryItem {
            DisplayName = "Blue Ancient Tablet of Knowledge",
            UniqueId = "truthtablet_5",
            CountId = "truth_tablet_count"
        }},
        {"Purple_Ancient_Tablet_of_Knowledge", new CountableInventoryItem {
            DisplayName = "Purple Ancient Tablet of Knowledge",
            UniqueId = "truthtablet_6",
            CountId = "truth_tablet_count"
        }},
        {"Pink_Ancient_Tablet_of_Knowledge", new CountableInventoryItem {
            DisplayName = "Pink Ancient Tablet of Knowledge",
            UniqueId = "truthtablet_7",
            CountId = "truth_tablet_count"
        }},

        // Levers
        {"Hookshot_Silent_Servant_Lever", new KeyItem { UniqueId = "lever_connectcave", DisplayName = "Hookshot Silent Servant Lever" }},
        {"Greatsword_Lever", new KeyItem { UniqueId = "sailorgate", DisplayName = "Greatsword Lever" }},
        {"Stranded_Sailor_Upper_Shrine_Lever", new KeyItem { UniqueId = "lever_sailorturncam1", DisplayName = "Stranded Sailor Upper Shrine Lever" }},

        // Doors
        {"Grove_of_Spirits_Door", new KeyItem { UniqueId = "sdoor_tutorial", DisplayName = "Grove of Spirits Door" }},
        {"Lost_Cemetery_Door", new KeyItem { UniqueId = "sdoor_graveyard", DisplayName = "Lost Cemetery Door" }},
        {"Stranded_Sailor_Door", new KeyItem { UniqueId = "sdoor_sailor", DisplayName = "Stranded Sailor Door" }},
        {"Castle_Lockstone_Door", new KeyItem { UniqueId = "sdoor_fortress", DisplayName = "Castle Lockstone Door" }},
        {"Camp_of_the_Free_Crows_Door", new KeyItem { UniqueId = "sdoor_covenant", DisplayName = "Camp of the Free Crows Door" }},
        {"Old_Watchtowers_Door", new KeyItem { UniqueId = "sdoor_mountaintops", DisplayName = "Old Watchtowers Door" }},
        {"Betty's_Lair_Door", new KeyItem { UniqueId = "sdoor_betty", DisplayName = "Betty's Lair Door" }},
        {"Overgrown_Ruins_Door", new KeyItem { UniqueId = "sdoor_forest", DisplayName = "Overgrown Ruins Door" }},
        {"Mushroom_Dungeon_Door", new KeyItem { UniqueId = "sdoor_forest_dung", DisplayName = "Mushroom Dungeon Door" }},
        {"Flooded_Fortress_Door", new KeyItem { UniqueId = "sdoor_swamp", DisplayName = "Flooded Fortress Door" }},
        {"Throne_of_the_Frog_King_Door", new KeyItem { UniqueId = "sdoor_frogboss", DisplayName = "Throne of the Frog King Door" }},
        {"Estate_of_the_Urn_Witch_Door", new KeyItem { UniqueId = "sdoor_gardens", DisplayName = "Estate of the Urn Witch Door" }},
        {"Ceramic_Manor_Door", new KeyItem { UniqueId = "sdoor_mansion", DisplayName = "Ceramic Manor Door" }},
        {"Inner_Furnace_Door", new KeyItem { UniqueId = "sdoor_basementromp", DisplayName = "Inner Furnace Door" }},
        {"The_Urn_Witch's_Laboratory_Door", new KeyItem { UniqueId = "sdoor_grandmaboss", DisplayName = "The Urn Witch's Laboratory Door" }},
    };

    public static Item Item(string name)
    {
        return predefinedItems[name];
    }
}