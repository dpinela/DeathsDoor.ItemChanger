using HL = HarmonyLib;

namespace DDoor.ItemChanger;

internal class DoorLocation : Location
{
    public string KeyId { get; set; } = "";

    public string UniqueId => KeyId;

    private const string keyPrefix = "ItemChanger-collected_door_location_";

    [HL.HarmonyPatch(typeof(ShortcutDoor), nameof(ShortcutDoor.Trigger))]
    private static class TriggerPatch
    {
        [HL.HarmonyReversePatch]
        internal static void OrigTrigger(ShortcutDoor self)
        {
            throw new System.InvalidOperationException("stub");
        }

        private static bool Prefix(ShortcutDoor __instance)
        {
            if (!ItemChangerPlugin.TryGetPlacedItem(typeof(DoorLocation), __instance.keyId, out var item))
            {
                return true;
            }

            // The check can be collected from either side of the door; if this
            // is not desirable - for instance if some form of transition rando
            // has been applied - then you should also check isHub here.

            var collectedKey = keyPrefix + __instance.keyId;
            if (!GameSave.GetSaveData().IsKeyUnlocked(collectedKey))
            {
                GameSave.GetSaveData().SetKeyState(collectedKey, true);
                CornerPopup.Show(item.DisplayName);
                item.Trigger();
            }

            // If the door is already open, allow you to go through it anyway.
            return __instance.unlocked;
        }
    }

    // Open the door immediately if you collect its item in the same room where
    // the door is.
    // This applies to doors outside the Hall of Doors, and also to the Grove
    // door in Hall of Doors (the one that is normally given at the start);
    // therefore this patch and the one in KeyItem are complementary.
    [HL.HarmonyPatch(typeof(ShortcutDoor), nameof(ShortcutDoor.FixedUpdate))]
    private static class VanillaRoomOpenPatch
    {
        private static void Postfix(ShortcutDoor __instance)
        {
            if (!__instance.unlocked && GameSave.GetSaveData().IsKeyUnlocked(__instance.keyId))
            {
                TriggerPatch.OrigTrigger(__instance);
            }
        }
    }
}