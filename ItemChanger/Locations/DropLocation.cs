using Collections = System.Collections.Generic;
using Reflection = System.Reflection;
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

    private const string forestHornKey = "trinket_basoon";
    private const string locketKey = "trinket_locket";
    private const string teddyKey = "trinket_teddy";
    private const string belltowerKey = "trinket_rusty_key";

    private static bool ChangeBelltowerDoorCondition(bool shouldOpen)
    {
        if (!ItemChangerPlugin.TryGetPlacedItem(typeof(DropLocation), belltowerKey, out var _))
        {
            return shouldOpen;
        }
        return GameSave.GetSaveData().GetCountKey(belltowerKey) > 0;
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

    // The Steadhone door normally checks for the Locket location instead of
    // the item.
    [HL.HarmonyPatch(typeof(CutsceneControl), nameof(CutsceneControl.check))]
    private static class SteadhoneDoorPatch
    {
        private static bool Prefix(CutsceneControl __instance)
        {
            if (!(__instance.gameObject.name == "GD_NIGHT" &&
                  ItemChangerPlugin.TryGetPlacedItem(typeof(DropLocation), locketKey, out var _)))
            {
                return true;
            }

            if (GameSave.GetSaveData().GetCountKey(locketKey) > 0)
            {
                var s = __instance.stages[0];
                s.triggerEvent?.Invoke();
                // We know turnOff and turnOn aren't null for this particular
                // object.
                s.turnOff.SetActive(false);
                s.turnOn.SetActive(true);
                // Not strictly necessary, but might as well, just in case
                s.used = true;
            }
            return false;
        }
    }

    // The same applies for the Magical Forest Horn interaction.
    [HL.HarmonyPatch]
    private static class ForestHornPatch
    {
        private static Collections.IEnumerable<Reflection.MethodInfo> TargetMethods()
        {
            yield return typeof(BaseLock).GetMethod(nameof(BaseLock.KeysAreUnlocked));
            yield return typeof(BaseLock).GetMethod(nameof(BaseLock.KeysAreUnlockedImmediate));
        }

        private static bool Prefix(BaseLock __instance, ref bool __result)
        {
            if (__instance is ActivationLock &&
                __instance.key.Length == 1 &&
                __instance.key[0].uniqueId == "drop_trinket_basoon" &&
                ItemChangerPlugin.TryGetPlacedItem(typeof(DropLocation), forestHornKey, out var _))
            {
                __result = GameSave.GetSaveData().GetCountKey(forestHornKey) > 0;
                return false;
            }
            return true;
        }
    }

    // The same applies for the Jefferson interactions.
    [HL.HarmonyPatch(typeof(JeffersonBackpackStarter), nameof(JeffersonBackpackStarter.canUse))]
    private static class JeffersonBackpackPatch
    {
        private static bool Prefix(ref bool __result)
        {
            if (ItemChangerPlugin.TryGetPlacedItem(typeof(DropLocation), teddyKey, out var _))
            {
                __result = GameSave.GetSaveData().GetCountKey(teddyKey) > 0;
                return false;
            }
            return true;
        }
    }

    [HL.HarmonyPatch(typeof(NPCCharacter), nameof(NPCCharacter.GetCurrentTextId))]
    private static class JeffersonDialoguePatch
    {
        private static void Postfix(NPCCharacter __instance, ref string __result)
        {
            if (__instance.currentSpeechIndex == 1 &&
                __instance.gameObject.name == "NPC_jeffersonNight_Pickup" &&
                ItemChangerPlugin.TryGetPlacedItem(typeof(DropLocation), teddyKey, out var _) &&
                GameSave.GetSaveData().GetCountKey(teddyKey) <= 0)
            {
                __instance.currentSpeechIndex = 0;
                __result = __instance.speech_id[0].id;
            }
        }
    }
}