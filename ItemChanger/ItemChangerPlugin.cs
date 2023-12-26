using CA = System.Diagnostics.CodeAnalysis;
using Collections = System.Collections.Generic;
using Bep = BepInEx;
using HL = HarmonyLib;

namespace DDoor.ItemChanger;

[Bep.BepInPlugin("deathsdoor.itemchanger", "ItemChanger", "1.0.1.0")]
internal class ItemChangerPlugin : Bep.BaseUnityPlugin
{
    private static ItemChangerPlugin? Instance;

    public void Start()
    {
        Instance = this;
        SaveData.OnLoadGame += () =>
        {
            activePlacements.Clear();

            if (SaveData.current == null)
            {
                return;
            }

            foreach (var p in SaveData.current.Placements)
            {
                var locOK = Predefined.TryGetLocation(p.LocationName, out var loc);
                var itemOK = Predefined.TryGetItem(p.ItemName, out var item);
                if (!locOK)
                {
                    Logger.LogError($"location {p.LocationName} does not exist");
                }
                if (!itemOK)
                {
                    Logger.LogError($"item {p.ItemName} does not exist");
                }
                if (itemOK && locOK)
                {
                    // The compiler can't tell, but loc and item are guaranteed non-null at this point.
                    activePlacements[(loc!.GetType(), loc!.UniqueId)] = item!;
                }
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

    internal static bool AnyItemsPlaced =>
        Instance != null && Instance.activePlacements.Count != 0;

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
