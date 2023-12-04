using Collections = System.Collections.Generic;
using SysDiag = System.Diagnostics;
using HL = HarmonyLib;
using UE = UnityEngine;

namespace DeathsDoor.ItemChanger;

public class DropLocation : Location
{
    public string UniqueId { get; set; } = "";

    [HL.HarmonyPatch(typeof(GameSave), nameof(GameSave.SetKeyState))]
    internal static class SKSPatch
    {
        internal static void Postfix(string id, bool state, bool save)
        {
            var st = new SysDiag.StackTrace(true);
            ItemChangerPlugin.LogInfo($"SET {id} = {state}");
            ItemChangerPlugin.LogInfo($"FROM: {st}");
        }
    }

    [HL.HarmonyPatch(typeof(GameSave), nameof(GameSave.AddToCountKey))]
    internal static class ATCKPatch
    {
        internal static void Postfix(string id, int quantity)
        {
            var st = new SysDiag.StackTrace(true);
            ItemChangerPlugin.LogInfo($"INC {id} += {quantity}");
            ItemChangerPlugin.LogInfo($"FROM: {st}");
        }
    }

    [HL.HarmonyPatch(typeof(GameSave), nameof(GameSave.IncreaseCountKey))]
    internal static class ICKPatch
    {
        internal static void Postfix(string id, int value)
        {
            var st = new SysDiag.StackTrace(true);
            ItemChangerPlugin.LogInfo($"INC {id} += {value}");
            ItemChangerPlugin.LogInfo($"FROM: {st}");
        }
    }

    [HL.HarmonyPatch(typeof(GameSave), nameof(GameSave.SetCountKey))]
    internal static class SCKPatch
    {
        internal static void Postfix(string id, int value)
        {
            var st = new SysDiag.StackTrace(true);
            ItemChangerPlugin.LogInfo($"SET {id} = {value}");
            ItemChangerPlugin.LogInfo($"FROM: {st}");
        }
    }

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
}