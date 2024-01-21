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
}