using Bep = BepInEx;
using HL = HarmonyLib;

namespace DDoorItemChanger;

[Bep.BepInPlugin("deathsdoor.itemchanger", "ItemChanger", "1.0.0.0")]
internal class ItemChangerPlugin : Bep.BaseUnityPlugin
{
    internal static Bep.Logging.ManualLogSource? Log;

    public void Start()
    {
        Log = Logger;
        var loc = new DropLocation { UniqueId = "umbrella" };
        var item = HookshotItem.Instance;
        loc.Replace(item);
        new HL.Harmony("deathsdoor.itemchanger").PatchAll();
        Logger.LogInfo("Under Construction");
    }
}
