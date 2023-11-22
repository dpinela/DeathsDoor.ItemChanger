using HL = HarmonyLib;
using UE = UnityEngine;

namespace DDoorItemChanger;

internal class IronLeverLocation : Location
{
    public string UniqueId { get; set; } = "";

    private const string keyPrefix = "ItemChanger-collected_lever_location_";

    [HL.HarmonyPatch(typeof(IronPullSwitch), nameof(IronPullSwitch.Start))]
    private static class StartPatch
    {
        private static void Prefix(IronPullSwitch __instance, out string __state)
        {
            var key = __instance.GetComponent<BaseKey>();
            __state = key.uniqueId;
            if (ItemChangerPlugin.TryGetPlacedItem(typeof(IronLeverLocation), key.uniqueId, out var _))
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

        private static void Postfix(IronPullSwitch __instance, string __state)
        {
            __instance.keyComponent.uniqueId = __state;
            __instance.keyComponent.loadState();
        }
    }

    [HL.HarmonyPatch(typeof(IronPullSwitch), nameof(IronPullSwitch.FixedUpdate))]
    private static class FixedUpdatePatch
    {
        private static void Prefix(IronPullSwitch __instance, out string __state)
        {
            __state = __instance.keyComponent.uniqueId;
            if (__instance.delay > 0 &&
                __instance.delay - UE.Time.fixedDeltaTime <= 0 &&
                ItemChangerPlugin.TryGetPlacedItem(typeof(IronLeverLocation), __instance.keyComponent.uniqueId, out var item))
            {
                __instance.keyComponent.uniqueId = keyPrefix + __instance.keyComponent.uniqueId;
                CornerPopup.Show(item.DisplayName);
                item.Trigger();
            }
        }

        private static void Postfix(IronPullSwitch __instance, string __state)
        {
            __instance.keyComponent.uniqueId = __state;
            __instance.keyComponent.loadState();
        }
    }
}