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
}
