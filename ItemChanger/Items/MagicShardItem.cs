using HL = HarmonyLib;
using static HarmonyLib.CodeInstructionExtensions;
using CG = System.Collections.Generic;
using RefEmit = System.Reflection.Emit;
using UE = UnityEngine;

namespace DDoor.ItemChanger;

internal class MagicShardItem : Item
{
    public static readonly MagicShardItem Instance = new();

    public string DisplayName => Amount == 1 ? "Magic Shard" : $"{Amount} Magic Shards";

    public string Icon => "MagicShard";

    public int Amount = 1;

    public void Trigger()
    {
        var save = GameSave.GetSaveData();
        save.AddToCountKey("arrow_shard_total");
        var shards = save.GetCountKey("arrow_shard") + Amount;
        if (shards >= 4)
        {
            var chargesAdded = shards / 4;
            shards %= 4;
            save.AddToCountKey("arrow_shard_complete", chargesAdded);
            // from Item_HeartContainer.giveExtraStats
            save.AddToCountKey("extra_arrow_charges", chargesAdded);
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

    // Keep the magic point HUD in one line even when exceeding the normal maximum of six,
    // so that it doesn't end up overlapping the key HUD.
    [HL.HarmonyPatch(typeof(UIArrowChargeBar), nameof(UIArrowChargeBar.Awake))]
    private static class ExtendMagicPointsBarPatch
    {
        private static void Postfix(UIArrowChargeBar __instance)
        {
            var lg = __instance.GetComponent<UE.UI.GridLayoutGroup>();
            if (lg == null)
            {
                ItemChangerPlugin.LogInfo("missing GridLayoutGroup on the arrow charge bar");
                return;
            }
            lg.constraint = UE.UI.GridLayoutGroup.Constraint.FixedRowCount;
            lg.constraintCount = 1;
        }
    }
}