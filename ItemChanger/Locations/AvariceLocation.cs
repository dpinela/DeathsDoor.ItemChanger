using HL = HarmonyLib;

namespace DDoorItemChanger;

internal class AvariceLocation : Location
{
    public string PowerId { get; set; } = "";

    public string UniqueId => PowerId;

    [HL.HarmonyPatch(typeof(Cutscene), nameof(Cutscene.UnlockPower))]
    private static class UnlockPowerPatch
    {
        private static bool Prefix(string id)
        {
            if (!ItemChangerPlugin.TryGetPlacedItem(typeof(AvariceLocation), id, out var item))
            {
                return true;
            }
            CornerPopup.Show(item.DisplayName);
            item.Trigger();
            return false;
        }
    }
}
