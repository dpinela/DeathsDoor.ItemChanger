using HL = HarmonyLib;
using UE = UnityEngine;

namespace DDoor.ItemChanger;

internal class FrogLeverLocation : Location
{
    public string UniqueId { get; set; } = "";

    private const string keyPrefix = "ItemChanger-collected_lever_location_";

    [HL.HarmonyPatch(typeof(FrogLever), nameof(FrogLever.Start))]
    private static class StartPatch
    {
        private static void Prefix(FrogLever __instance, out string __state)
        {
            var key = __instance.GetComponent<BaseKey>();
            __state = key.uniqueId;
            if (ItemChangerPlugin.TryGetPlacedItem(typeof(FrogLeverLocation), key.uniqueId, out var _))
            {
                // We need to distinguish "having pulled the lever"
                // from "having opened the gate". The former switches to using
                // a prefixed key, the latter sticks with the vanilla one.
                key.uniqueId = keyPrefix + key.uniqueId;
                // Every time we change the uniqueId of a BaseKey we must reload
                // its state, as the BaseKey object stores a copy of it after
                // it loads.
                key.loadState();
            }
        }

        private static void Postfix(FrogLever __instance, string __state)
        {
            __instance.key.uniqueId = __state;
            __instance.key.loadState();
        }
    }

    [HL.HarmonyPatch(typeof(FrogLever), nameof(FrogLever.Update))]
    private static class UpdatePatch
    {
        private static void Prefix(FrogLever __instance, out string __state)
        {
            __state = __instance.key.uniqueId;
            if (__instance.unlocking > 0 &&
                __instance.unlocking - UE.Time.deltaTime <= 0 &&
                ItemChangerPlugin.TryGetPlacedItem(typeof(FrogLeverLocation), __instance.key.uniqueId, out var item))
            {
                __instance.key.uniqueId = keyPrefix + __instance.key.uniqueId;
                CornerPopup.Show(item.DisplayName);
                item.Trigger();
            }
        }

        private static void Postfix(FrogLever __instance, string __state)
        {
            __instance.key.uniqueId = __state;
            __instance.key.loadState();
        }
    }
}