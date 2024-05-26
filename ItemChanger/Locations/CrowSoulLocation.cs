using Reflection = System.Reflection;
using CG = System.Collections.Generic;
using HL = HarmonyLib;
using static HarmonyLib.CodeInstructionExtensions;
using UE = UnityEngine;

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
            
            SoundEngine.Event("CrowGhostFly", __instance.gameObject);
            SoundEngine.Event("CrowSoulResume", __instance.gameObject);
            __instance.anim.SetTrigger("rise");
            __instance.isCollected = true;
            __instance.key = null;
            // Make the crow disappear after being collected; for vanilla crows,
            // the charge cutscene handles this.
            var d = __instance.gameObject.AddComponent<DelayedCrowDeactivator>();
            d.key = __instance;
            d.enabled = true;
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
    
    // The cutscene where the crow charges at the ancient door (triggered by
    // obtaining a crow item) is programmed to destroy the original crow pickup
    // at the end.
    // This is not what we want when that crow pickup has been replaced.
    [HL.HarmonyPatch(typeof(CrowSoulCharge), nameof(CrowSoulCharge.Update))]
    private static class ChargeCutsceneUpdatePatch
    {
        private static CG.IEnumerable<HL.CodeInstruction> Transpiler(
            CG.IEnumerable<HL.CodeInstruction> orig)
        {
            var destroy = typeof(UE.Object).GetMethod(nameof(UE.Object.Destroy),
                new System.Type[] { typeof(UE.Object) });
            // We only want to rewrite the *second* call to Object.Destroy.
            foreach (var insn in orig)
            {
                yield return insn;
                if (insn.Calls(destroy))
                {
                    break;
                }
            }
            foreach (var insn in orig)
            {
                if (insn.Calls(destroy))
                {
                    yield return HL.CodeInstruction.CallClosure((System.Action<UE.GameObject>)DestroyIfVanillaCrow);
                }
                else
                {
                    yield return insn;
                }
            }
        }
    }

    private static void DestroyIfVanillaCrow(UE.GameObject obj)
    {
        var key = obj.GetComponent<BaseKey>().uniqueId;
        if (!ItemChangerPlugin.TryGetPlacedItem(typeof(CrowSoulLocation), key, out var _))
        {
            UE.Object.Destroy(obj);
        }
    }

    private class DelayedCrowDeactivator : UE.MonoBehaviour
    {
        public SoulKey? key;

        public void Update()
        {
            if (key!.riseTween >= 1)
            {
                // Flash the screen to cover up the crow's sudden disappearance.
                ScreenFade.instance.SetColor(new UE.Color(1, .514f, .665f, 1));
                ScreenFade.instance.FadeIn(2.5f);
                // We cannot just destroy the crow object. For some reason, that
                // causes the vanilla crow charge cutscene to trigger.
                // Deactivating it is sufficient.
                gameObject.SetActive(false);
                UE.Object.Destroy(this);
            }
        }
    }
}