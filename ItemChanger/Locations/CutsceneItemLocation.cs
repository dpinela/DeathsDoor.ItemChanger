using Collections = System.Collections.Generic;
using HL = HarmonyLib;

// Cutscene.AddItem soul_gran, soul_frog, soul_yeti
// Cutscene.UnlockPower
// ShortcutDoor.Trigger
namespace DDoorItemChanger;

internal class CutsceneItemLocation : Location
{
    public string ItemId { get; set; } = "";

    public void Replace(Item replacement)
    {
        if (replacement == null)
        {
            throw new System.InvalidOperationException("replacement item must be non-null");
        }
        ActiveReplacements[ItemId] = replacement;
    }

    internal static void ResetReplacements()
    {
        ActiveReplacements.Clear();
    }

    private static Collections.Dictionary<string, Item> ActiveReplacements = new();

    [HL.HarmonyPatch(typeof(Cutscene), nameof(Cutscene.AddItem))]
    private static class AddItemPatch
    {
        private static bool Prefix(string itemId)
        {
            if (!ActiveReplacements.TryGetValue(itemId, out var item))
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
                case "soul_yeti":
                case "soul_frog":
                case "soul_gran":
                    GameSave.GetSaveData().IncreaseCountKey("boss_souls", -1);
                    break;
            }
            CornerPopup.Show(item.DisplayName);
            item.Trigger();
            return false;
        }
    }
}