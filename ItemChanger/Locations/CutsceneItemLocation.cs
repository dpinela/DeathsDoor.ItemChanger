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
            CornerPopup.Show(item.DisplayName);
            item.Trigger();
            return false;
        }
    }
}