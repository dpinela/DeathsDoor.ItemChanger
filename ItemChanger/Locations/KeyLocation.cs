using HL = HarmonyLib;
using static HarmonyLib.CodeInstructionExtensions;
using RefEmit = System.Reflection.Emit;
using Collections = System.Collections.Generic;

namespace DDoor.ItemChanger;

internal class KeyLocation : Location
{
    public string UniqueId { get; set; } = "";

    [HL.HarmonyPatch(typeof(CollectableKey), nameof(CollectableKey.Update))]
    private static class UpdatePatch
    {
        private static Collections.IEnumerable<HL.CodeInstruction> Transpiler(
            Collections.IEnumerable<HL.CodeInstruction> orig)
        {
            var gainKey = typeof(CollectableKey).GetMethod(nameof(CollectableKey.GainKey));

            foreach (var insn in orig)
            {
                if (insn.Calls(gainKey))
                {
                    yield return new(RefEmit.OpCodes.Ldarg_0);
                    yield return HL.CodeInstruction.LoadField(typeof(CollectableKey), nameof(CollectableKey.keyId));
                    yield return HL.CodeInstruction.CallClosure((System.Action<CollectableKey.KeyType, string>)ChangeKeyToItem);
                }
                else
                {
                    yield return insn;
                }
            }
        }
    }

    private static void ChangeKeyToItem(CollectableKey.KeyType type, string keyId)
    {
        if (!ItemChangerPlugin.TryGetPlacedItem(typeof(KeyLocation), keyId, out var item))
        {
            CollectableKey.GainKey(type);
            return;
        }

        CornerPopup.Show(item);
        item.Trigger();
    }

    // The Grey Crow key normally unlocks after watching the initial
    // Grey Crow cutscene. However, if the player already has all of the
    // Giant Souls (or Truth Ending) upon the first visit to that Crow,
    // the key would become inaccessible.
    [HL.HarmonyPatch(typeof(KeyShrine), nameof(KeyShrine.Start))]
    private static class GreyCrowKeyPatch
    {
        private static void Postfix(KeyShrine __instance)
        {
            if (!__instance.theKey.enabled &&
                __instance.keyObj.keyId == "collectablekey_graveyardsummit" &&
                ItemChangerPlugin.AnyItemsPlaced)
            {
                __instance.doUnlock();
            }
        }
    }
}