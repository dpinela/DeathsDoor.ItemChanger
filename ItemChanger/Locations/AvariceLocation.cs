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
            item.Trigger();
            return false;
        }
    }

    [HL.HarmonyPatch(typeof(NPCCharacter), nameof(NPCCharacter.Trigger))]
    private static class TextboxPatch
    {
        private static void Prefix(NPCCharacter __instance)
        {
            if (__instance.cutscene == null)
            {
                return;
            }
            var key = __instance.cutscene.GetComponent<BaseKey>();
            if (key == null)
            {
                return;
            }

            void ModifyAvaricePopup(string powerId)
            {
                if (ItemChangerPlugin.TryGetPlacedItem(typeof(AvariceLocation), powerId, out var item))
                {
                    SpeechPopup.Modify(__instance, $"{item.DisplayName.ToUpper()} ACQUIRED");
                }
            }


            switch (key.uniqueId)
            {
                case "gift_hookshot":
                    ModifyAvaricePopup("hookshot");
                    break;
                case "gift_bombs":
                    ModifyAvaricePopup("bombs");
                    break;
                case "gift_fire":
                    ModifyAvaricePopup("fire");
                    break;
            }
        }
    }

    // If the player enters an Avarice without having the respective big door open,
    // die and choose to leave, they should return to Hall of Doors rather than the
    // room where the big door is in.
    // This is impossible in a vanilla game, but can happen if they obtain enough
    // items to access that Avarice directly from Hall of Doors instead:
    // Hookshot for Avarice 3, or Bomb plus the exit lever for Avarice 2.
    [HL.HarmonyPatch(typeof(RespawnPrompter), nameof(RespawnPrompter.Leave))]
    private static class LeavePatch
    {
        private static void Prefix(RespawnPrompter __instance)
        {
            void RedirectIfLocked(string s)
            {
                if (!GameSave.GetSaveData().IsKeyUnlocked(s))
                {
                    __instance.returnSceneId = "lvl_HallOfDoors";
                }
            }

            switch (__instance.returnDoorId)
            {
                case "hod_anc_mansion":
                    RedirectIfLocked("anc_door_mansion_unlocked");
                    break;
                case "hod_anc_forest":
                    RedirectIfLocked("anc_door_forest_unlocked");
                    break;
                case "hod_anc_fortress":
                    RedirectIfLocked("anc_door_fortress_unlocked");
                    break;
            }
        }
    }
}
