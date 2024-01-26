using Collections = System.Collections.Generic;
using CA = System.Diagnostics.CodeAnalysis;

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
        {"Rogue Daggers", new DropLocation { UniqueId = "daggers" }},
        {"Discarded Umbrella", new DropLocation { UniqueId = "umbrella" }},
        {"Reaper's Greatsword", new DropLocation { UniqueId = "sword_heavy" }},
        {"Thunder Hammer", new DropLocation { UniqueId = "hammer" }},

        // Giant Souls
        {"Betty", new CutsceneItemLocation { ItemId = "soul_yeti" }},
        {"Frog King", new CutsceneItemLocation { ItemId = "soul_frog" }},
        {"Grandma", new CutsceneItemLocation { ItemId = "soul_gran" }},

        // Shrines
        {"Heart Shrine-Cemetery Behind Entrance", new ShrineLocation { UniqueId = "shrine_graveyardhookshot" }},
        {"Magic Shrine-Cemetery After Smough Arena", new ShrineLocation { UniqueId = "shrine_graveyardbomb" }},
        {"Heart Shrine-Cemetery Winding Bridge End", new ShrineLocation { UniqueId = "shrine_graveyardturncam" }},
        {"Heart Shrine-Hookshot Arena", new ShrineLocation { UniqueId = "shrine_sailorhookshot" }},
        {"Magic Shrine-Sailor Turncam", new ShrineLocation { UniqueId = "shrine_sailorturncam" }},
        {"Magic Shrine-Lockstone Secret West", new ShrineLocation { UniqueId = "shrine_fortress" }},
        {"Heart Shrine-Camp Ice Skating", new ShrineLocation { UniqueId = "shrine_icechallenge" }},
        {"Magic Shrine-Ruins Hookshot Arena", new ShrineLocation { UniqueId = "shrine_foresthookshot" }},
        {"Magic Shrine-Ruins Turncam", new ShrineLocation { UniqueId = "shrine_forestturncam" }},
        {"Heart Shrine-Dungeon Water Arena", new ShrineLocation { UniqueId = "shrine_dungeonbomb" }},
        {"Heart Shrine-Ruins Sewer", new ShrineLocation { UniqueId = "shrine_forestsewer" }},
        {"Magic Shrine-Fortress Bow Secret", new ShrineLocation { UniqueId = "shrine_swamp" }},
        {"Magic Shrine-Estate Left of Manor", new ShrineLocation { UniqueId = "shrine_gardenturncam" }},
        {"Heart Shrine-Garden of Life", new ShrineLocation { UniqueId = "shrine_gardendrop" }},
        {"Magic Shrine-Manor Bathroom Puzzle", new ShrineLocation { UniqueId = "shrine_mansionreflection" }},
        {"Heart Shrine-Furnace Cart Puzzle", new ShrineLocation { UniqueId = "shrine_basement" }},

        // Shiny Things
        {"Engagement Ring", new DropLocation { UniqueId = "trinket_ring" }},
        {"Old Compass", new DropLocation { UniqueId = "trinket_compass" }},
        {"Incense", new DropLocation { UniqueId = "trinket_incense" }},
        {"Undying Blossom", new DropLocation { UniqueId = "trinket_flower" }},
        {"Old Photograph", new DropLocation { UniqueId = "trinket_photo" }},
        {"Sludge-Filled Urn", new DropLocation { UniqueId = "trinket_elixir" }},
        {"Token of Death", new DropLocation { UniqueId = "trinket_coin" }},
        {"Rusty Garden Trowel", new DropLocation { UniqueId = "trinket_trowel" }},
        {"Captain's Log", new DropLocation { UniqueId = "trinket_journal" }},
        {"Giant Arrowhead", new DropLocation { UniqueId = "trinket_arrow" }},
        {"Malformed Seed", new DropLocation { UniqueId = "trinket_seed" }},
        {"Corrupted Antler", new DropLocation { UniqueId = "trinket_antler" }},
        {"Magical Forest Horn", new DropLocation { UniqueId = "trinket_basoon" }},
        {"Ancient Crown", new DropLocation { UniqueId = "trinket_crown" }},
        {"Grunt's Old Mask", new DropLocation { UniqueId = "trinket_mask" }},
        {"Ancient Door Scale Model", new DropLocation { UniqueId = "trinket_door_old" }},
        {"Modern Door Scale Model", new DropLocation { UniqueId = "trinket_door_new" }},
        {"Rusty Belltower Key", new DropLocation { UniqueId = "trinket_rusty_key" }},
        {"Surveillance Device", new DropLocation { UniqueId = "trinket_surv" }},
        {"Shiny Medallion", new DropLocation { UniqueId = "trinket_medal" }},
        {"Ink-Covered Teddy Bear", new DropLocation { UniqueId = "trinket_teddy" }},
        {"Death's Contract", new DropLocation { UniqueId = "trinket_contract" }},
        {"Makeshift Soul Key", new DropLocation { UniqueId = "trinket_soulkey" }},
        {"Mysterious Locket", new DropLocation { UniqueId = "trinket_locket" }},

        // Seeds
        {"Seed-Cemetery Broken Bridge", new DropLocation { UniqueId = "seed_graveyardbrokenbridge" }},
        {"Seed-Catacombs Tower", new DropLocation { UniqueId = "seed_graveyardtower" }},
        {"Seed-Cemetery Left of Main Entrance", new DropLocation { UniqueId = "seed_graveyardbuilding" }},
        {"Seed-Cemetery Near Tablet Gate", new DropLocation { UniqueId = "seed_graveyardcliff" }},
        {"Seed-Between Cemetery and Sailor", new DropLocation { UniqueId = "seed_cavescrate" }},
        {"Seed-Sailor Upper", new DropLocation { UniqueId = "seed_sailormountain" }},
        {"Seed-Lockstone Upper East", new DropLocation { UniqueId = "seed_castlegardeneast" }},
        {"Seed-Lockstone Soul Door", new DropLocation { UniqueId = "seed_castledoor" }},
        {"Seed-Lockstone Behind Bars", new DropLocation { UniqueId = "seed_castleelevator" }},
        {"Seed-Lockstone Entrance West", new DropLocation { UniqueId = "seed_castlegardenwest" }},
        {"Seed-Lockstone North", new DropLocation { UniqueId = "seed_castleeast" }},
        {"Seed-Camp Ledge With Huts", new DropLocation { UniqueId = "seed_crowcavesledge" }},
        {"Seed-Camp Stall", new DropLocation { UniqueId = "seed_crowcampstall" }},
        {"Seed-Camp Rooftops", new DropLocation { UniqueId = "seed_fortressexteriorcrate" }},
        {"Seed-Watchtowers Ice Skating", new DropLocation { UniqueId = "seed_mountaintopsice" }},
        {"Seed-Watchtowers Tablet Door", new DropLocation { UniqueId = "seed_mountaintopstruth" }},
        {"Seed-Watchtowers Archer Platform", new DropLocation { UniqueId = "seed_mountaintopshookshot" }},
        {"Seed-Watchtowers Boxes", new DropLocation { UniqueId = "seed_mountaintopsroute1" }},
        {"Seed-Dungeon Fire Puzzle Near Water Arena", new DropLocation { UniqueId = "seed_dungeonconnect" }},
        {"Seed-Ruins Lord of Doors Arena", new DropLocation { UniqueId = "seed_forestgargoyle" }},
        {"Seed-Ruins Fire Plant Corridor", new DropLocation { UniqueId = "seed_forestcorridor" }},
        {"Seed-Dungeon Water Arena Left Exit", new DropLocation { UniqueId = "seed_dungeontwindoor" }},
        {"Seed-Ruins Right Middle", new DropLocation { UniqueId = "seed_forestmiddle" }},
        {"Seed-Ruins On Settlement Wall", new DropLocation { UniqueId = "seed_forestvillage" }},
        {"Seed-Ruins Behind Boxes", new DropLocation { UniqueId = "seed_forestintro" }},
        {"Seed-Ruins Down Through Bomb Wall", new DropLocation { UniqueId = "seed_forestdrop" }},
        {"Seed-Dungeon Above Crow 2", new DropLocation { UniqueId = "seed_dungeoneastexit" }},
        {"Seed-Dungeon Right Above Key", new DropLocation { UniqueId = "seed_dungeonprisonbreak" }},
        {"Seed-Dungeon Avarice Bridge", new DropLocation { UniqueId = "seed_dungeonbridge" }},
        {"Seed-Fortress Watchtower", new DropLocation { UniqueId = "seed_swampwatchtower" }},
        {"Seed-Fortress Statue", new DropLocation { UniqueId = "seed_swampstatue" }},
        {"Seed-Fortress Bridge", new DropLocation { UniqueId = "seed_swampbridge" }},
        {"Seed-Fortress Intro Crate", new DropLocation { UniqueId = "seed_swampintrocrate" }},
        {"Seed-Fortress East After Statue", new DropLocation { UniqueId = "seed_swampintroeast" }},
        {"Seed-Estate Family Tomb", new DropLocation { UniqueId = "seed_gardennorthwest" }},
        {"Seed-Estate Entrance", new DropLocation { UniqueId = "seed_gardenintrostart" }},
        {"Seed-Estate Hedge Gaps", new DropLocation { UniqueId = "seed_gardenbush" }},
        {"Seed-Garden of Joy", new DropLocation { UniqueId = "seed_gardensouthwest" }},
        {"Seed-Manor Boxes", new DropLocation { UniqueId = "seed_mansionsquareroom" }},
        {"Seed-Manor Near Brazier", new DropLocation { UniqueId = "seed_mansionrightshelves" }},
        {"Seed-Manor Below Big Pot Arena", new DropLocation { UniqueId = "seed_ballroom" }},
        {"Seed-Manor Rafters", new DropLocation { UniqueId = "seed_mansionattic" }},
        {"Seed-Manor Main Room Upper", new DropLocation { UniqueId = "seed_mansioncentre" }},
        {"Seed-Manor Spinny Pot Room", new DropLocation { UniqueId = "seed_mansionleftshelves" }},
        {"Seed-Manor Library Shelf", new DropLocation { UniqueId = "seed_mansionlibraryshelves" }},
        {"Seed-Cart Puzzle", new DropLocation { UniqueId = "seed_basementshrineabyss" }},
        {"Seed-Furnace Entrance", new DropLocation { UniqueId = "seed_basementintro" }},
        {"Seed-Inner Furnace Horizontal Pistons", new DropLocation { UniqueId = "seed_basementplague1" }},
        {"Seed-Inner Furnace Conveyor Bridge", new DropLocation { UniqueId = "seed_basementconveyor" }},
        {"Seed-Inner Furnace Conveyor Gauntlet", new DropLocation { UniqueId = "seed_basementplague2" }},

        // Soul Orbs
        {"Soul Orb-Fire Return Upper", new DropLocation { UniqueId = "dropsoul_HoDfirereturn1" }},
        {"Soul Orb-Hookshot Secret", new DropLocation { UniqueId = "dropsoul_hodhookshotsecret" }},
        {"Soul Orb-Bomb Return", new DropLocation { UniqueId = "dropsoul_hodbombreturn" }},
        {"Soul Orb-Bomb Secret", new DropLocation { UniqueId = "dropsoul_hodbombsecret" }},
        {"Soul Orb-Hookshot Return", new DropLocation { UniqueId = "dropsoul_hookshotreturn" }},
        {"Soul Orb-Fire Return Lower", new DropLocation { UniqueId = "dropsoul_hodfirereturn2" }},
        {"Soul Orb-Fire Secret", new DropLocation { UniqueId = "dropsoul_hodfiresecret" }},
        {"Soul Orb-Catacombs Exit", new DropLocation { UniqueId = "dropsoul_catacombsexit" }},
        {"Soul Orb-Cemetery Hookshot Towers", new DropLocation { UniqueId = "dropsoul_graveyardhookshot" }},
        {"Soul Orb-Cemetery Under Bridge", new DropLocation { UniqueId = "dropsoul_graveyardbridge" }},
        {"Soul Orb-Cemetery East Tree", new DropLocation { UniqueId = "dropsoul_graveyardtree" }},
        {"Soul Orb-Cemetery Winding Bridge End", new DropLocation { UniqueId = "dropsoul_graveyardbridgeroom" }},
        {"Soul Orb-Catacombs Room 2", new DropLocation { UniqueId = "dropsoul_catacombs2" }},
        {"Soul Orb-Catacombs Room 1", new DropLocation { UniqueId = "dropsoul_catacombs1" }},
        {"Soul Orb-Cemetery Gated Sewer", new DropLocation { UniqueId = "dropsoul_graveyardsewer" }},
        {"Soul Orb-Catacombs Entrance", new DropLocation { UniqueId = "dropsoul_catacombsentrance" }},
        {"Soul Orb-Cemetery Cave", new DropLocation { UniqueId = "dropsoul_graveyardcave" }},
        {"Soul Orb-Sailor Turncam", new DropLocation { UniqueId = "dropsoul_sailorturncam" }},
        {"Soul Orb-North Lockstone Sewer", new DropLocation { UniqueId = "dropsoul_castlesewer2" }},
        {"Soul Orb-Lockstone Hookshot North", new DropLocation { UniqueId = "dropsoul_castlehookshoteast" }},
        {"Soul Orb-Lockstone Exit", new DropLocation { UniqueId = "dropsoul_castleexit" }},
        {"Soul Orb-West Lockstone Sewer", new DropLocation { UniqueId = "dropsoul_castlesewer1" }},
        {"Soul Orb-Camp Rooftops", new DropLocation { UniqueId = "dropsoul_fortressexterior" }},
        {"Soul Orb-Camp Broken Bridge", new DropLocation { UniqueId = "dropsoul_crowcavesbridge" }},
        {"Soul Orb-Watchtowers Behind Barb Elevator", new DropLocation { UniqueId = "dropsoul_mountaintopsturncam" }},
        {"Soul Orb-Dungeon Vine", new DropLocation { UniqueId = "dropsoul_dungeonpeek" }},
        {"Soul Orb-Ruins Stump", new DropLocation { UniqueId = "dropsoul_forestcolliseumhookshot" }},
        {"Soul Orb-Ruins Outside Left Dungeon Exit", new DropLocation { UniqueId = "dropsoul_forestraised" }},
        {"Soul Orb-Dungeon Cobweb", new DropLocation { UniqueId = "dropsoul_dungeoncobweb" }},
        {"Soul Orb-Ruins Left After Key Door", new DropLocation { UniqueId = "dropsoul_forestcorner" }},
        {"Soul Orb-Ruins Lower Bomb Wall", new DropLocation { UniqueId = "dropsoul_forestblocked" }},
        {"Soul Orb-Ruins Lord of Doors Arena Hookshot", new DropLocation { UniqueId = "dropsoul_forestnorthhookshot" }},
        {"Soul Orb-Dungeon Lower Entrance", new DropLocation { UniqueId = "dropsoul_swamproute" }},
        {"Soul Orb-Ruins Upper Above Horn", new DropLocation { UniqueId = "dropsoul_forestcolliseum" }},
        {"Soul Orb-Ruins Above Three Plants", new DropLocation { UniqueId = "dropsoul_forestvine" }},
        {"Soul Orb-Ruins Up Turncam Ladder", new DropLocation { UniqueId = "dropsoul_forestladder" }},
        {"Soul Orb-Ruins Above Entrance Gate", new DropLocation { UniqueId = "dropsoul_forestentrancewall" }},
        {"Soul Orb-Ruins Upper Bomb Wall", new DropLocation { UniqueId = "dropsoul_forestbomber" }},
        {"Soul Orb-Dungeon Left Exit Shelf", new DropLocation { UniqueId = "dropsoul_dungeonshelfdrop" }},
        {"Soul Orb-Ruins Lower Hookshot", new DropLocation { UniqueId = "dropsoul_forestintrohookshot" }},
        {"Soul Orb-Fortress Bomb", new DropLocation { UniqueId = "dropsoul_swampbomb" }},
        {"Soul Orb-Fortress Hidden Sewer", new DropLocation { UniqueId = "dropsoul_swampsewer" }},
        {"Soul Orb-Fortress Drop", new DropLocation { UniqueId = "dropsoul_swampdrop" }},
        {"Soul Orb-Estate Access Crypt", new DropLocation { UniqueId = "dropsoul_cryptgrave" }},
        {"Soul Orb-Estate Balcony", new DropLocation { UniqueId = "dropsoul_gardenbalcony" }},
        {"Soul Orb-Garden of Love Turncam", new DropLocation { UniqueId = "dropsoul_gardenturncam" }},
        {"Soul Orb-Garden of Life Hookshot Loop", new DropLocation { UniqueId = "dropsoul_gardennorthhookshot" }},
        {"Soul Orb-Garden of Love Bomb Walls", new DropLocation { UniqueId = "dropsoul_familytombbomb" }},
        {"Soul Orb-Garden of Life Bomb Wall", new DropLocation { UniqueId = "dropsoul_gardenknight" }},
        {"Soul Orb-Estate Broken Boardwalk", new DropLocation { UniqueId = "dropsoul_gardensouthhookshot" }},
        {"Soul Orb-Estate Secret Cave", new DropLocation { UniqueId = "dropsoul_gardencave" }},
        {"Soul Orb-Estate Twin Benches", new DropLocation { UniqueId = "dropsoul_gardensbenches" }},
        {"Soul Orb-Estate Sewer Middle", new DropLocation { UniqueId = "dropsoul_gardensewerroute1" }},
        {"Soul Orb-Estate Sewer End", new DropLocation { UniqueId = "dropsoul_gardensewerroute2" }},
        {"Soul Orb-Garden of Peace", new DropLocation { UniqueId = "dropsoul_gardensouthbomb" }},
        {"Soul Orb-Manor Imp Loft", new DropLocation { UniqueId = "dropsoul_mansionladder" }},
        {"Soul Orb-Manor Library Shelf", new DropLocation { UniqueId = "dropsoul_mansionlibrary" }},
        {"Soul Orb-Manor Chandelier", new DropLocation { UniqueId = "chand_souls" }},
        {"Soul Orb-Furnace Lantern Chain", new DropLocation { UniqueId = "dropsoul_basementlanternchain" }},
        {"Soul Orb-Small Room", new DropLocation { UniqueId = "dropsoul_basementsmallroom" }},
        {"Soul Orb-Furnace Entrance Sewer", new DropLocation { UniqueId = "dropsoul_basementsewer" }},

        // Tablets
        {"Red Ancient Tablet of Knowledge", new DropLocation { UniqueId = "truthtablet_1" }},
        {"Yellow Ancient Tablet of Knowledge", new DropLocation { UniqueId = "truthtablet_2" }},
        {"Green Ancient Tablet of Knowledge", new DropLocation { UniqueId = "truthtablet_3" }},
        {"Cyan Ancient Tablet of Knowledge", new DropLocation { UniqueId = "truthtablet_4" }},
        {"Blue Ancient Tablet of Knowledge", new DropLocation { UniqueId = "truthtablet_5" }},
        {"Purple Ancient Tablet of Knowledge", new DropLocation { UniqueId = "truthtablet_6" }},
        {"Estate Owl", new DropLocation { UniqueId = "truthshard_1" }},
        {"Ruins Owl", new DropLocation { UniqueId = "truthshard_2" }},
        {"Watchtowers Owl", new DropLocation { UniqueId = "truthshard_3" }},

        // Levers
        {"Bomb Exit Lever", new FrogLeverLocation { UniqueId = "hod_frog_lever" }},
        {"Cemetery Sewer Lever", new FrogLeverLocation { UniqueId = "lever_graveyardsummiteast" }},
        {"Guardian of the Door Access Lever", new FrogLeverLocation { UniqueId = "lever_graveyardredeemer" }},
        {"Cemetery Shortcut to East Tree Lever", new FrogLeverLocation { UniqueId = "lever_graveyardforestroute" }},
        {"Cemetery East Tree Lever", new FrogLeverLocation { UniqueId = "lever_graveyardeast" }},
        {"Catacombs Tower Lever", new FrogLeverLocation { UniqueId = "lever_graveyardcentraltower" }},
        {"Cemetery Exit to Estate Lever", new FrogLeverLocation { UniqueId = "lever_graveyardsummitwest" }},
        {"Catacombs Exit Lever", new FrogLeverLocation { UniqueId = "lever_catacombsexit" }},
        {"Hookshot Silent Servant Lever", new FrogLeverLocation { UniqueId = "lever_connectcave" }},
        {"Sailor Turncam Upper Lever", new FrogLeverLocation { UniqueId = "lever_sailorturncam1" }},
        {"Sailor Turncam Lower Lever", new FrogLeverLocation { UniqueId = "lever_sailorturncam2" }},
        {"Sailor Greatsword Gate Lever", new IronLeverLocation { UniqueId = "sailorgate" }},
        {"Lockstone East Start Shortcut Lever", new FrogLeverLocation { UniqueId = "fort_east_start" }},
        {"Lockstone Entrance Lever", new IronLeverLocation { UniqueId = "fort_gate_1" }},
        {"Lockstone East Lower Lever", new FrogLeverLocation { UniqueId = "fort_upper1" }},
        {"Lockstone Upper Shortcut Lever", new FrogLeverLocation { UniqueId = "fort_ladlev_2" }},
        {"Lockstone Dual Laser Puzzle Lever", new IronLeverLocation { UniqueId = "fort_gate_4" }},
        {"Lockstone Tracking Beam Puzzle Lever", new IronLeverLocation { UniqueId = "fort_gate_2" }},
        {"Lockstone Vertical Laser Puzzle Lever", new IronLeverLocation { UniqueId = "fort_gate_3" }},
        {"Lockstone North Puzzle Lever", new IronLeverLocation { UniqueId = "fort_gate_5" }},
        {"Lockstone Secret West Lever", new FrogLeverLocation { UniqueId = "lever_fortresssecretwest" }},
        {"Lockstone Hookshot Puzzle Lever", new IronLeverLocation { UniqueId = "fort_gate_8" }},
        {"Lockstone Upper Puzzle Lever", new IronLeverLocation { UniqueId = "fort_gate_upper" }},
        {"Lockstone Upper Dual Laser Puzzle Lever", new IronLeverLocation { UniqueId = "fort_gate_6" }},
        {"Watchtowers Before Ice Arena Lever", new FrogLeverLocation { UniqueId = "lever_mountaintopsshortcut2" }},
        {"Watchtowers After Ice Skating Lever", new FrogLeverLocation { UniqueId = "lever_mountaintopsshortcut3" }},
        {"Watchtowers After Boomers Lever", new FrogLeverLocation { UniqueId = "lever_mountaintopsshortcut1" }},
        {"Ruins Settlement Gate Lever", new FrogLeverLocation { UniqueId = "forestoldsettlementgate" }},
        {"Ruins Upper Dungeon Entrance Lever", new FrogLeverLocation { UniqueId = "colliseumsecret" }},
        {"Ruins Ladder Left of Lord of Doors Arena Lever", new FrogLeverLocation { UniqueId = "fsettle_sc_1" }},
        {"Ruins Entrance Ladder Shortcut Lever", new FrogLeverLocation { UniqueId = "forest_short1" }},
        {"Ruins Main Gate Lever", new FrogLeverLocation { UniqueId = "forest_gate_lever" }},
        {"Dungeon Entrance Right Gate Lever", new FrogLeverLocation { UniqueId = "jail2" }},
        {"Dungeon Entrance Left Gate Lever", new FrogLeverLocation { UniqueId = "jail1" }},
        {"Dungeon Above Crow 2 Lever", new FrogLeverLocation { UniqueId = "foresteastexit" }},
        {"Fortress Bomb Lever", new FrogLeverLocation { UniqueId = "swampladdershortcut2" }},
        {"Fortress Main Gate Lever", new FrogLeverLocation { UniqueId = "swamp_enter_maingatelever" }},
        {"Fortress Central Shortcut Lever", new FrogLeverLocation { UniqueId = "swampladdershortcut1" }},
        {"Fortress Statue Lever", new FrogLeverLocation { UniqueId = "swampgateshortcut1" }},
        {"Fortress Watchtower Lower Lever", new FrogLeverLocation { UniqueId = "swampladdershortcut4" }},
        {"Fortress Bridge Ladder", new FrogLeverLocation { UniqueId = "swampladdershortcut3" }},
        {"Fortress Pre-Main Gate Lever", new FrogLeverLocation { UniqueId = "swampgateshortcut2" }},
        {"Fortress Watchtower Upper Lever", new FrogLeverLocation { UniqueId = "swampladdershortcut5" }},
        {"Fortress North West Lever", new FrogLeverLocation { UniqueId = "lever_swampnorthwest" }},
        {"Estate Elevator Left Lever", new FrogLeverLocation { UniqueId = "crypt_exit1" }},
        {"Estate Elevator Right Lever", new FrogLeverLocation { UniqueId = "crypt_exit2" }},
        {"Garden of Love Lever", new FrogLeverLocation { UniqueId = "lever_gardennorthwest" }},
        {"Garden of Life End Lever", new FrogLeverLocation { UniqueId = "lever_gardennortheast" }},
        {"Garden of Peace Lever", new FrogLeverLocation { UniqueId = "Garden2End" }},
        {"Garden of Joy Lever", new FrogLeverLocation { UniqueId = "Garden1End" }},
        {"Garden of Love Turncam Lever", new FrogLeverLocation { UniqueId = "lever_gardenturncam" }},
        {"Garden of Life Lanterns Lever", new FrogLeverLocation { UniqueId = "garden4lantern" }},
        {"Estate Underground Urn Shed Lever", new FrogLeverLocation { UniqueId = "lever_Gardenselixir" }},
        {"Manor Big Pot Arena Lever", new FrogLeverLocation { UniqueId = "lever_dumbwaiter" }},
        {"Manor Bookshelf Shortcut Lever", new FrogLeverLocation { UniqueId = "mansionlibrarylever" }},

        // Doors
        {"Grove of Spirits Door", new DoorLocation { KeyId = "sdoor_tutorial" }},
        {"Lost Cemetery Door", new DoorLocation { KeyId = "sdoor_graveyard" }},
        {"Stranded Sailor Door", new DoorLocation { KeyId = "sdoor_sailor" }},
        {"Castle Lockstone Door", new DoorLocation { KeyId = "sdoor_fortress" }},
        {"Camp of the Free Crows Door", new DoorLocation { KeyId = "sdoor_covenant" }},
        {"Old Watchtowers Door", new DoorLocation { KeyId = "sdoor_mountaintops" }},
        {"Betty's Lair Door", new DoorLocation { KeyId = "sdoor_betty" }},
        {"Overgrown Ruins Door", new DoorLocation { KeyId = "sdoor_forest" }},
        {"Mushroom Dungeon Door", new DoorLocation { KeyId = "sdoor_forest_dung" }},
        {"Flooded Fortress Door", new DoorLocation { KeyId = "sdoor_swamp" }},
        {"Throne of the Frog King Door", new DoorLocation { KeyId = "sdoor_frogboss" }},
        {"Estate of the Urn Witch Door", new DoorLocation { KeyId = "sdoor_gardens" }},
        {"Ceramic Manor Door", new DoorLocation { KeyId = "sdoor_mansion" }},
        {"Inner Furnace Door", new DoorLocation { KeyId = "sdoor_basementromp" }},
        {"The Urn Witch's Laboratory Door", new DoorLocation { KeyId = "sdoor_grandmaboss" }},

        // Keys
        {"Key-Cemetery Central", new KeyLocation { UniqueId = "collectablekey_graveyardroute1" }},
        {"Key-Cemetery Grey Crow", new KeyLocation { UniqueId = "collectablekey_graveyardsummit" }},
        {"Key-Camp of the Free Crows", new KeyLocation { UniqueId = "covenant_key" }},
        {"Key-Lockstone West", new KeyLocation { UniqueId = "collectablekey_fortresswest" }},
        {"Key-Lockstone North", new KeyLocation { UniqueId = "collectablekey_fortresseast" }},
        {"Key-Overgrown Ruins", new KeyLocation { UniqueId = "forest_key_4" }},
        {"Key-Dungeon Hall", new KeyLocation { UniqueId = "forest_key_2" }},
        {"Key-Dungeon Right", new KeyLocation { UniqueId = "forest_key_1" }},
        {"Key-Dungeon Near Water Arena", new KeyLocation { UniqueId = "forest_key_3" }},
        {"Key-Manor Under Dining Room", new KeyLocation { UniqueId = "mansion_key1" }},
        {"Key-Manor After Spinny Pot Room", new KeyLocation { UniqueId = "mansion_key2" }},
        {"Key-Manor Library", new KeyLocation { UniqueId = "collectablekey_mansion3" }},
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
        {"Vitality Shard", VitalityShardItem.Instance},
        {"Magic Shard", MagicShardItem.Instance},

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
        {"Life Seed", SeedItem.Instance},

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
        {"Bomb Exit Lever", new BoolItem { UniqueId = "hod_frog_lever", DisplayName = "Bomb Exit Lever", Icon = "FrogLever" }},
        {"Cemetery Sewer Lever", new BoolItem { UniqueId = "lever_graveyardsummiteast", DisplayName = "Cemetery Sewer Lever", Icon = "FrogLever" }},
        {"Guardian of the Door Access Lever", new BoolItem { UniqueId = "lever_graveyardredeemer", DisplayName = "Guardian of the Door Access Lever", Icon = "FrogLever" }},
        {"Cemetery Shortcut to East Tree Lever", new BoolItem { UniqueId = "lever_graveyardforestroute", DisplayName = "Cemetery Shortcut to East Tree Lever", Icon = "FrogLever" }},
        {"Cemetery East Tree Lever", new BoolItem { UniqueId = "lever_graveyardeast", DisplayName = "Cemetery East Tree Lever", Icon = "FrogLever" }},
        {"Catacombs Tower Lever", new BoolItem { UniqueId = "lever_graveyardcentraltower", DisplayName = "Catacombs Tower Lever", Icon = "FrogLever" }},
        {"Cemetery Exit to Estate Lever", new BoolItem { UniqueId = "lever_graveyardsummitwest", DisplayName = "Cemetery Exit to Estate Lever", Icon = "FrogLever" }},
        {"Catacombs Exit Lever", new BoolItem { UniqueId = "lever_catacombsexit", DisplayName = "Catacombs Exit Lever", Icon = "FrogLever" }},
        {"Hookshot Silent Servant Lever", new BoolItem { UniqueId = "lever_connectcave", DisplayName = "Hookshot Silent Servant Lever", Icon = "FrogLever" }},
        {"Sailor Turncam Upper Lever", new BoolItem { UniqueId = "lever_sailorturncam1", DisplayName = "Sailor Turncam Upper Lever", Icon = "FrogLever" }},
        {"Sailor Turncam Lower Lever", new BoolItem { UniqueId = "lever_sailorturncam2", DisplayName = "Sailor Turncam Lower Lever", Icon = "FrogLever" }},
        {"Sailor Greatsword Gate Lever", new BoolItem { UniqueId = "sailorgate", DisplayName = "Sailor Greatsword Gate Lever", Icon = "FrogLever" }},
        {"Lockstone East Start Shortcut Lever", new BoolItem { UniqueId = "fort_east_start", DisplayName = "Lockstone East Start Shortcut Lever", Icon = "FrogLever" }},
        {"Lockstone Entrance Lever", new BoolItem { UniqueId = "fort_gate_1", DisplayName = "Lockstone Entrance Lever", Icon = "FrogLever" }},
        {"Lockstone East Lower Lever", new BoolItem { UniqueId = "fort_upper1", DisplayName = "Lockstone East Lower Lever", Icon = "FrogLever" }},
        {"Lockstone Upper Shortcut Lever", new BoolItem { UniqueId = "fort_ladlev_2", DisplayName = "Lockstone Upper Shortcut Lever", Icon = "FrogLever" }},
        {"Lockstone Dual Laser Puzzle Lever", new BoolItem { UniqueId = "fort_gate_4", DisplayName = "Lockstone Dual Laser Puzzle Lever", Icon = "FrogLever" }},
        {"Lockstone Tracking Beam Puzzle Lever", new BoolItem { UniqueId = "fort_gate_2", DisplayName = "Lockstone Tracking Beam Puzzle Lever", Icon = "FrogLever" }},
        {"Lockstone Vertical Laser Puzzle Lever", new BoolItem { UniqueId = "fort_gate_3", DisplayName = "Lockstone Vertical Laser Puzzle Lever", Icon = "FrogLever" }},
        {"Lockstone North Puzzle Lever", new BoolItem { UniqueId = "fort_gate_5", DisplayName = "Lockstone North Puzzle Lever", Icon = "FrogLever" }},
        {"Lockstone Secret West Lever", new BoolItem { UniqueId = "lever_fortresssecretwest", DisplayName = "Lockstone Secret West Lever", Icon = "FrogLever" }},
        {"Lockstone Hookshot Puzzle Lever", new BoolItem { UniqueId = "fort_gate_8", DisplayName = "Lockstone Hookshot Puzzle Lever", Icon = "FrogLever" }},
        {"Lockstone Upper Puzzle Lever", new BoolItem { UniqueId = "fort_gate_upper", DisplayName = "Lockstone Upper Puzzle Lever", Icon = "FrogLever" }},
        {"Lockstone Upper Dual Laser Puzzle Lever", new BoolItem { UniqueId = "fort_gate_6", DisplayName = "Lockstone Upper Dual Laser Puzzle Lever", Icon = "FrogLever" }},
        {"Watchtowers Before Ice Arena Lever", new BoolItem { UniqueId = "lever_mountaintopsshortcut2", DisplayName = "Watchtowers Before Ice Arena Lever", Icon = "FrogLever" }},
        {"Watchtowers After Ice Skating Lever", new BoolItem { UniqueId = "lever_mountaintopsshortcut3", DisplayName = "Watchtowers After Ice Skating Lever", Icon = "FrogLever" }},
        {"Watchtowers After Boomers Lever", new BoolItem { UniqueId = "lever_mountaintopsshortcut1", DisplayName = "Watchtowers After Boomers Lever", Icon = "FrogLever" }},
        {"Ruins Settlement Gate Lever", new BoolItem { UniqueId = "forestoldsettlementgate", DisplayName = "Ruins Settlement Gate Lever", Icon = "FrogLever" }},
        {"Ruins Upper Dungeon Entrance Lever", new BoolItem { UniqueId = "colliseumsecret", DisplayName = "Ruins Upper Dungeon Entrance Lever", Icon = "FrogLever" }},
        {"Ruins Ladder Left of Lord of Doors Arena Lever", new BoolItem { UniqueId = "fsettle_sc_1", DisplayName = "Ruins Ladder Left of Lord of Doors Arena Lever", Icon = "FrogLever" }},
        {"Ruins Entrance Ladder Shortcut Lever", new BoolItem { UniqueId = "forest_short1", DisplayName = "Ruins Entrance Ladder Shortcut Lever", Icon = "FrogLever" }},
        {"Ruins Main Gate Lever", new BoolItem { UniqueId = "forest_gate_lever", DisplayName = "Ruins Main Gate Lever", Icon = "FrogLever" }},
        {"Dungeon Entrance Right Gate Lever", new BoolItem { UniqueId = "jail2", DisplayName = "Dungeon Entrance Right Gate Lever", Icon = "FrogLever" }},
        {"Dungeon Entrance Left Gate Lever", new BoolItem { UniqueId = "jail1", DisplayName = "Dungeon Entrance Left Gate Lever", Icon = "FrogLever" }},
        {"Dungeon Above Crow 2 Lever", new BoolItem { UniqueId = "foresteastexit", DisplayName = "Dungeon Above Crow 2 Lever" , Icon = "FrogLever"}},
        {"Fortress Bomb Lever", new BoolItem { UniqueId = "swampladdershortcut2", DisplayName = "Fortress Bomb Lever", Icon = "FrogLever" }},
        {"Fortress Main Gate Lever", new BoolItem { UniqueId = "swamp_enter_maingatelever", DisplayName = "Fortress Main Gate Lever", Icon = "FrogLever" }},
        {"Fortress Central Shortcut Lever", new BoolItem { UniqueId = "swampladdershortcut1", DisplayName = "Fortress Central Shortcut Lever", Icon = "FrogLever" }},
        {"Fortress Statue Lever", new BoolItem { UniqueId = "swampgateshortcut1", DisplayName = "Fortress Statue Lever", Icon = "FrogLever" }},
        {"Fortress Watchtower Lower Lever", new BoolItem { UniqueId = "swampladdershortcut4", DisplayName = "Fortress Watchtower Lower Lever", Icon = "FrogLever" }},
        {"Fortress Bridge Ladder", new BoolItem { UniqueId = "swampladdershortcut3", DisplayName = "Fortress Bridge Ladder", Icon = "FrogLever" }},
        {"Fortress Pre-Main Gate Lever", new BoolItem { UniqueId = "swampgateshortcut2", DisplayName = "Fortress Pre-Main Gate Lever", Icon = "FrogLever" }},
        {"Fortress Watchtower Upper Lever", new BoolItem { UniqueId = "swampladdershortcut5", DisplayName = "Fortress Watchtower Upper Lever", Icon = "FrogLever" }},
        {"Fortress North West Lever", new BoolItem { UniqueId = "lever_swampnorthwest", DisplayName = "Fortress North West Lever", Icon = "FrogLever" }},
        {"Estate Elevator Left Lever", new BoolItem { UniqueId = "crypt_exit1", DisplayName = "Estate Elevator Left Lever", Icon = "FrogLever" }},
        {"Estate Elevator Right Lever", new BoolItem { UniqueId = "crypt_exit2", DisplayName = "Estate Elevator Right Lever", Icon = "FrogLever" }},
        {"Garden of Love Lever", new BoolItem { UniqueId = "lever_gardennorthwest", DisplayName = "Garden of Love Lever", Icon = "FrogLever" }},
        {"Garden of Life End Lever", new BoolItem { UniqueId = "lever_gardennortheast", DisplayName = "Garden of Life End Lever", Icon = "FrogLever" }},
        {"Garden of Peace Lever", new BoolItem { UniqueId = "Garden2End", DisplayName = "Garden of Peace Lever", Icon = "FrogLever" }},
        {"Garden of Joy Lever", new BoolItem { UniqueId = "Garden1End", DisplayName = "Garden of Joy Lever", Icon = "FrogLever" }},
        {"Garden of Love Turncam Lever", new BoolItem { UniqueId = "lever_gardenturncam", DisplayName = "Garden of Love Turncam Lever", Icon = "FrogLever" }},
        {"Garden of Life Lanterns Lever", new BoolItem { UniqueId = "garden4lantern", DisplayName = "Garden of Life Lanterns Lever", Icon = "FrogLever" }},
        {"Estate Underground Urn Shed Lever", new BoolItem { UniqueId = "lever_Gardenselixir", DisplayName = "Estate Underground Urn Shed Lever", Icon = "FrogLever" }},
        {"Manor Big Pot Arena Lever", new BoolItem { UniqueId = "lever_dumbwaiter", DisplayName = "Manor Big Pot Arena Lever", Icon = "FrogLever" }},
        {"Manor Bookshelf Shortcut Lever", new BoolItem { UniqueId = "mansionlibrarylever", DisplayName = "Manor Bookshelf Shortcut Lever", Icon = "FrogLever" }},

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
    };

    public static bool TryGetItem(string name, [CA.NotNullWhen(true)] out Item? item) =>
        predefinedItems.TryGetValue(name, out item);
}