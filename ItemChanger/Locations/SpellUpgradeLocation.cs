using HL = HarmonyLib;

namespace DeathsDoor.ItemChanger;

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

    private const string locationCollectedKey = "ItemChanger-collected_spell_upgrade_location_";

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
                GameSave.GetSaveData().SetKeyState(locationCollectedKey + __instance.upgradeKey, true, false);
            }
        }
    }

    [HL.HarmonyPatch(typeof(DoorTrigger), nameof(DoorTrigger.Awake))]
    private static class EntryConditionPatch
    {
        private static void Prefix(DoorTrigger __instance)
        {
            void AlterDoorCondition(string vanillaSpell)
            {
                if (ItemChangerPlugin.TryGetPlacedItem(typeof(SpellUpgradeLocation), vanillaSpell, out var _))
                {
                    __instance.destroyKey = locationCollectedKey + vanillaSpell;
                }
            }

            switch (__instance.doorId)
            {
                case "tdoor_hookshot":
                    AlterDoorCondition("hookshot");
                    break;
                case "tdoor_fire":
                    AlterDoorCondition("fire");
                    break;
                case "tdoor_bombs":
                    AlterDoorCondition("bombs");
                    break;
                // not a typo, this door's name really is just inconsistent with
                // the upgradeKey for arrows
                case "tdoor_arrow":
                    AlterDoorCondition("arrows");
                    break;
            }
        }
    }
}