using Collections = System.Collections.Generic;
using HL = HarmonyLib;

namespace DDoor.ItemChanger;

internal class CutsceneItemLocation : Location
{
    public string ItemId { get; set; } = "";

    public string UniqueId => ItemId;

    private const string grandmaSoulKey = "soul_gran";
    private const string frogKingSoulKey = "soul_frog";
    private const string bettySoulKey = "soul_yeti";

    [HL.HarmonyPatch(typeof(Cutscene), nameof(Cutscene.AddItem))]
    private static class AddItemPatch
    {
        private static bool Prefix(string itemId)
        {
            if (!ItemChangerPlugin.TryGetPlacedItem(typeof(CutsceneItemLocation), itemId, out var item))
            {
                return true;
            }
            // Negate the increment of this variable that the game does after
            // a Giant Soul fight.
            // It would be preferable to suppress the increment in the first place,
            // but there is not enough context at the point of that call to
            // distinguish it from one that we do ourselves.
            switch (itemId)
            {
                case bettySoulKey:
                case frogKingSoulKey:
                case grandmaSoulKey:
                    GameSave.GetSaveData().IncreaseCountKey("boss_souls", -1);
                    break;
            }
            CornerPopup.Show(item.DisplayName);
            item.Trigger();
            return false;
        }
    }

    // The Grey Crow door cutscene normally checks whether the player has
    // defeated the Giant Soul bosses, which normally give the corresponding
    // items.
    // If any of these bosses has been changed to give a different item,
    // make this cutscene check for the Giant Soul items instead.
    // This presumes that any original Giant Soul item that was replaced
    // has been placed somewhere else instead.
    [HL.HarmonyPatch(typeof(CombinedKey), nameof(CombinedKey.checkUnlocked))]
    private static class GreyCrowPatch
    {
        private static bool Prefix(CombinedKey __instance, ref bool __result)
        {
            var isGreyCrowKey =
                __instance.keys.Length == 3 &&
                __instance.keys[0] == "c_grandead" &&
                __instance.keys[1] == "c_frogdead" &&
                __instance.keys[2] == "c_yetidead";
            var someGiantSoulReplaced =
                ItemChangerPlugin.TryGetPlacedItem(typeof(CutsceneItemLocation), grandmaSoulKey, out var _) ||
                ItemChangerPlugin.TryGetPlacedItem(typeof(CutsceneItemLocation), frogKingSoulKey, out var _) ||
                ItemChangerPlugin.TryGetPlacedItem(typeof(CutsceneItemLocation), bettySoulKey, out var _);
            if (isGreyCrowKey && someGiantSoulReplaced)
            {
                var save = GameSave.GetSaveData();
                var numSouls =
                    save.GetCountKey(grandmaSoulKey) +
                    save.GetCountKey(frogKingSoulKey) +
                    save.GetCountKey(bettySoulKey);
                __result = numSouls >= 3;
                return false;
            }
            return true;
        }
    }
}