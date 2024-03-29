using HL = HarmonyLib;
using UE = UnityEngine;

namespace DDoor.ItemChanger;

internal class ShrineLocation : Location
{
    public string UniqueId { get; set; } = "";

    public Area Area { get; set; } = Area.Unknown;

    [HL.HarmonyPatch(typeof(Item_HeartContainer), nameof(Item_HeartContainer.Trigger))]
    private static class TriggerPatch
    {
        private static bool Prefix(Item_HeartContainer __instance)
        {
            if (!ItemChangerPlugin.TryGetPlacedItem(typeof(ShrineLocation), __instance.theKey.uniqueId, out var item))
            {
                return true;
            }

            // From ButtonTarget.Trigger. This would normally be called as base.Trigger
            // () but we don't have access to that here. We could use a reverse patch
            // to get it but calling that wouldn't call any hooks on
            // ButtonTarget.Trigger so it wouldn't really help with anything.
            __instance.triggered = true;

            SpeechPopup.Modify(__instance.speech, $"You obtained {item.DisplayName}!");
            PlayerGlobal.instance.PauseInput_Cutscene();
            return false;
        }
    }

    [HL.HarmonyPatch(typeof(Item_HeartContainer), nameof(Item_HeartContainer.SpeechComplete))]
    private static class SpeechCompletePatch
    {
        private static bool Prefix(Item_HeartContainer __instance)
        {
            if (!ItemChangerPlugin.TryGetPlacedItem(typeof(ShrineLocation), __instance.theKey.uniqueId, out var item))
            {
                return true;
            }

            // from the original method
            UE.Object.Destroy(__instance.uiItem3D);
            UE.Object.Destroy(__instance.gameObject);
            PlayerGlobal.instance.UnPauseInput_Cutscene();
            
            // mark the shrine as collected
            __instance.theKey.Unlock();
            GameSave.GetSaveData().IncreaseCountKey("shrine_count");

            item.Trigger();
            return false;
        }
    }
}