using Collections = System.Collections.Generic;
using HL = HarmonyLib;
using static HarmonyLib.CodeInstructionExtensions;
using UE = UnityEngine;

namespace DDoor.ItemChanger;

public class DropLocation : Location
{
    public string UniqueId { get; set; } = "";

    [HL.HarmonyPatch(typeof(DropItem), nameof(DropItem.Start))]
    internal static class StartPatch
    {
        internal static bool Prefix(DropItem __instance)
        {
            if (ItemChangerPlugin.TryGetPlacedItem(typeof(DropLocation), __instance.uniqueId, out var _))
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
            if (!ItemChangerPlugin.TryGetPlacedItem(typeof(DropLocation), __instance.uniqueId, out var item))
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

    // The condition for opening the belltower door is normally having
    // checked the Rusty Belltower Key location; but if an item has been
    // placed there, this becomes incorrect.
    // Change the condition to check for the actual key item instead.
    [HL.HarmonyPatch(typeof(BelltowerDoor), nameof(BelltowerDoor.Trigger))]
    private static class BelltowerDoorPatch
    {
        private static Collections.IEnumerable<HL.CodeInstruction> Transpiler(
            Collections.IEnumerable<HL.CodeInstruction> orig)
        {
            var isKeyUnlocked = typeof(GameSave).GetMethod(nameof(GameSave.IsKeyUnlocked));
            foreach (var insn in orig)
            {
                yield return insn;
                
                if (insn.Calls(isKeyUnlocked))
                {
                    yield return HL.CodeInstruction.CallClosure((System.Func<bool, bool>)ChangeBelltowerDoorCondition);
                }
            }
        }
    }

    private static bool ChangeBelltowerDoorCondition(bool shouldOpen)
    {
        if (!ItemChangerPlugin.TryGetPlacedItem(typeof(DropLocation), "trinket_rusty_key", out var _))
        {
            return shouldOpen;
        }
        return GameSave.GetSaveData().GetCountKey("trinket_rusty_key") > 0;
    }
}