using HL = HarmonyLib;

namespace DDoor.ItemChanger;

[HL.HarmonyPatch(typeof(CounterKey), nameof(CounterKey.loadState))]
internal static class GreenTabletDoorPatch
{
    private static void Prefix(CounterKey __instance)
    {
        if (SaveData.current != null &&
            __instance.requiredCount == 50 &&
            __instance.uniqueId == "plant_count" &&
            __instance.gameObject.name == "TruthDoor")
        {
            __instance.requiredCount = SaveData.current.GreenTabletDoorCost;
        }
    }
}
