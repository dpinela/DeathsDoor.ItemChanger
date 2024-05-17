using HL = HarmonyLib;

namespace DDoor.ItemChanger;

internal class CrowSoulLocation : Location
{
    public string UniqueId { get; set; } = "";

    public Area Area { get; set; } = Area.Unknown;

    private const string keyPrefix = "ItemChanger-collected_crow_location_";

    [HL.HarmonyPatch(typeof(SoulKey), nameof(SoulKey.Start))]
    private static class StartPatch
    {
        private static void Prefix(SoulKey __instance, out string? __state)
        {
            ItemChangerPlugin.LogInfo($"SoulKey: {GetKey(__instance)}");
            SwapCrowKey(__instance, out __state);
        }

        private static void Postfix(SoulKey __instance, string? __state)
        {
            if (__state != null)
            {
                __instance.GetComponentInChildren<NPCCharacter>().speech_id[0].unlocks = __state;
            }
        }
    }

    [HL.HarmonyPatch(typeof(SoulKey), nameof(SoulKey.Trigger))]
    private static class TriggerPatch
    {
        private static bool Prefix(SoulKey __instance)
        {
            var key = GetKey(__instance);
            if (!ItemChangerPlugin.TryGetPlacedItem(typeof(CrowSoulLocation), key, out var item))
            {
                return true;
            }
            CornerPopup.Show(item);
            item.Trigger();
            GameSave.GetSaveData().SetKeyState(keyPrefix + key, true);
            __instance.isCollected = true;
            __instance.key = null;
            return false;
        }
    }

    private static void SwapCrowKey(SoulKey crow, out string? state)
    {
        var key = GetKey(crow);
        if (ItemChangerPlugin.TryGetPlacedItem(typeof(CrowSoulLocation), key, out var _))
        {
            crow.GetComponentInChildren<NPCCharacter>().speech_id[0].unlocks = keyPrefix + key;
            state = key;
        }
        else
        {
            state = null;
        }
    }

    private static string GetKey(SoulKey crow) =>
        crow.GetComponentInChildren<NPCCharacter>().speech_id[0].unlocks;
}