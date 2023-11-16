using Collections = System.Collections.Generic;
using HL = HarmonyLib;
using UE = UnityEngine;

namespace DDoorItemChanger;

public class DropLocation : Location
{
    public string UniqueId { get; set; } = "";

    public void Replace(Item replacement)
    {
        ActiveReplacements[UniqueId] = replacement;
    }

    internal static void ResetReplacements()
    {
        ActiveReplacements.Clear();
    }

    private static Collections.Dictionary<string, Item> ActiveReplacements = new();

    [HL.HarmonyPatch(typeof(FrogLever), nameof(FrogLever.Start))]
    internal static class FLAwakePatch
    {
        internal static void Postfix(FrogLever __instance)
        {
            if (__instance.key is {} bk)
            {
                ItemChangerPlugin.LogInfo($"Vanilla FL keyId: {bk.uniqueId}");
            }
        }
    }

    [HL.HarmonyPatch(typeof(DropItem), nameof(DropItem.Start))]
    internal static class StartPatch
    {
        internal static bool Prefix(DropItem __instance)
        {
            if (ActiveReplacements.ContainsKey(__instance.uniqueId))
            {
                __instance.showSouls = false;
                __instance.doSpeech = false;
            }
            return true;
        }
    }

    [HL.HarmonyPatch(typeof(DropItem), nameof(DropItem.Trigger))]
    internal static class TriggerPatch
    {
        internal static bool Prefix(DropItem __instance)
        {
            if (!ActiveReplacements.TryGetValue(__instance.uniqueId, out var item))
            {
                return true;
            }

            if (__instance.poi != null)
            {
                __instance.poi.gameObject.SetActive(false);
            }
            if (__instance.prompt != null)
            {
                UE.Object.Destroy(__instance.prompt.gameObject);
            }
            
            __instance.getPickedUp();
            __instance.saveCollected();
            CornerPopup.Show(item.DisplayName);
            item.Trigger();

            GameSave.SaveGameState();

            return false;
        }
    }
}