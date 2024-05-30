using HL = HarmonyLib;
using static HarmonyLib.CodeInstructionExtensions;
using CG = System.Collections.Generic;
using RefEmit = System.Reflection.Emit;

namespace DDoor.ItemChanger;

internal class MagicShardItem : Item
{
    private MagicShardItem() {}

    public static readonly MagicShardItem Instance = new();

    public string DisplayName => "Magic Shard";

    public string Icon => "MagicShard";

    public void Trigger()
    {
        var save = GameSave.GetSaveData();
        save.AddToCountKey("arrow_shard_total");
        var shards = save.GetCountKey("arrow_shard") + 1;
        if (shards >= 4)
        {
            shards = 0;
            save.AddToCountKey("arrow_shard_complete");
            // from Item_HeartContainer.giveExtraStats
            save.AddToCountKey("extra_arrow_charges");
            WeaponSwitcher.instance.Refresh();
            UIArrowChargeBar.instance.SetMaxChargeDelayed();
        }
        save.SetCountKey("arrow_shard", shards);
    }

    // _ArrowPower.Start hard caps the amount of magic points that can be held at 6
    // (the initial 4 + 2 extra from shards), but this is entirely redundant in a
    // vanilla game since there are only 8 magic shrines to begin with. We remove the
    // cap so that excess magic shard items added through this mod work as expected.
    private const int patchedMPCap = 999_999_999;

    [HL.HarmonyPatch(typeof(_ArrowPower), nameof(_ArrowPower.Start))]
    private static class UncapMagicPointsPatch
    {
        private static CG.IEnumerable<HL.CodeInstruction> Transpiler(
            CG.IEnumerable<HL.CodeInstruction> orig)
        {
            foreach (var insn in orig)
            {
                if (insn.LoadsConstant(2))
                {
                    yield return new(RefEmit.OpCodes.Ldc_I4, patchedMPCap);
                }
                else
                {
                    yield return insn;
                }
            }
        }
    }

    // The inventory counters for shards normally turn off when the vanilla maximum of
    // 8 of either is collected. Override that when shards beyond that limit are obtained.
    // (This retains the vanilla behaviour when the number of shards is a multiple of 4,
    // but that's good enough since in that case the counter would always show 0 anyway.)
    [HL.HarmonyPatch(typeof(UICollectableCellLimited), nameof(UICollectableCellLimited.checkItem))]
    private static class UncapInventoryShardCounterPatch
    {
        private static void Postfix(UICollectableCellLimited __instance)
        {
            if (GameSave.GetSaveData().GetCountKey(__instance.itemId) > 0)
            {
                __instance.counter.gameObject.SetActive(true);
            }
        }
    }
}