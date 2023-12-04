using Collections = System.Collections.Generic;
using UE = UnityEngine;
using HL = HarmonyLib;

namespace DeathsDoor.ItemChanger;

internal class KeyItem : Item
{
    public string DisplayName { get; set; } = "";

    public string UniqueId { get; set; } = "";

    public void Trigger()
    {
        GameSave.GetSaveData().SetKeyState(UniqueId, true);
        // Open a hub door if we collect its item while in the Hall of Doors.
        //
        // The door might be null if it was seen by DoorStartupPatch but then
        // we left the room.
        if (closedHubDoors.TryGetValue(UniqueId, out var door) && door != null)
        {
            door.SetActive(true);
        }
    }

    private static Collections.Dictionary<string, UE.GameObject?> closedHubDoors = new();
    
    [HL.HarmonyPatch(typeof(ShortcutDoor), nameof(ShortcutDoor.checkStartup))]
    private static class DoorStartupPatch
    {
        private static void Prefix(ShortcutDoor __instance)
        {
            if (__instance.hubDoor && (__instance.keyId == "" || !GameSave.GetSaveData().IsKeyUnlocked(__instance.keyId)))
            {
                closedHubDoors[__instance.keyId] = __instance.gameObject;
            }
        }
    }
}