namespace DDoor.ItemChanger;

public enum Area
{
    Unknown,
    HallOfDoors,
    Grove,
    Cemetery,
    Estate,
    Manor,
    OuterFurnace,
    InnerFurnace,
    Grandma,
    Ruins,
    Dungeon,
    Fortress,
    FrogKing,
    Sailor,
    Lockstone,
    Camp,
    Watchtowers,
    Betty
}

public static class AreaName
{
    private static string[] names = new string[]
    {
        "Other",
        "Hall of Doors",
        "Grove of Spirits",
        "Lost Cemetery",
        "Estate of the Urn Witch",
        "Ceramic Manor",
        "Furnace Observation Rooms",
        "Inner Furnace",
        "The Urn Witch's Laboratory",
        "Overgrown Ruins",
        "Mushroom Dungeon",
        "Flooded Fortress",
        "Throne of the Frog King",
        "Stranded Sailor",
        "Castle Lockstone",
        "Camp of the Free Crows",
        "Old Watchtowers",
        "Betty's Lair"
    };

    public static string Of(Area a)
    {
        var i = (int)a;
        return i >= 0 && i < names.Length ? names[i] : names[0];
    }
}
