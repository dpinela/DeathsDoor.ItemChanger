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
        var loc = new DropLocation { UniqueId = "umbrella" };
        var item = HookshotItem.Instance;
        loc.Replace(item);
        new HL.Harmony("deathsdoor.itemchanger").PatchAll();
        Logger.LogInfo("Under Construction");
    }

    internal static void LogInfo(string msg)
    {
        if (Instance != null)
        {
            Instance.Logger.LogInfo(msg);
        }
    }
}
