using Collections = System.Collections.Generic;
using CA = System.Diagnostics.CodeAnalysis;
using static System.Linq.Enumerable;

namespace DDoor.ItemChanger;

public static class Predefined
{
    // Item and location names contributed by MrKoiCarp and
    // TheDancingGrad, as well as myself.
    private static readonly Collections.Dictionary<string, Location> predefinedLocations = new()
    {
        // Spells and their upgrades
        {"Fire Avarice", new AvariceLocation { PowerId = "fire" }},
        {"Bomb Avarice", new AvariceLocation { PowerId = "bombs" }},
        {"Hookshot Avarice", new AvariceLocation { PowerId = "hookshot" }},
        {"Fire Silent Servant", new SpellUpgradeLocation { UpgradeKey = "fire" }},
        {"Bomb Silent Servant", new SpellUpgradeLocation { UpgradeKey = "bombs" }},
        {"Hookshot Silent Servant", new SpellUpgradeLocation { UpgradeKey = "hookshot" }},
        {"Arrow Silent Servant", new SpellUpgradeLocation { UpgradeKey = "arrows" }},

        // Weapons
        {"Rogue Daggers", new DropLocation { UniqueId = "daggers", Area = Area.Estate }},
        {"Discarded Umbrella", new DropLocation { UniqueId = "umbrella", Area = Area.HallOfDoors }},
        {"Reaper's Greatsword", new DropLocation { UniqueId = "sword_heavy", Area = Area.Sailor }},
        {"Thunder Hammer", new DropLocation { UniqueId = "hammer", Area = Area.Dungeon }},

        // Giant Souls
        {"Betty", new CutsceneItemLocation { ItemId = "soul_yeti", Area = Area.Betty }},
        {"Frog King", new CutsceneItemLocation { ItemId = "soul_frog", Area = Area.FrogKing }},
        {"Grandma", new CutsceneItemLocation { ItemId = "soul_gran", Area = Area.Grandma }},

        // Shrines
        {"Heart Shrine-Cemetery Behind Entrance", new ShrineLocation { UniqueId = "shrine_graveyardhookshot", Area = Area.Cemetery }},
        {"Magic Shrine-Cemetery After Smough Arena", new ShrineLocation { UniqueId = "shrine_graveyardbomb", Area = Area.Cemetery }},
        {"Heart Shrine-Cemetery Winding Bridge End", new ShrineLocation { UniqueId = "shrine_graveyardturncam", Area = Area.Cemetery }},
        {"Heart Shrine-Hookshot Arena", new ShrineLocation { UniqueId = "shrine_sailorhookshot", Area = Area.Sailor }},
        {"Magic Shrine-Sailor Turncam", new ShrineLocation { UniqueId = "shrine_sailorturncam", Area = Area.Sailor }},
        {"Magic Shrine-Lockstone Secret West", new ShrineLocation { UniqueId = "shrine_fortress", Area = Area.Lockstone }},
        {"Heart Shrine-Camp Ice Skating", new ShrineLocation { UniqueId = "shrine_icechallenge", Area = Area.Camp }},
        {"Magic Shrine-Ruins Hookshot Arena", new ShrineLocation { UniqueId = "shrine_foresthookshot", Area = Area.Ruins }},
        {"Magic Shrine-Ruins Turncam", new ShrineLocation { UniqueId = "shrine_forestturncam", Area = Area.Ruins }},
        {"Heart Shrine-Dungeon Water Arena", new ShrineLocation { UniqueId = "shrine_dungeonbomb", Area = Area.Dungeon }},
        {"Heart Shrine-Ruins Sewer", new ShrineLocation { UniqueId = "shrine_forestsewer", Area = Area.Ruins }},
        {"Magic Shrine-Fortress Bow Secret", new ShrineLocation { UniqueId = "shrine_swamp", Area = Area.Fortress }},
        {"Magic Shrine-Estate Left of Manor", new ShrineLocation { UniqueId = "shrine_gardenturncam", Area = Area.Estate }},
        {"Heart Shrine-Garden of Life", new ShrineLocation { UniqueId = "shrine_gardendrop", Area = Area.Estate }},
        {"Magic Shrine-Manor Bathroom Puzzle", new ShrineLocation { UniqueId = "shrine_mansionreflection", Area = Area.Manor }},
        {"Heart Shrine-Furnace Cart Puzzle", new ShrineLocation { UniqueId = "shrine_basement", Area = Area.OuterFurnace }},

        // Shiny Things
        {"Engagement Ring", new DropLocation { UniqueId = "trinket_ring", Area = Area.Manor }},
        {"Old Compass", new DropLocation { UniqueId = "trinket_compass", Area = Area.Cemetery }},
        {"Incense", new DropLocation { UniqueId = "trinket_incense", Area = Area.Cemetery }},
        {"Undying Blossom", new DropLocation { UniqueId = "trinket_flower", Area = Area.Cemetery }},
        {"Old Photograph", new DropLocation { UniqueId = "trinket_photo", Area = Area.Manor }},
        {"Sludge-Filled Urn", new DropLocation { UniqueId = "trinket_elixir", Area = Area.Estate }},
        {"Token of Death", new DropLocation { UniqueId = "trinket_coin", Area = Area.Cemetery }},
        {"Rusty Garden Trowel", new DropLocation { UniqueId = "trinket_trowel", Area = Area.Estate }},
        {"Captain's Log", new DropLocation { UniqueId = "trinket_journal", Area = Area.Sailor }},
        {"Giant Arrowhead", new DropLocation { UniqueId = "trinket_arrow", Area = Area.FrogKing }},
        {"Malformed Seed", new DropLocation { UniqueId = "trinket_seed", Area = Area.Ruins }},
        {"Corrupted Antler", new DropLocation { UniqueId = "trinket_antler", Area = Area.Dungeon }},
        {"Magical Forest Horn", new DropLocation { UniqueId = "trinket_basoon", Area = Area.Ruins }},
        {"Ancient Crown", new DropLocation { UniqueId = "trinket_crown", Area = Area.Lockstone }},
        {"Grunt's Old Mask", new DropLocation { UniqueId = "trinket_mask", Area = Area.Sailor }},
        {"Ancient Door Scale Model", new DropLocation { UniqueId = "trinket_door_old", Area = Area.HallOfDoors }},
        {"Modern Door Scale Model", new DropLocation { UniqueId = "trinket_door_new", Area = Area.HallOfDoors }},
        {"Rusty Belltower Key", new DropLocation { UniqueId = "trinket_rusty_key", Area = Area.HallOfDoors }},
        {"Surveillance Device", new DropLocation { UniqueId = "trinket_surv", Area = Area.HallOfDoors }},
        {"Shiny Medallion", new DropLocation { UniqueId = "trinket_medal", Area = Area.Camp }},
        {"Ink-Covered Teddy Bear", new DropLocation { UniqueId = "trinket_teddy", Area = Area.Sailor }},
        {"Death's Contract", new DropLocation { UniqueId = "trinket_contract", Area = Area.Lockstone }},
        {"Makeshift Soul Key", new DropLocation { UniqueId = "trinket_soulkey", Area = Area.Grove }},
        {"Mysterious Locket", new DropLocation { UniqueId = "trinket_locket", Area = Area.Watchtowers }},

        // Seeds
        {"Seed-Cemetery Broken Bridge", new DropLocation { UniqueId = "seed_graveyardbrokenbridge", Area = Area.Cemetery }},
        {"Seed-Catacombs Tower", new DropLocation { UniqueId = "seed_graveyardtower", Area = Area.Cemetery }},
        {"Seed-Cemetery Left of Main Entrance", new DropLocation { UniqueId = "seed_graveyardbuilding", Area = Area.Cemetery }},
        {"Seed-Cemetery Near Tablet Gate", new DropLocation { UniqueId = "seed_graveyardcliff", Area = Area.Cemetery }},
        {"Seed-Between Cemetery and Sailor", new DropLocation { UniqueId = "seed_cavescrate", Area = Area.Cemetery }},
        {"Seed-Sailor Upper", new DropLocation { UniqueId = "seed_sailormountain", Area = Area.Sailor }},
        {"Seed-Lockstone Upper East", new DropLocation { UniqueId = "seed_castlegardeneast", Area = Area.Lockstone }},
        {"Seed-Lockstone Soul Door", new DropLocation { UniqueId = "seed_castledoor", Area = Area.Lockstone }},
        {"Seed-Lockstone Behind Bars", new DropLocation { UniqueId = "seed_castleelevator", Area = Area.Lockstone }},
        {"Seed-Lockstone Entrance West", new DropLocation { UniqueId = "seed_castlegardenwest", Area = Area.Lockstone }},
        {"Seed-Lockstone North", new DropLocation { UniqueId = "seed_castleeast", Area = Area.Lockstone }},
        {"Seed-Camp Ledge With Huts", new DropLocation { UniqueId = "seed_crowcavesledge", Area = Area.Camp }},
        {"Seed-Camp Stall", new DropLocation { UniqueId = "seed_crowcampstall", Area = Area.Camp }},
        {"Seed-Camp Rooftops", new DropLocation { UniqueId = "seed_fortressexteriorcrate", Area = Area.Camp }},
        {"Seed-Watchtowers Ice Skating", new DropLocation { UniqueId = "seed_mountaintopsice", Area = Area.Watchtowers }},
        {"Seed-Watchtowers Tablet Door", new DropLocation { UniqueId = "seed_mountaintopstruth", Area = Area.Watchtowers }},
        {"Seed-Watchtowers Archer Platform", new DropLocation { UniqueId = "seed_mountaintopshookshot", Area = Area.Watchtowers }},
        {"Seed-Watchtowers Boxes", new DropLocation { UniqueId = "seed_mountaintopsroute1", Area = Area.Watchtowers }},
        {"Seed-Dungeon Fire Puzzle Near Water Arena", new DropLocation { UniqueId = "seed_dungeonconnect", Area = Area.Dungeon }},
        {"Seed-Ruins Lord of Doors Arena", new DropLocation { UniqueId = "seed_forestgargoyle", Area = Area.Ruins }},
        {"Seed-Ruins Fire Plant Corridor", new DropLocation { UniqueId = "seed_forestcorridor", Area = Area.Ruins }},
        {"Seed-Dungeon Water Arena Left Exit", new DropLocation { UniqueId = "seed_dungeontwindoor", Area = Area.Dungeon }},
        {"Seed-Ruins Right Middle", new DropLocation { UniqueId = "seed_forestmiddle", Area = Area.Ruins }},
        {"Seed-Ruins On Settlement Wall", new DropLocation { UniqueId = "seed_forestvillage", Area = Area.Ruins }},
        {"Seed-Ruins Behind Boxes", new DropLocation { UniqueId = "seed_forestintro", Area = Area.Ruins }},
        {"Seed-Ruins Down Through Bomb Wall", new DropLocation { UniqueId = "seed_forestdrop", Area = Area.Ruins }},
        {"Seed-Dungeon Above Rightmost Crow", new DropLocation { UniqueId = "seed_dungeoneastexit", Area = Area.Dungeon }},
        {"Seed-Dungeon Right Above Key", new DropLocation { UniqueId = "seed_dungeonprisonbreak", Area = Area.Dungeon }},
        {"Seed-Dungeon Avarice Bridge", new DropLocation { UniqueId = "seed_dungeonbridge", Area = Area.Dungeon }},
        {"Seed-Fortress Watchtower", new DropLocation { UniqueId = "seed_swampwatchtower", Area = Area.Fortress }},
        {"Seed-Fortress Statue", new DropLocation { UniqueId = "seed_swampstatue", Area = Area.Fortress }},
        {"Seed-Fortress Bridge", new DropLocation { UniqueId = "seed_swampbridge", Area = Area.Fortress }},
        {"Seed-Fortress Intro Crate", new DropLocation { UniqueId = "seed_swampintrocrate", Area = Area.Fortress }},
        {"Seed-Fortress East After Statue", new DropLocation { UniqueId = "seed_swampintroeast", Area = Area.Fortress }},
        {"Seed-Estate Family Tomb", new DropLocation { UniqueId = "seed_gardennorthwest", Area = Area.Estate }},
        {"Seed-Estate Entrance", new DropLocation { UniqueId = "seed_gardenintrostart", Area = Area.Estate }},
        {"Seed-Estate Hedge Gaps", new DropLocation { UniqueId = "seed_gardenbush", Area = Area.Estate }},
        {"Seed-Garden of Joy", new DropLocation { UniqueId = "seed_gardensouthwest", Area = Area.Estate }},
        {"Seed-Manor Boxes", new DropLocation { UniqueId = "seed_mansionsquareroom", Area = Area.Manor }},
        {"Seed-Manor Near Brazier", new DropLocation { UniqueId = "seed_mansionrightshelves", Area = Area.Manor }},
        {"Seed-Manor Below Big Pot Arena", new DropLocation { UniqueId = "seed_ballroom", Area = Area.Manor }},
        {"Seed-Manor Rafters", new DropLocation { UniqueId = "seed_mansionattic", Area = Area.Manor }},
        {"Seed-Manor Main Room Upper", new DropLocation { UniqueId = "seed_mansioncentre", Area = Area.Manor }},
        {"Seed-Manor Spinny Pot Room", new DropLocation { UniqueId = "seed_mansionleftshelves", Area = Area.Manor }},
        {"Seed-Manor Library Shelf", new DropLocation { UniqueId = "seed_mansionlibraryshelves", Area = Area.Manor }},
        {"Seed-Cart Puzzle", new DropLocation { UniqueId = "seed_basementshrineabyss", Area = Area.OuterFurnace }},
        {"Seed-Furnace Entrance", new DropLocation { UniqueId = "seed_basementintro", Area = Area.OuterFurnace }},
        {"Seed-Inner Furnace Horizontal Pistons", new DropLocation { UniqueId = "seed_basementplague1", Area = Area.InnerFurnace }},
        {"Seed-Inner Furnace Conveyor Bridge", new DropLocation { UniqueId = "seed_basementconveyor", Area = Area.InnerFurnace }},
        {"Seed-Inner Furnace Conveyor Gauntlet", new DropLocation { UniqueId = "seed_basementplague2", Area = Area.InnerFurnace }},

        // Soul Orbs
        {"Soul Orb-Fire Return Upper", new DropLocation { UniqueId = "dropsoul_HoDfirereturn1", Area = Area.HallOfDoors }},
        {"Soul Orb-Hookshot Secret", new DropLocation { UniqueId = "dropsoul_hodhookshotsecret", Area = Area.HallOfDoors }},
        {"Soul Orb-Bomb Return", new DropLocation { UniqueId = "dropsoul_hodbombreturn", Area = Area.HallOfDoors }},
        {"Soul Orb-Bomb Secret", new DropLocation { UniqueId = "dropsoul_hodbombsecret", Area = Area.HallOfDoors }},
        {"Soul Orb-Hookshot Return", new DropLocation { UniqueId = "dropsoul_hookshotreturn", Area = Area.HallOfDoors }},
        {"Soul Orb-Fire Return Lower", new DropLocation { UniqueId = "dropsoul_hodfirereturn2", Area = Area.HallOfDoors }},
        {"Soul Orb-Fire Secret", new DropLocation { UniqueId = "dropsoul_hodfiresecret", Area = Area.HallOfDoors }},
        {"Soul Orb-Catacombs Exit", new DropLocation { UniqueId = "dropsoul_catacombsexit", Area = Area.Cemetery }},
        {"Soul Orb-Cemetery Hookshot Towers", new DropLocation { UniqueId = "dropsoul_graveyardhookshot", Area = Area.Cemetery }},
        {"Soul Orb-Cemetery Under Bridge", new DropLocation { UniqueId = "dropsoul_graveyardbridge", Area = Area.Cemetery }},
        {"Soul Orb-Cemetery East Tree", new DropLocation { UniqueId = "dropsoul_graveyardtree", Area = Area.Cemetery }},
        {"Soul Orb-Cemetery Winding Bridge End", new DropLocation { UniqueId = "dropsoul_graveyardbridgeroom", Area = Area.Cemetery }},
        {"Soul Orb-Catacombs Room 2", new DropLocation { UniqueId = "dropsoul_catacombs2", Area = Area.Cemetery }},
        {"Soul Orb-Catacombs Room 1", new DropLocation { UniqueId = "dropsoul_catacombs1", Area = Area.Cemetery }},
        {"Soul Orb-Cemetery Gated Sewer", new DropLocation { UniqueId = "dropsoul_graveyardsewer", Area = Area.Cemetery }},
        {"Soul Orb-Catacombs Entrance", new DropLocation { UniqueId = "dropsoul_catacombsentrance", Area = Area.Cemetery }},
        {"Soul Orb-Cemetery Cave", new DropLocation { UniqueId = "dropsoul_graveyardcave", Area = Area.Cemetery }},
        {"Soul Orb-Sailor Turncam", new DropLocation { UniqueId = "dropsoul_sailorturncam", Area = Area.Sailor }},
        {"Soul Orb-North Lockstone Sewer", new DropLocation { UniqueId = "dropsoul_castlesewer2", Area = Area.Lockstone }},
        {"Soul Orb-Lockstone Hookshot North", new DropLocation { UniqueId = "dropsoul_castlehookshoteast", Area = Area.Lockstone }},
        {"Soul Orb-Lockstone Exit", new DropLocation { UniqueId = "dropsoul_castleexit", Area = Area.Lockstone }},
        {"Soul Orb-West Lockstone Sewer", new DropLocation { UniqueId = "dropsoul_castlesewer1", Area = Area.Lockstone }},
        {"Soul Orb-Camp Rooftops", new DropLocation { UniqueId = "dropsoul_fortressexterior", Area = Area.Camp }},
        {"Soul Orb-Camp Broken Bridge", new DropLocation { UniqueId = "dropsoul_crowcavesbridge", Area = Area.Camp }},
        {"Soul Orb-Watchtowers Behind Barb Elevator", new DropLocation { UniqueId = "dropsoul_mountaintopsturncam", Area = Area.Watchtowers }},
        {"Soul Orb-Dungeon Vine", new DropLocation { UniqueId = "dropsoul_dungeonpeek", Area = Area.Dungeon }},
        {"Soul Orb-Ruins Stump", new DropLocation { UniqueId = "dropsoul_forestcolliseumhookshot", Area = Area.Ruins }},
        {"Soul Orb-Ruins Outside Left Dungeon Exit", new DropLocation { UniqueId = "dropsoul_forestraised", Area = Area.Ruins }},
        {"Soul Orb-Dungeon Cobweb", new DropLocation { UniqueId = "dropsoul_dungeoncobweb", Area = Area.Dungeon }},
        {"Soul Orb-Ruins Left After Key Door", new DropLocation { UniqueId = "dropsoul_forestcorner", Area = Area.Ruins }},
        {"Soul Orb-Ruins Lower Bomb Wall", new DropLocation { UniqueId = "dropsoul_forestblocked", Area = Area.Ruins }},
        {"Soul Orb-Ruins Lord of Doors Arena Hookshot", new DropLocation { UniqueId = "dropsoul_forestnorthhookshot", Area = Area.Ruins }},
        {"Soul Orb-Dungeon Lower Entrance", new DropLocation { UniqueId = "dropsoul_swamproute", Area = Area.Dungeon }},
        {"Soul Orb-Ruins Upper Above Horn", new DropLocation { UniqueId = "dropsoul_forestcolliseum", Area = Area.Ruins }},
        {"Soul Orb-Ruins Above Three Plants", new DropLocation { UniqueId = "dropsoul_forestvine", Area = Area.Ruins }},
        {"Soul Orb-Ruins Up Turncam Ladder", new DropLocation { UniqueId = "dropsoul_forestladder", Area = Area.Ruins }},
        {"Soul Orb-Ruins Above Entrance Gate", new DropLocation { UniqueId = "dropsoul_forestentrancewall", Area = Area.Ruins }},
        {"Soul Orb-Ruins Upper Bomb Wall", new DropLocation { UniqueId = "dropsoul_forestbomber", Area = Area.Ruins }},
        {"Soul Orb-Dungeon Left Exit Shelf", new DropLocation { UniqueId = "dropsoul_dungeonshelfdrop", Area = Area.Dungeon }},
        {"Soul Orb-Ruins Lower Hookshot", new DropLocation { UniqueId = "dropsoul_forestintrohookshot", Area = Area.Ruins }},
        {"Soul Orb-Fortress Bomb", new DropLocation { UniqueId = "dropsoul_swampbomb", Area = Area.Fortress }},
        {"Soul Orb-Fortress Hidden Sewer", new DropLocation { UniqueId = "dropsoul_swampsewer", Area = Area.Fortress }},
        {"Soul Orb-Fortress Drop", new DropLocation { UniqueId = "dropsoul_swampdrop", Area = Area.Fortress }},
        {"Soul Orb-Estate Access Crypt", new DropLocation { UniqueId = "dropsoul_cryptgrave", Area = Area.Cemetery }},
        {"Soul Orb-Estate Balcony", new DropLocation { UniqueId = "dropsoul_gardenbalcony", Area = Area.Estate }},
        {"Soul Orb-Garden of Love Turncam", new DropLocation { UniqueId = "dropsoul_gardenturncam", Area = Area.Estate }},
        {"Soul Orb-Garden of Life Hookshot Loop", new DropLocation { UniqueId = "dropsoul_gardennorthhookshot", Area = Area.Estate }},
        {"Soul Orb-Garden of Love Bomb Walls", new DropLocation { UniqueId = "dropsoul_familytombbomb", Area = Area.Estate }},
        {"Soul Orb-Garden of Life Bomb Wall", new DropLocation { UniqueId = "dropsoul_gardenknight", Area = Area.Estate }},
        {"Soul Orb-Estate Broken Boardwalk", new DropLocation { UniqueId = "dropsoul_gardensouthhookshot", Area = Area.Estate }},
        {"Soul Orb-Estate Secret Cave", new DropLocation { UniqueId = "dropsoul_gardencave", Area = Area.Estate }},
        {"Soul Orb-Estate Twin Benches", new DropLocation { UniqueId = "dropsoul_gardensbenches", Area = Area.Estate }},
        {"Soul Orb-Estate Sewer Middle", new DropLocation { UniqueId = "dropsoul_gardensewerroute1", Area = Area.Estate }},
        {"Soul Orb-Estate Sewer End", new DropLocation { UniqueId = "dropsoul_gardensewerroute2", Area = Area.Estate }},
        {"Soul Orb-Garden of Peace", new DropLocation { UniqueId = "dropsoul_gardensouthbomb", Area = Area.Estate }},
        {"Soul Orb-Manor Imp Loft", new DropLocation { UniqueId = "dropsoul_mansionladder", Area = Area.Manor }},
        {"Soul Orb-Manor Library Shelf", new DropLocation { UniqueId = "dropsoul_mansionlibrary", Area = Area.Manor }},
        {"Soul Orb-Manor Chandelier", new DropLocation { UniqueId = "chand_souls", Area = Area.Manor }},
        {"Soul Orb-Furnace Lantern Chain", new DropLocation { UniqueId = "dropsoul_basementlanternchain", Area = Area.
        OuterFurnace }},
        {"Soul Orb-Small Room", new DropLocation { UniqueId = "dropsoul_basementsmallroom", Area = Area.OuterFurnace }},
        {"Soul Orb-Furnace Entrance Sewer", new DropLocation { UniqueId = "dropsoul_basementsewer", Area = Area.OuterFurnace }},

        // Tablets
        {"Red Ancient Tablet of Knowledge", new DropLocation { UniqueId = "truthtablet_1", Area = Area.Fortress }},
        {"Yellow Ancient Tablet of Knowledge", new DropLocation { UniqueId = "truthtablet_2", Area = Area.Ruins }},
        {"Green Ancient Tablet of Knowledge", new DropLocation { UniqueId = "truthtablet_3", Area = Area.Estate }},
        {"Cyan Ancient Tablet of Knowledge", new DropLocation { UniqueId = "truthtablet_4", Area = Area.Cemetery }},
        {"Blue Ancient Tablet of Knowledge", new DropLocation { UniqueId = "truthtablet_5", Area = Area.Watchtowers }},
        {"Purple Ancient Tablet of Knowledge", new DropLocation { UniqueId = "truthtablet_6", Area = Area.Cemetery }},
        {"Estate Owl", new DropLocation { UniqueId = "truthshard_1", Area = Area.Estate }},
        {"Ruins Owl", new DropLocation { UniqueId = "truthshard_2", Area = Area.Ruins }},
        {"Watchtowers Owl", new DropLocation { UniqueId = "truthshard_3", Area = Area.Watchtowers }},

        // Levers
        {"Lever-Bomb Exit", new FrogLeverLocation { UniqueId = "hod_frog_lever", Area = Area.HallOfDoors }},
        {"Lever-Cemetery Sewer", new FrogLeverLocation { UniqueId = "lever_graveyardsummiteast", Area = Area.Cemetery }},
        {"Lever-Guardian of the Door Access", new FrogLeverLocation { UniqueId = "lever_graveyardredeemer", Area = Area.Cemetery }},
        {"Lever-Cemetery Shortcut to East Tree", new FrogLeverLocation { UniqueId = "lever_graveyardforestroute", Area = Area.Cemetery }},
        {"Lever-Cemetery East Tree", new FrogLeverLocation { UniqueId = "lever_graveyardeast", Area = Area.Cemetery }},
        {"Lever-Catacombs Tower", new FrogLeverLocation { UniqueId = "lever_graveyardcentraltower", Area = Area.Cemetery }},
        {"Lever-Cemetery Exit to Estate", new FrogLeverLocation { UniqueId = "lever_graveyardsummitwest", Area = Area.Cemetery }},
        {"Lever-Catacombs Exit", new FrogLeverLocation { UniqueId = "lever_catacombsexit", Area = Area.Cemetery }},
        {"Lever-Hookshot Silent Servant", new FrogLeverLocation { UniqueId = "lever_connectcave", Area = Area.Cemetery }},
        {"Lever-Sailor Turncam Upper", new FrogLeverLocation { UniqueId = "lever_sailorturncam1", Area = Area.Sailor }},
        {"Lever-Sailor Turncam Lower", new FrogLeverLocation { UniqueId = "lever_sailorturncam2", Area = Area.Sailor }},
        {"Lever-Sailor Greatsword Gate", new IronLeverLocation { UniqueId = "sailorgate", Area = Area.Sailor }},
        {"Lever-Lockstone East Start Shortcut", new FrogLeverLocation { UniqueId = "fort_east_start", Area = Area.Lockstone }},
        {"Lever-Lockstone Entrance", new IronLeverLocation { UniqueId = "fort_gate_1", Area = Area.Lockstone }},
        {"Lever-Lockstone East Lower", new FrogLeverLocation { UniqueId = "fort_upper1", Area = Area.Lockstone }},
        {"Lever-Lockstone Upper Shortcut", new FrogLeverLocation { UniqueId = "fort_ladlev_2", Area = Area.Lockstone }},
        {"Lever-Lockstone Dual Laser Puzzle", new IronLeverLocation { UniqueId = "fort_gate_4", Area = Area.Lockstone }},
        {"Lever-Lockstone Tracking Beam Puzzle", new IronLeverLocation { UniqueId = "fort_gate_2", Area = Area.Lockstone }},
        {"Lever-Lockstone Vertical Laser Puzzle", new IronLeverLocation { UniqueId = "fort_gate_3", Area = Area.Lockstone }},
        {"Lever-Lockstone North Puzzle", new IronLeverLocation { UniqueId = "fort_gate_5", Area = Area.Lockstone }},
        {"Lever-Lockstone Shrine", new FrogLeverLocation { UniqueId = "lever_fortresssecretwest", Area = Area.Lockstone }},
        {"Lever-Lockstone Hookshot Puzzle", new IronLeverLocation { UniqueId = "fort_gate_8", Area = Area.Lockstone }},
        {"Lever-Lockstone Upper Puzzle", new IronLeverLocation { UniqueId = "fort_gate_upper", Area = Area.Lockstone }},
        {"Lever-Lockstone Upper Dual Laser Puzzle", new IronLeverLocation { UniqueId = "fort_gate_6", Area = Area.Lockstone }},
        {"Lever-Watchtowers Before Ice Arena", new FrogLeverLocation { UniqueId = "lever_mountaintopsshortcut2", Area = Area.Watchtowers }},
        {"Lever-Watchtowers After Ice Skating", new FrogLeverLocation { UniqueId = "lever_mountaintopsshortcut3", Area = Area.Watchtowers }},
        {"Lever-Watchtowers After Boomers", new FrogLeverLocation { UniqueId = "lever_mountaintopsshortcut1", Area = Area.Watchtowers }},
        {"Lever-Ruins Settlement Gate", new FrogLeverLocation { UniqueId = "forestoldsettlementgate", Area = Area.Ruins }},
        {"Lever-Ruins Upper Dungeon Entrance", new FrogLeverLocation { UniqueId = "colliseumsecret", Area = Area.Ruins }},
        {"Lever-Ruins Ladder Left of Lord of Doors Arena", new FrogLeverLocation { UniqueId = "fsettle_sc_1", Area = Area.Ruins }},
        {"Lever-Ruins Entrance Ladder Shortcut", new FrogLeverLocation { UniqueId = "forest_short1", Area = Area.Ruins }},
        {"Lever-Ruins Main Gate", new FrogLeverLocation { UniqueId = "forest_gate_lever", Area = Area.Ruins }},
        {"Lever-Dungeon Entrance Right Gate", new FrogLeverLocation { UniqueId = "jail2", Area = Area.Dungeon }},
        {"Lever-Dungeon Entrance Left Gate", new FrogLeverLocation { UniqueId = "jail1", Area = Area.Dungeon }},
        {"Lever-Dungeon Above Rightmost Crow", new FrogLeverLocation { UniqueId = "foresteastexit", Area = Area.Dungeon }},
        {"Lever-Fortress Bomb", new FrogLeverLocation { UniqueId = "swampladdershortcut2", Area = Area.Fortress }},
        {"Lever-Fortress Main Gate", new FrogLeverLocation { UniqueId = "swamp_enter_maingatelever", Area = Area.Fortress }},
        {"Lever-Fortress Central Shortcut", new FrogLeverLocation { UniqueId = "swampladdershortcut1", Area = Area.Fortress }},
        {"Lever-Fortress Statue", new FrogLeverLocation { UniqueId = "swampgateshortcut1", Area = Area.Fortress }},
        {"Lever-Fortress Watchtower Lower", new FrogLeverLocation { UniqueId = "swampladdershortcut4", Area = Area.Fortress }},
        {"Lever-Fortress Bridge", new FrogLeverLocation { UniqueId = "swampladdershortcut3", Area = Area.Fortress }},
        {"Lever-Fortress Pre-Main Gate", new FrogLeverLocation { UniqueId = "swampgateshortcut2", Area = Area.Fortress }},
        {"Lever-Fortress Watchtower Upper", new FrogLeverLocation { UniqueId = "swampladdershortcut5", Area = Area.Fortress }},
        {"Lever-Fortress North West", new FrogLeverLocation { UniqueId = "lever_swampnorthwest", Area = Area.Fortress }},
        {"Lever-Estate Elevator Left", new FrogLeverLocation { UniqueId = "crypt_exit1", Area = Area.Cemetery }},
        {"Lever-Estate Elevator Right", new FrogLeverLocation { UniqueId = "crypt_exit2", Area = Area.Cemetery }},
        {"Lever-Garden of Love", new FrogLeverLocation { UniqueId = "lever_gardennorthwest", Area = Area.Estate }},
        {"Lever-Garden of Life End", new FrogLeverLocation { UniqueId = "lever_gardennortheast", Area = Area.Estate }},
        {"Lever-Garden of Peace", new FrogLeverLocation { UniqueId = "Garden2End", Area = Area.Estate }},
        {"Lever-Garden of Joy", new FrogLeverLocation { UniqueId = "Garden1End", Area = Area.Estate }},
        {"Lever-Garden of Love Turncam", new FrogLeverLocation { UniqueId = "lever_gardenturncam", Area = Area.Estate }},
        {"Lever-Garden of Life Lanterns", new FrogLeverLocation { UniqueId = "garden4lantern", Area = Area.Estate }},
        {"Lever-Estate Underground Urn Shed", new FrogLeverLocation { UniqueId = "lever_Gardenselixir", Area = Area.Estate }},
        {"Lever-Manor Big Pot Arena", new FrogLeverLocation { UniqueId = "lever_dumbwaiter", Area = Area.Manor }},
        {"Lever-Manor Bookshelf Shortcut", new FrogLeverLocation { UniqueId = "mansionlibrarylever", Area = Area.Manor }},

        // Doors
        {"Grove of Spirits Door", new DoorLocation { KeyId = "sdoor_tutorial", Area = Area.HallOfDoors }},
        {"Lost Cemetery Door", new DoorLocation { KeyId = "sdoor_graveyard", Area = Area.Cemetery }},
        {"Stranded Sailor Door", new DoorLocation { KeyId = "sdoor_sailor", Area = Area.Sailor }},
        {"Castle Lockstone Door", new DoorLocation { KeyId = "sdoor_fortress", Area = Area.Lockstone }},
        {"Camp of the Free Crows Door", new DoorLocation { KeyId = "sdoor_covenant", Area = Area.Camp }},
        {"Old Watchtowers Door", new DoorLocation { KeyId = "sdoor_mountaintops", Area = Area.Watchtowers }},
        {"Betty's Lair Door", new DoorLocation { KeyId = "sdoor_betty", Area = Area.Betty }},
        {"Overgrown Ruins Door", new DoorLocation { KeyId = "sdoor_forest", Area = Area.Ruins }},
        {"Mushroom Dungeon Door", new DoorLocation { KeyId = "sdoor_forest_dung", Area = Area.Dungeon }},
        {"Flooded Fortress Door", new DoorLocation { KeyId = "sdoor_swamp", Area = Area.Fortress }},
        {"Throne of the Frog King Door", new DoorLocation { KeyId = "sdoor_frogboss", Area = Area.FrogKing }},
        {"Estate of the Urn Witch Door", new DoorLocation { KeyId = "sdoor_gardens", Area = Area.Estate }},
        {"Ceramic Manor Door", new DoorLocation { KeyId = "sdoor_mansion", Area = Area.Manor }},
        {"Inner Furnace Door", new DoorLocation { KeyId = "sdoor_basementromp", Area = Area.InnerFurnace }},
        {"The Urn Witch's Laboratory Door", new DoorLocation { KeyId = "sdoor_grandmaboss", Area = Area.Grandma }},

        // Keys
        {"Key-Cemetery Central", new KeyLocation { UniqueId = "collectablekey_graveyardroute1", Area = Area.Cemetery }},
        {"Key-Cemetery Grey Crow", new KeyLocation { UniqueId = "collectablekey_graveyardsummit", Area = Area.Cemetery }},
        {"Key-Camp of the Free Crows", new KeyLocation { UniqueId = "covenant_key", Area = Area.Camp }},
        {"Key-Lockstone West", new KeyLocation { UniqueId = "collectablekey_fortresswest", Area = Area.Lockstone }},
        {"Key-Lockstone North", new KeyLocation { UniqueId = "collectablekey_fortresseast", Area = Area.Lockstone }},
        {"Key-Overgrown Ruins", new KeyLocation { UniqueId = "forest_key_4", Area = Area.Ruins }},
        {"Key-Dungeon Hall", new KeyLocation { UniqueId = "forest_key_2", Area = Area.Dungeon }},
        {"Key-Dungeon Right", new KeyLocation { UniqueId = "forest_key_1", Area = Area.Dungeon }},
        {"Key-Dungeon Near Water Arena", new KeyLocation { UniqueId = "forest_key_3", Area = Area.Dungeon }},
        {"Key-Manor Under Dining Room", new KeyLocation { UniqueId = "mansion_key1", Area = Area.Manor }},
        {"Key-Manor After Spinny Pot Room", new KeyLocation { UniqueId = "mansion_key2", Area = Area.Manor }},
        {"Key-Manor Library", new KeyLocation { UniqueId = "collectablekey_mansion3", Area = Area.Manor }},

        // Crow Souls
        {"Crow-Manor After Torch Puzzle", new CrowSoulLocation { UniqueId = "crowskele_mansion_4", Area = Area.Manor }},
        {"Crow-Manor Imp Loft", new CrowSoulLocation { UniqueId = "crowskele_mansion_1", Area = Area.Manor }},
        {"Crow-Manor Library", new CrowSoulLocation { UniqueId = "crowskele_mansion_2", Area = Area.Manor }},
        {"Crow-Manor Bedroom", new CrowSoulLocation { UniqueId = "crowskele_mansion_3", Area = Area.Manor }},
        {"Crow-Dungeon Hall", new CrowSoulLocation { UniqueId = "crowskele_forest_4", Area = Area.Dungeon}},
        {"Crow-Dungeon Water Arena", new CrowSoulLocation { UniqueId = "crowskele_forest_1", Area = Area.Dungeon }},
        {"Crow-Dungeon Cobweb", new CrowSoulLocation { UniqueId = "crowskele_forest_3", Area = Area.Dungeon }},
        {"Crow-Dungeon Rightmost", new CrowSoulLocation { UniqueId = "crowskele_forest_2", Area = Area.Dungeon }},
        {"Crow-Lockstone East", new CrowSoulLocation { UniqueId = "crowskele_fortress_4", Area = Area.Lockstone }},
        {"Crow-Lockstone West", new CrowSoulLocation { UniqueId = "crowskele_fortress_1", Area = Area.Lockstone }},
        {"Crow-Lockstone West Locked", new CrowSoulLocation { UniqueId = "crowskele_fortress_2", Area = Area.Lockstone }},
        {"Crow-Lockstone South West", new CrowSoulLocation { UniqueId = "crowskele_fortress_3", Area = Area.Lockstone }},
    };

