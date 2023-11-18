using CA = System.Diagnostics.CodeAnalysis;
using Collections = System.Collections.Generic;
using Bep = BepInEx;
using HL = HarmonyLib;

namespace DDoorItemChanger;

[Bep.BepInPlugin("deathsdoor.itemchanger", "ItemChanger", "1.0.0.0")]
internal class ItemChangerPlugin : Bep.BaseUnityPlugin
{
    private static ItemChangerPlugin? Instance;

    public void Start()
    {
        Instance = this;
        SaveFile.OnNewGame += () =>
        {
            var placements = SaveFile.CurrentData!.Placements;
            placements.Add(new() { LocationName = "Discarded_Umbrella", ItemName = "Hookshot" });
            placements.Add(new() { LocationName = "100_Souls-Hall_of_Doors_(Hookshot_Secret)", ItemName = "Hookshot" });
            placements.Add(new() { LocationName = "Frog_King", ItemName = "Giant_Soul_of_Betty" });
            placements.Add(new() { LocationName = "Hookshot_Avarice", ItemName = "Giant_Soul_of_The_Frog_King" });
        };
        SaveFile.OnLoadGame += () =>
        {
            activePlacements.Clear();

            foreach (var p in SaveFile.CurrentData!.Placements)
            {
                var loc = Predefined.Location(p.LocationName);
                var item = Predefined.Item(p.ItemName);
                activePlacements[(loc.GetType(), loc.UniqueId)] = item;
            }
        };
        new HL.Harmony("deathsdoor.itemchanger").PatchAll();
    }

    private Collections.Dictionary<(System.Type, string), Item> activePlacements = new();

    internal static bool TryGetPlacedItem(System.Type locationType, string id, [CA.NotNullWhen(true)] out Item? item)
    {
        if (Instance == null)
        {
            item = null;
            return false;
        }
        return Instance.activePlacements.TryGetValue((locationType, id), out item);
    }

    internal static void LogInfo(string msg)
    {
        if (Instance != null)
        {
            Instance.Logger.LogInfo(msg);
        }
    }

    internal static void LogError(string msg)
    {
        if (Instance != null)
        {
            Instance.Logger.LogError(msg);
        }
    }
}
