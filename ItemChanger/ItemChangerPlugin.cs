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
            SaveFile.CurrentData!.Placements.Add(
                new() { LocationName = "Discarded_Umbrella", ItemName = "Hookshot" }
            );
        };
        SaveFile.OnLoadGame += () =>
        {
            DropLocation.ResetReplacements();
            foreach (var p in SaveFile.CurrentData!.Placements)
            {
                var loc = Predefined.Location(p.LocationName);
                var item = Predefined.Item(p.ItemName);
                loc.Replace(item);
            }
        };
        new HL.Harmony("deathsdoor.itemchanger").PatchAll();
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