    public static bool TryGetLocation(string name, [CA.NotNullWhen(true)] out Location? loc) =>
        predefinedLocations.TryGetValue(name, out loc);

    private static readonly Collections.Dictionary<string, Item> predefinedItems = new()
    {
        // Spells and their upgrades
        {"Hookshot", HookshotItem.Instance},
        {"Fire", FireItem.Instance},
        {"Bomb", BombItem.Instance},
        {"Arrow Upgrade", ArrowUpgradeItem.Instance},

        // Weapons
        {"Reaper's Sword", new CountableInventoryItem {
            DisplayName = "Reaper's Sword",
            Icon = "Sword",
            UniqueId = "sword",
            CountId = "weapons_count"
        }},
        {"Rogue Daggers", new CountableInventoryItem {
            DisplayName = "Rogue Daggers",
            Icon = "Daggers",
            UniqueId = "daggers",
            CountId = "weapons_count"
        }},
        {"Discarded Umbrella", new CountableInventoryItem {
            DisplayName = "Discarded Umbrella",
            Icon = "Umbrella",
            UniqueId = "umbrella",
            CountId = "weapons_count"
        }},
        {"Reaper's Greatsword", new CountableInventoryItem {
            DisplayName = "Reaper's Greatsword",
            Icon = "Greatsword",
            UniqueId = "sword_heavy",
            CountId = "weapons_count"
        }},
        {"Thunder Hammer", new CountableInventoryItem {
            DisplayName = "Thunder Hammer",
            Icon = "ThunderHammer",
            UniqueId = "hammer",
            CountId = "weapons_count"
        }},

        // Giant Souls
        {"Giant Soul of The Urn Witch", new CountableInventoryItem {
            DisplayName = "Giant Soul of The Urn Witch",
            Icon = "Grandma",
            UniqueId = "soul_gran", 
            CountId = "boss_souls"
        }},
        {"Giant Soul of The Frog King", new CountableInventoryItem {
            DisplayName = "Giant Soul of The Frog King",
            Icon = "FrogKing",
            UniqueId = "soul_frog",
            CountId = "boss_souls"
        }},
        {"Giant Soul of Betty", new CountableInventoryItem {
            DisplayName = "Giant Soul of Betty",
            Icon = "Betty",
            UniqueId = "soul_yeti",
            CountId = "boss_souls"
        }},

        // Shards
        {"Vitality Shard", new VitalityShardItem { Amount = 1 }},
        {"Magic Shard", new MagicShardItem { Amount = 1 }},

        // Shiny Things
        {"Engagement Ring", new CountableInventoryItem {
            DisplayName = "Engagement Ring",
            Icon = "Ring",
            UniqueId = "trinket_ring",
            CountId = "trinket_collect_count"
        }},
        {"Old Compass", new CountableInventoryItem {
            DisplayName = "Old Compass",
            Icon = "Compass",
            UniqueId = "trinket_compass",
            CountId = "trinket_collect_count"
        }},
        {"Incense", new CountableInventoryItem {
            DisplayName = "Incense",
            Icon = "Incense",
            UniqueId = "trinket_incense",
            CountId = "trinket_collect_count"
        }},
        {"Undying Blossom", new CountableInventoryItem {
            DisplayName = "Undying Blossom",
            Icon = "Blossom",
            UniqueId = "trinket_flower",
            CountId = "trinket_collect_count"
        }},
        {"Old Photograph", new CountableInventoryItem {
            DisplayName = "Old Photograph",
            Icon = "OldPhoto",
            UniqueId = "trinket_photo",
            CountId = "trinket_collect_count"
        }},
        {"Sludge-Filled Urn", new CountableInventoryItem {
            DisplayName = "Sludge-Filled Urn",
            Icon = "SludgeUrn",
            UniqueId = "trinket_elixir",
            CountId = "trinket_collect_count"
        }},
        {"Token of Death", new CountableInventoryItem {
            DisplayName = "Token of Death",
            Icon = "TokenOfDeath",
            UniqueId = "trinket_coin",
            CountId = "trinket_collect_count"
        }},
        {"Rusty Garden Trowel", new CountableInventoryItem {
            DisplayName = "Rusty Garden Trowel",
            Icon = "Trowel",
            UniqueId = "trinket_trowel",
            CountId = "trinket_collect_count"
        }},
        {"Captain's Log", new CountableInventoryItem {
            DisplayName = "Captain's Log",
            Icon = "CaptainsLog",
            UniqueId = "trinket_journal",
            CountId = "trinket_collect_count"
        }},
        {"Giant Arrowhead", new CountableInventoryItem {
            DisplayName = "Giant Arrowhead",
            Icon = "Arrowhead",
            UniqueId = "trinket_arrow",
            CountId = "trinket_collect_count"
        }},
        {"Malformed Seed", new CountableInventoryItem {
            DisplayName = "Malformed Seed",
            Icon = "CorruptedSeed",
            UniqueId = "trinket_seed",
            CountId = "trinket_collect_count"
        }},
        {"Corrupted Antler", new CountableInventoryItem {
            DisplayName = "Corrupted Antler",
            Icon = "CorruptedAntler",
            UniqueId = "trinket_antler",
            CountId = "trinket_collect_count"
        }},
        {"Magical Forest Horn", new CountableInventoryItem {
            DisplayName = "Magical Forest Horn",
            Icon = "ForestHorn",
            UniqueId = "trinket_basoon",
            CountId = "trinket_collect_count"
        }},
        {"Ancient Crown", new CountableInventoryItem {
            DisplayName = "Ancient Crown",
            Icon = "Crown",
            UniqueId = "trinket_crown",
            CountId = "trinket_collect_count"
        }},
        {"Grunt's Old Mask", new CountableInventoryItem {
            DisplayName = "Grunt's Old Mask",
            Icon = "GruntMask",
            UniqueId = "trinket_mask",
            CountId = "trinket_collect_count"
        }},
        {"Ancient Door Scale Model", new CountableInventoryItem {
            DisplayName = "Ancient Door Scale Model",
            Icon = "AncientDoor",
            UniqueId = "trinket_door_old",
            CountId = "trinket_collect_count"
        }},
        {"Modern Door Scale Model", new CountableInventoryItem {
            DisplayName = "Modern Door Scale Model",
            Icon = "ModernDoor",
            UniqueId = "trinket_door_new",
            CountId = "trinket_collect_count"
        }},
        {"Rusty Belltower Key", new CountableInventoryItem {
            DisplayName = "Rusty Belltower Key",
            Icon = "BelltowerKey",
            UniqueId = "trinket_rusty_key",
            CountId = "trinket_collect_count"
        }},
        {"Surveillance Device", new CountableInventoryItem {
            DisplayName = "Surveillance Device",
            Icon = "SurveillanceDevice",
            UniqueId = "trinket_surv",
            CountId = "trinket_collect_count"
        }},
        {"Shiny Medallion", new CountableInventoryItem {
            DisplayName = "Shiny Medallion",
            Icon = "ShinyMedallion",
            UniqueId = "trinket_medal",
            CountId = "trinket_collect_count"
        }},
        {"Ink-Covered Teddy Bear", new CountableInventoryItem {
            DisplayName = "Ink-Covered Teddy Bear",
            Icon = "TeddyBear",
            UniqueId = "trinket_teddy",
            CountId = "trinket_collect_count"
        }},
        {"Death's Contract", new CountableInventoryItem {
            DisplayName = "Death's Contract",
            Icon = "DeathsContract",
            UniqueId = "trinket_contract",
            CountId = "trinket_collect_count"
        }},
        {"Makeshift Soul Key", new CountableInventoryItem {
            DisplayName = "Makeshift Soul Key",
            Icon = "SoulKey",
            UniqueId = "trinket_soulkey",
            CountId = "trinket_collect_count"
        }},
        {"Mysterious Locket", new CountableInventoryItem {
            DisplayName = "Mysterious Locket",
            Icon = "Locket",
            UniqueId = "trinket_locket",
            CountId = "trinket_collect_count"
        }},

        // Seeds
        {"Life Seed", new SeedsItem { Amount = 1 }},

        // Soul Orbs
        {"100 Souls", new SoulsItem { Amount = 100 }},

        // Tablets
        {"Red Ancient Tablet of Knowledge", new CountableInventoryItem {
            DisplayName = "Red Ancient Tablet of Knowledge",
            Icon = "RedTablet",
            UniqueId = "truthtablet_1",
            CountId = "truth_tablet_count"
        }},
        {"Yellow Ancient Tablet of Knowledge", new CountableInventoryItem {
            DisplayName = "Yellow Ancient Tablet of Knowledge",
            Icon = "YellowTablet",
            UniqueId = "truthtablet_2",
            CountId = "truth_tablet_count"
        }},
        {"Green Ancient Tablet of Knowledge", new CountableInventoryItem {
            DisplayName = "Green Ancient Tablet of Knowledge",
            Icon = "GreenTablet",
            UniqueId = "truthtablet_3",
            CountId = "truth_tablet_count"
        }},
        {"Cyan Ancient Tablet of Knowledge", new CountableInventoryItem {
            DisplayName = "Cyan Ancient Tablet of Knowledge",
            Icon = "CyanTablet",
            UniqueId = "truthtablet_4",
            CountId = "truth_tablet_count"
        }},
        {"Blue Ancient Tablet of Knowledge", new CountableInventoryItem {
            DisplayName = "Blue Ancient Tablet of Knowledge",
            Icon = "BlueTablet",
            UniqueId = "truthtablet_5",
            CountId = "truth_tablet_count"
        }},
        {"Purple Ancient Tablet of Knowledge", new CountableInventoryItem {
            DisplayName = "Purple Ancient Tablet of Knowledge",
            Icon = "PurpleTablet",
            UniqueId = "truthtablet_6",
            CountId = "truth_tablet_count"
        }},
        {"Pink Ancient Tablet of Knowledge", new CountableInventoryItem {
            DisplayName = "Pink Ancient Tablet of Knowledge",
            Icon = "PinkTablet",
            UniqueId = "truthtablet_7",
            CountId = "truth_tablet_count"
        }},

        // Levers
        {"Lever-Bomb Exit", new BoolItem { UniqueId = "hod_frog_lever", DisplayName = "Bomb Exit Lever", Icon = "FrogLever" }},
        {"Lever-Cemetery Sewer", new BoolItem { UniqueId = "lever_graveyardsummiteast", DisplayName = "Cemetery Sewer Lever", Icon = "FrogLever" }},
        {"Lever-Guardian of the Door Access", new BoolItem { UniqueId = "lever_graveyardredeemer", DisplayName = "Guardian of the Door Access Lever", Icon = "FrogLever" }},
        {"Lever-Cemetery Shortcut to East Tree", new BoolItem { UniqueId = "lever_graveyardforestroute", DisplayName = "Cemetery Shortcut to East Tree Lever", Icon = "FrogLever" }},
        {"Lever-Cemetery East Tree", new BoolItem { UniqueId = "lever_graveyardeast", DisplayName = "Cemetery East Tree Lever", Icon = "FrogLever" }},
        {"Lever-Catacombs Tower", new BoolItem { UniqueId = "lever_graveyardcentraltower", DisplayName = "Catacombs Tower Lever", Icon = "FrogLever" }},
        {"Lever-Cemetery Exit to Estate", new BoolItem { UniqueId = "lever_graveyardsummitwest", DisplayName = "Cemetery Exit to Estate Lever", Icon = "FrogLever" }},
        {"Lever-Catacombs Exit", new BoolItem { UniqueId = "lever_catacombsexit", DisplayName = "Catacombs Exit Lever", Icon = "FrogLever" }},
        {"Lever-Hookshot Silent Servant", new BoolItem { UniqueId = "lever_connectcave", DisplayName = "Hookshot Silent Servant Lever", Icon = "FrogLever" }},
        {"Lever-Sailor Turncam Upper", new BoolItem { UniqueId = "lever_sailorturncam1", DisplayName = "Sailor Turncam Upper Lever", Icon = "FrogLever" }},
        {"Lever-Sailor Turncam Lower", new BoolItem { UniqueId = "lever_sailorturncam2", DisplayName = "Sailor Turncam Lower Lever", Icon = "FrogLever" }},
        {"Lever-Sailor Greatsword Gate", new BoolItem { UniqueId = "sailorgate", DisplayName = "Sailor Greatsword Gate Lever", Icon = "FrogLever" }},
        {"Lever-Lockstone East Start Shortcut", new BoolItem { UniqueId = "fort_east_start", DisplayName = "Lockstone East Start Shortcut Lever", Icon = "FrogLever" }},
        {"Lever-Lockstone Entrance", new BoolItem { UniqueId = "fort_gate_1", DisplayName = "Lockstone Entrance Lever", Icon = "FrogLever" }},
        {"Lever-Lockstone East Lower", new BoolItem { UniqueId = "fort_upper1", DisplayName = "Lockstone East Lower Lever", Icon = "FrogLever" }},
        {"Lever-Lockstone Upper Shortcut", new BoolItem { UniqueId = "fort_ladlev_2", DisplayName = "Lockstone Upper Shortcut Lever", Icon = "FrogLever" }},
        {"Lever-Lockstone Dual Laser Puzzle", new BoolItem { UniqueId = "fort_gate_4", DisplayName = "Lockstone Dual Laser Puzzle Lever", Icon = "FrogLever" }},
        {"Lever-Lockstone Tracking Beam Puzzle", new BoolItem { UniqueId = "fort_gate_2", DisplayName = "Lockstone Tracking Beam Puzzle Lever", Icon = "FrogLever" }},
        {"Lever-Lockstone Vertical Laser Puzzle", new BoolItem { UniqueId = "fort_gate_3", DisplayName = "Lockstone Vertical Laser Puzzle Lever", Icon = "FrogLever" }},
        {"Lever-Lockstone North Puzzle", new BoolItem { UniqueId = "fort_gate_5", DisplayName = "Lockstone North Puzzle Lever", Icon = "FrogLever" }},
        {"Lever-Lockstone Shrine", new BoolItem { UniqueId = "lever_fortresssecretwest", DisplayName = "Lockstone Shrine Lever", Icon = "FrogLever" }},
        {"Lever-Lockstone Hookshot Puzzle", new BoolItem { UniqueId = "fort_gate_8", DisplayName = "Lockstone Hookshot Puzzle Lever", Icon = "FrogLever" }},
        {"Lever-Lockstone Upper Puzzle", new BoolItem { UniqueId = "fort_gate_upper", DisplayName = "Lockstone Upper Puzzle Lever", Icon = "FrogLever" }},
        {"Lever-Lockstone Upper Dual Laser Puzzle", new BoolItem { UniqueId = "fort_gate_6", DisplayName = "Lockstone Upper Dual Laser Puzzle Lever", Icon = "FrogLever" }},
        {"Lever-Watchtowers Before Ice Arena", new BoolItem { UniqueId = "lever_mountaintopsshortcut2", DisplayName = "Watchtowers Before Ice Arena Lever", Icon = "FrogLever" }},
        {"Lever-Watchtowers After Ice Skating", new BoolItem { UniqueId = "lever_mountaintopsshortcut3", DisplayName = "Watchtowers After Ice Skating Lever", Icon = "FrogLever" }},
        {"Lever-Watchtowers After Boomers", new BoolItem { UniqueId = "lever_mountaintopsshortcut1", DisplayName = "Watchtowers After Boomers Lever", Icon = "FrogLever" }},
        {"Lever-Ruins Settlement Gate", new BoolItem { UniqueId = "forestoldsettlementgate", DisplayName = "Ruins Settlement Gate Lever", Icon = "FrogLever" }},
        {"Lever-Ruins Upper Dungeon Entrance", new BoolItem { UniqueId = "colliseumsecret", DisplayName = "Ruins Upper Dungeon Entrance Lever", Icon = "FrogLever" }},
        {"Lever-Ruins Ladder Left of Lord of Doors Arena", new BoolItem { UniqueId = "fsettle_sc_1", DisplayName = "Ruins Ladder Left of Lord of Doors Arena Lever", Icon = "FrogLever" }},
        {"Lever-Ruins Entrance Ladder Shortcut", new BoolItem { UniqueId = "forest_short1", DisplayName = "Ruins Entrance Ladder Shortcut Lever", Icon = "FrogLever" }},
        {"Lever-Ruins Main Gate", new BoolItem { UniqueId = "forest_gate_lever", DisplayName = "Ruins Main Gate Lever", Icon = "FrogLever" }},
        {"Lever-Dungeon Entrance Right Gate", new BoolItem { UniqueId = "jail2", DisplayName = "Dungeon Entrance Right Gate Lever", Icon = "FrogLever" }},
        {"Lever-Dungeon Entrance Left Gate", new BoolItem { UniqueId = "jail1", DisplayName = "Dungeon Entrance Left Gate Lever", Icon = "FrogLever" }},
        {"Lever-Dungeon Above Rightmost Crow", new BoolItem { UniqueId = "foresteastexit", DisplayName = "Dungeon Above Rightmost Crow Lever" , Icon = "FrogLever"}},
        {"Lever-Fortress Bomb", new BoolItem { UniqueId = "swampladdershortcut2", DisplayName = "Fortress Bomb Lever", Icon = "FrogLever" }},
        {"Lever-Fortress Main Gate", new BoolItem { UniqueId = "swamp_enter_maingatelever", DisplayName = "Fortress Main Gate Lever", Icon = "FrogLever" }},
        {"Lever-Fortress Central Shortcut", new BoolItem { UniqueId = "swampladdershortcut1", DisplayName = "Fortress Central Shortcut Lever", Icon = "FrogLever" }},
        {"Lever-Fortress Statue", new BoolItem { UniqueId = "swampgateshortcut1", DisplayName = "Fortress Statue Lever", Icon = "FrogLever" }},
        {"Lever-Fortress Watchtower Lower", new BoolItem { UniqueId = "swampladdershortcut4", DisplayName = "Fortress Watchtower Lower Lever", Icon = "FrogLever" }},
        {"Lever-Fortress Bridge", new BoolItem { UniqueId = "swampladdershortcut3", DisplayName = "Fortress Bridge Ladder", Icon = "FrogLever" }},
        {"Lever-Fortress Pre-Main Gate", new BoolItem { UniqueId = "swampgateshortcut2", DisplayName = "Fortress Pre-Main Gate Lever", Icon = "FrogLever" }},
        {"Lever-Fortress Watchtower Upper", new BoolItem { UniqueId = "swampladdershortcut5", DisplayName = "Fortress Watchtower Upper Lever", Icon = "FrogLever" }},
        {"Lever-Fortress North West", new BoolItem { UniqueId = "lever_swampnorthwest", DisplayName = "Fortress North West Lever", Icon = "FrogLever" }},
        {"Lever-Estate Elevator Left", new BoolItem { UniqueId = "crypt_exit1", DisplayName = "Estate Elevator Left Lever", Icon = "FrogLever" }},
        {"Lever-Estate Elevator Right", new BoolItem { UniqueId = "crypt_exit2", DisplayName = "Estate Elevator Right Lever", Icon = "FrogLever" }},
        {"Lever-Garden of Love", new BoolItem { UniqueId = "lever_gardennorthwest", DisplayName = "Garden of Love Lever", Icon = "FrogLever" }},
        {"Lever-Garden of Life End", new BoolItem { UniqueId = "lever_gardennortheast", DisplayName = "Garden of Life End Lever", Icon = "FrogLever" }},
        {"Lever-Garden of Peace", new BoolItem { UniqueId = "Garden2End", DisplayName = "Garden of Peace Lever", Icon = "FrogLever" }},
        {"Lever-Garden of Joy", new BoolItem { UniqueId = "Garden1End", DisplayName = "Garden of Joy Lever", Icon = "FrogLever" }},
        {"Lever-Garden of Love Turncam", new BoolItem { UniqueId = "lever_gardenturncam", DisplayName = "Garden of Love Turncam Lever", Icon = "FrogLever" }},
        {"Lever-Garden of Life Lanterns", new BoolItem { UniqueId = "garden4lantern", DisplayName = "Garden of Life Lanterns Lever", Icon = "FrogLever" }},
        {"Lever-Estate Underground Urn Shed", new BoolItem { UniqueId = "lever_Gardenselixir", DisplayName = "Estate Underground Urn Shed Lever", Icon = "FrogLever" }},
        {"Lever-Manor Big Pot Arena", new BoolItem { UniqueId = "lever_dumbwaiter", DisplayName = "Manor Big Pot Arena Lever", Icon = "FrogLever" }},
        {"Lever-Manor Bookshelf Shortcut", new BoolItem { UniqueId = "mansionlibrarylever", DisplayName = "Manor Bookshelf Shortcut Lever", Icon = "FrogLever" }},

        // Doors
        {"Grove of Spirits Door", new BoolItem { UniqueId = "sdoor_tutorial", DisplayName = "Grove of Spirits Door", Icon = "ModernDoor" }},
        {"Lost Cemetery Door", new BoolItem { UniqueId = "sdoor_graveyard", DisplayName = "Lost Cemetery Door", Icon = "ModernDoor" }},
        {"Stranded Sailor Door", new BoolItem { UniqueId = "sdoor_sailor", DisplayName = "Stranded Sailor Door", Icon = "ModernDoor" }},
        {"Castle Lockstone Door", new BoolItem { UniqueId = "sdoor_fortress", DisplayName = "Castle Lockstone Door", Icon = "ModernDoor" }},
        {"Camp of the Free Crows Door", new BoolItem { UniqueId = "sdoor_covenant", DisplayName = "Camp of the Free Crows Door", Icon = "ModernDoor" }},
        {"Old Watchtowers Door", new BoolItem { UniqueId = "sdoor_mountaintops", DisplayName = "Old Watchtowers Door", Icon = "ModernDoor" }},
        {"Betty's Lair Door", new BoolItem { UniqueId = "sdoor_betty", DisplayName = "Betty's Lair Door", Icon = "ModernDoor" }},
        {"Overgrown Ruins Door", new BoolItem { UniqueId = "sdoor_forest", DisplayName = "Overgrown Ruins Door", Icon = "ModernDoor" }},
        {"Mushroom Dungeon Door", new BoolItem { UniqueId = "sdoor_forest_dung", DisplayName = "Mushroom Dungeon Door", Icon = "ModernDoor" }},
        {"Flooded Fortress Door", new BoolItem { UniqueId = "sdoor_swamp", DisplayName = "Flooded Fortress Door", Icon = "ModernDoor" }},
        {"Throne of the Frog King Door", new BoolItem { UniqueId = "sdoor_frogboss", DisplayName = "Throne of the Frog King Door", Icon = "ModernDoor" }},
        {"Estate of the Urn Witch Door", new BoolItem { UniqueId = "sdoor_gardens", DisplayName = "Estate of the Urn Witch Door", Icon = "ModernDoor" }},
        {"Ceramic Manor Door", new BoolItem { UniqueId = "sdoor_mansion", DisplayName = "Ceramic Manor Door", Icon = "ModernDoor" }},
        {"Inner Furnace Door", new BoolItem { UniqueId = "sdoor_basementromp", DisplayName = "Inner Furnace Door", Icon = "ModernDoor" }},
        {"The Urn Witch's Laboratory Door", new BoolItem { UniqueId = "sdoor_grandmaboss", DisplayName = "The Urn Witch's Laboratory Door", Icon = "ModernDoor" }},

        // Keys
        {"Pink Key", new KeyItem {
            DisplayName = "Pink Key",
            Icon = "PinkKey",
            Type = CollectableKey.KeyType.Graveyard
        }},
        {"Green Key", new KeyItem {
            DisplayName = "Green Key",
            Icon = "GreenKey",
            Type = CollectableKey.KeyType.Forest
        }},
        {"Yellow Key", new KeyItem {
            DisplayName = "Yellow Key",
            Icon = "YellowKey",
            Type = CollectableKey.KeyType.Mansion
        }},

        // Crow Souls
        {"Crow-Manor After Torch Puzzle", new CrowSoulItem {
            DisplayName = "Manor Crow 1",
            UniqueId = "crowskele_mansion_4"
        }},
        {"Crow-Manor Imp Loft", new CrowSoulItem {
            DisplayName = "Manor Crow 2",
            UniqueId = "crowskele_mansion_1"
        }},
        {"Crow-Manor Library", new CrowSoulItem {
            DisplayName = "Manor Crow 3",
            UniqueId = "crowskele_mansion_2"
        }},
        {"Crow-Manor Bedroom", new CrowSoulItem {
            DisplayName = "Manor Crow 4",
            UniqueId = "crowskele_mansion_3"
        }},
        {"Crow-Dungeon Hall", new CrowSoulItem {
            DisplayName = "Dungeon Crow 1",
            UniqueId = "crowskele_forest_4"
        }},
        {"Crow-Dungeon Water Arena", new CrowSoulItem {
            DisplayName = "Dungeon Crow 2",
            UniqueId = "crowskele_forest_1"
        }},
        {"Crow-Dungeon Cobweb", new CrowSoulItem {
            DisplayName = "Dungeon Crow 3",
            UniqueId = "crowskele_forest_3"
        }},
        {"Crow-Dungeon Rightmost", new CrowSoulItem {
            DisplayName = "Dungeon Crow 4",
            UniqueId = "crowskele_forest_2"
        }},
        {"Crow-Lockstone East", new CrowSoulItem {
            DisplayName = "Lockstone Crow 1",
            UniqueId = "crowskele_fortress_4"
        }},
        {"Crow-Lockstone West", new CrowSoulItem {
            DisplayName = "Lockstone Crow 2",
            UniqueId = "crowskele_fortress_1"
        }},
        {"Crow-Lockstone West Locked", new CrowSoulItem {
            DisplayName = "Lockstone Crow 3",
            UniqueId = "crowskele_fortress_2"
        }},
        {"Crow-Lockstone South West", new CrowSoulItem {
            DisplayName = "Lockstone Crow 4",
            UniqueId = "crowskele_fortress_3"
        }}
    };

