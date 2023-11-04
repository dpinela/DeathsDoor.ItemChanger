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

    internal static Collections.Dictionary<string, Item> ActiveReplacements = new();

    [HL.HarmonyPatch(typeof(DropItem), nameof(DropItem.Awake))]
    internal static class AwakePatch
    {
        internal static bool Prefix(DropItem __instance)
        {
            if (!ActiveReplacements.TryGetValue(__instance.uniqueId, out var item))
            {
                return true;
            }

            ItemChangerPlugin.Log!.LogInfo($"Awake: replacing {__instance.uniqueId} with {item.UniqueName}");

            if (item.Obtained)
            {
                UE.Object.Destroy(__instance.gameObject);
            }
            return false;
        }
    }

    [HL.HarmonyPatch(typeof(DropItem), nameof(DropItem.Start))]
    internal static class StartPatch
    {
        internal static bool Prefix(DropItem __instance, out string? __state)
        {
            __state = null;
            if (!ActiveReplacements.TryGetValue(__instance.uniqueId, out var item))
            {
                return true;
            }
            __instance.showSouls = false;
            __instance.doSpeech = false;

            ItemChangerPlugin.Log!.LogInfo($"Start: replacing {__instance.uniqueId} with {item.UniqueName}");

            if (item.Obtained)
            {
                UE.Object.Destroy(__instance.gameObject);
                return false;
            }

            // Prevent the original method from destroying the object,
            // but allow the rest of it to run.
            // We'll restore the uniqueId in the postfix.
            __state = __instance.uniqueId;
            __instance.uniqueId = "###########";
            return false;
        }

        internal static void Postfix(DropItem __instance, string? __state)
        {
            if (__state != null)
            {
                __instance.uniqueId = __state;
            }
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

            ItemChangerPlugin.Log!.LogInfo($"Trigger: replacing {__instance.uniqueId} with {item.UniqueName}");

            item.Trigger();
            __instance.poi?.gameObject?.SetActive(false);
            UE.Object.Destroy(__instance.prompt.gameObject);
            GameSave.SaveGameState();
            ShowCornerPopup(item.DisplayName);

            return false;
        }
    }

    internal static void ShowCornerPopup(string s)
    {
        foreach (var c in UICount.countList)
        {
            if (c.name == "SOULS")
            {
                if (c.notGlobal && Inventory.instance != null)
                {
                    c.lastCount = Inventory.instance.GetSoulCount();
                }
                c.count = (float)c.realCount;

                c.counter.text = s;
                return;
            }
        }
    }
}