using HL = HarmonyLib;

namespace DDoorItemChanger;

internal class SpellUpgradeLocation : Location
{
    public string UpgradeKey { get; set; } = "";

    public string UniqueId => UpgradeKey;

    [HL.HarmonyPatch(typeof(UpgraderSoul), nameof(UpgraderSoul.absorb))]
    private static class AbsorbPatch
    {
        private static void Prefix(UpgraderSoul __instance)
        {
            if (!__instance.absorbed && ItemChangerPlugin.TryGetPlacedItem(typeof(SpellUpgradeLocation), __instance.upgradeKey, out var item))
            {
                SpeechPopup.Modify(__instance.speech, $"You obtained {item.DisplayName}!");
            }
        }
    }

    [HL.HarmonyPatch(typeof(UpgraderSoul), nameof(UpgraderSoul.updatePlayer))]
    private static class UpdatePlayerPatch
    {
        private static void Prefix(UpgraderSoul __instance)
        {
            var wouldUpgrade = !__instance.didUpgrade && __instance.endTimer > 0 && __instance.speech.IsFinished();
            if (wouldUpgrade &&
                ItemChangerPlugin.TryGetPlacedItem(typeof(SpellUpgradeLocation), __instance.upgradeKey, out var item))
            {
                // Disable the code that would normally upgrade your ability.
                __instance.didUpgrade = true;

                item.Trigger();
            }
        }
    }
}