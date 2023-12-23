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
    
    // The Truth shrine normally lights up according to which tablet
    // locations have been checked.
    // This becomes incorrect if other items have been placed there, or
    // at the owls; change it to check for the actual items instead.
    [HL.HarmonyPatch(typeof(TruthShrine), nameof(TruthShrine.Start))]
    private static class TruthShrinePatch
    {
        private static Collections.IEnumerable<HL.CodeInstruction> Transpiler(
            Collections.IEnumerable<HL.CodeInstruction> orig)
        {
            var isKeyUnlocked = typeof(GameSave).GetMethod(nameof(GameSave.IsKeyUnlocked));
            foreach (var insn in orig)
            {
                if (insn.Calls(isKeyUnlocked))
                {
                    yield return HL.CodeInstruction.CallClosure((System.Func<GameSave, string, bool>)IsTruthShrineKeyUnlocked);
                }
                else
                {
                    yield return insn;
                }
            }
        }
    }

    private static bool IsTruthShrineKeyUnlocked(GameSave save, string key)
    {
        // Should never happen unless someone else patches TruthShrine.Start.
        if (key.Length < 5)
        {
            return save.IsKeyUnlocked(key);
        }
        var sk = key.Substring(5); // cut off "drop_" prefix
        var cond = sk == "truthtablet_7" ?
            IsAnyOwlReplaced() :
            ItemChangerPlugin.TryGetPlacedItem(typeof(DropLocation), sk, out var _);
        if (cond)
        {
            return save.GetCountKey(sk) > 0;
        }
        return save.IsKeyUnlocked(key);
    }

    private static bool IsAnyOwlReplaced() =>
        ItemChangerPlugin.TryGetPlacedItem(typeof(DropLocation), "truthshard_1", out var _) ||
        ItemChangerPlugin.TryGetPlacedItem(typeof(DropLocation), "truthshard_2", out var _) ||
        ItemChangerPlugin.TryGetPlacedItem(typeof(DropLocation), "truthshard_3", out var _);
}