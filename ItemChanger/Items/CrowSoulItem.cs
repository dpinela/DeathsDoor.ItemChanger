using CG = System.Collections.Generic;
using HL = HarmonyLib;
using UE = UnityEngine;

namespace DDoor.ItemChanger;

internal class CrowSoulItem : Item
{
    public string UniqueId { get; set; } = "";

    public string DisplayName { get; set; } = "";

    public string Icon => "CrowSoul";

    public void Trigger()
    {
        var save = GameSave.GetSaveData();
        save.SetKeyState(UniqueId, true);
        save.AddToCountKey("crow_soul_count");
        // Trigger the crow cutscene if we collect a crow item while in the area of the door
        // that the crow unlocks.
        // Otherwise, we'd have to wait until we reenter the room.
        // These GameObjects may be null if they were seen by the hooks in this file but then
        // we left the room.
        var uc = untriggeredCutscenes[UniqueId];
        if (uc.CameraFocus != null)
        {
            uc.CameraFocus.GetComponent<CameraFocusTrigger>().key[0].loadState();
        }
        if (uc.CrowCharge != null)
        {
            uc.CrowCharge.GetComponent<CrowSoulCharge>().key[0].loadState();
        }
    }

    private static CG.Dictionary<string, UntriggeredCutscene> untriggeredCutscenes = new()
    {
        {"crowskele_mansion_1", new()},
        {"crowskele_mansion_2", new()},
        {"crowskele_mansion_3", new()},
        {"crowskele_mansion_4", new()},
        {"crowskele_forest_1", new()},
        {"crowskele_forest_2", new()},
        {"crowskele_forest_3", new()},
        {"crowskele_forest_4", new()},
        {"crowskele_fortress_1", new()},
        {"crowskele_fortress_2", new()},
        {"crowskele_fortress_3", new()},
        {"crowskele_fortress_4", new()},
    };

    [HL.HarmonyPatch(typeof(CameraFocusTrigger), nameof(CameraFocusTrigger.Start))]
    private static class ChargeCutscenePatch
    {
        private static void Postfix(CameraFocusTrigger __instance)
        {
            var key = __instance.key[0].uniqueId;
            if (untriggeredCutscenes.TryGetValue(key, out var uc) && !GameSave.GetSaveData().IsKeyUnlocked(key))
            {
                uc.CameraFocus = __instance.gameObject;
            }
        }
    }

    [HL.HarmonyPatch(typeof(CrowSoulCharge), nameof(CrowSoulCharge.Start))]
    private static class ChargeCutscenePatch2
    {
        private static void Postfix(CrowSoulCharge __instance)
        {
            var key = __instance.key[0].uniqueId;
            if (untriggeredCutscenes.TryGetValue(key, out var uc) && !GameSave.GetSaveData().IsKeyUnlocked(key))
            {
                uc.CrowCharge = __instance.gameObject;
            }
        }
    }

    private class UntriggeredCutscene
    {
        internal UE.GameObject? CameraFocus, CrowCharge;
    }
}