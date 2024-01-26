using HL = HarmonyLib;
using RefEmit = System.Reflection.Emit;
using static HarmonyLib.CodeInstructionExtensions;
using Collections = System.Collections.Generic;

namespace DDoor.ItemChanger;

// Because LoadDefaultValues (despite its name) runs for both newly-created
// and reloaded save files, we must replace the starting weapon every time.
[HL.HarmonyPatch(typeof(Inventory), nameof(Inventory.LoadDefaultValues))]
internal class StartingWeaponPatch
{
    private static Collections.IEnumerable<HL.CodeInstruction> Transpiler(
            Collections.IEnumerable<HL.CodeInstruction> orig)
    {
        foreach (var insn in orig)
        {
            yield return insn;

            if (insn.Is(RefEmit.OpCodes.Ldstr, "sword"))
            {
                yield return HL.CodeInstruction.CallClosure(
                    (System.Func<string, string>)ChangeStartingWeapon);
            }
        }
    }

    private static string ChangeStartingWeapon(string orig)
    {
        if (SaveData.current == null)
        {
            return orig;
        }
        return SaveData.current.StartingWeapon;
    }
}