    public static bool TryGetItem(string name, [CA.NotNullWhen(true)] out Item? item)
    {
        if (predefinedItems.TryGetValue(name, out item))
        {
            return true;
        }

        foreach (var (prefix, f) in multiplicableItems)
        {
            if (name.StartsWith(prefix) && int.TryParse(name.Substring(prefix.Length), out var n))
            {
                item = f(n);
                return true;
            }
        }

        item = null;
        return false;
    }

    private static readonly Collections.List<(string, System.Func<int, Item>)> multiplicableItems = new()
    {
        ("Life Seed x", n => new SeedsItem { Amount = n }),
        ("Magic Shard x", n => new MagicShardItem { Amount = n }),
        ("Vitality Shard x", n => new VitalityShardItem { Amount = n }),
    };
    
    // When the Plando mod and most original plandos were made, lever names
    // ended in " Lever". Since then ItemChanger has changed to begin them
    // with "Lever-", in line with other kinds of locations/items.
    // Also, the Rightmost Crow in Dungeon was previously called "Crow 2",
    // after its position in the 100% and Any% routes.
    // Keep the old names as aliases for the sake of compatibility.
    static Predefined()
    {
        const string leverPrefix = "Lever-";

        // We take advantage of the fact that predefined lever items have the same names as their
        // corresponding vanilla locations.
        var leverNames = predefinedLocations.Keys.Where(k => k.StartsWith(leverPrefix)).ToList();

        foreach (var name in leverNames)
        {
            var alias = name.Substring(leverPrefix.Length) + " Lever";
            predefinedLocations[alias] = predefinedLocations[name];
            predefinedItems[alias] = predefinedItems[name];
        }

        predefinedItems["Lever-Dungeon Above Crow 2"] = predefinedItems["Lever-Dungeon Above Rightmost Crow"];
        predefinedLocations["Lever-Dungeon Above Crow 2"] = predefinedLocations["Lever-Dungeon Above Rightmost Crow"];
        predefinedLocations["Seed-Dungeon Above Crow 2"] = predefinedLocations["Seed-Dungeon Above Rightmost Crow"];

        predefinedLocations["Lever-Lockstone Secret West"] = predefinedLocations["Lever-Lockstone Shrine"];
        predefinedItems["Lever-Lockstone Secret West"] = predefinedItems["Lever-Lockstone Shrine"];
    }
}