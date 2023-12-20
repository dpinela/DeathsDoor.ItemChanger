using HL = HarmonyLib;
using RefEmit = System.Reflection.Emit;
using static HarmonyLib.CodeInstructionExtensions;
using Collections = System.Collections.Generic;

namespace DDoor.ItemChanger;

internal class DoorLocation : Location
{
    public string KeyId { get; set; } = "";

    public string UniqueId => KeyId;

    private const string keyPrefix = "ItemChanger-collected_door_location_";
    private const string dfsKey = "bosskill_forestmother";
    private const string dfsAltKey = "ItemChanger-DFS_killed";
    private const string groveDoorKey = "sdoor_tutorial";

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
            var save = GameSave.GetSaveData();
            if (!save.IsKeyUnlocked(collectedKey))
            {
                save.SetKeyState(collectedKey, true);
                CornerPopup.Show(item.DisplayName);
                item.Trigger();

                // Darwin normally only wakes up after defeating DFS.
                // If the Grove of Spirits door is replaced by something
                // else, this is problematic as it prevents the player from
                // upgrading stats until potentially much later in the game.
                //
                // It would be preferrable to directly patch whatever is
                // making the decision to wake Darwin up, but it has been
                // very difficult to locate the exact object that does it.
                //
                // We set these keys after the Grove of Spirits door check
                // because setting the DFS one earlier also disables the
                // Chandler cutscene, which triggers the check in the first
                // place.
                if (__instance.keyId == groveDoorKey)
                {
                    save.SetKeyState("shop_prompted", true);
                    save.SetKeyState(dfsKey, true);
                }
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

    // Since we are using the DFS flag for its side effects above,
    // we must use a different one for the primary purpose of recording
    // whether DFS herself has actually been killed.
    [HL.HarmonyPatch(typeof(ForestMother), nameof(ForestMother.Start))]
    private static class DFSStartPatch
    {
        private static Collections.IEnumerable<HL.CodeInstruction> Transpiler(
            Collections.IEnumerable<HL.CodeInstruction> orig)
        {
            foreach (var insn in orig)
            {
                yield return insn;

                if (insn.Is(RefEmit.OpCodes.Ldstr, dfsKey))
                {
                    yield return HL.CodeInstruction.CallClosure(
                        (System.Func<string, string>)ChangeDFSStartCondition);
                }
            }
        }
    }

    private static string ChangeDFSStartCondition(string cond)
    {
        if (!ItemChangerPlugin.TryGetPlacedItem(typeof(DoorLocation), groveDoorKey, out var _))
        {
            return cond;
        }
        return dfsAltKey;
    }

    [HL.HarmonyPatch(typeof(ForestMother), nameof(ForestMother.OnDeath))]
    private static class DFSEndPatch
    {
        private static void Postfix()
        {
            if (ItemChangerPlugin.TryGetPlacedItem(typeof(DoorLocation), groveDoorKey, out var _))
            {
                GameSave.GetSaveData().SetKeyState(dfsAltKey, true);
            }
        }
    }
}