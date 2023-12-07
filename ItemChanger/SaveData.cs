using Collections = System.Collections.Generic;
using IO = System.IO;
using Json = Newtonsoft.Json;
using UE = UnityEngine;
using HL = HarmonyLib;

namespace DeathsDoor.ItemChanger;

public class SaveData
{
    public Collections.List<Placement> Placements = new();

    private void Save(string saveId)
    {
        // Serialize the data into a buffer so that we don't destroy an existing
        // file if serialization fails.
        var json = Json.JsonConvert.SerializeObject(this);
        IO.File.WriteAllText(Location(saveId), json);
    }

    // everything below should be static

    internal static event System.Action? OnLoadGame;

    internal static SaveData? current;

    public static SaveData Open()
    {
        if (current == null)
        {
            current = new();
        }
        return current;
    }

    private static string Location(string saveId) =>
        IO.Path.Combine(UE.Application.persistentDataPath, "SAVEDATA", "Save_" + saveId + "-ItemChanger.json");

    private static void Load(string saveId)
    {
        try
        {
            using var file = IO.File.OpenText(Location(saveId));
            using var reader = new Json.JsonTextReader(file);
            var ser = Json.JsonSerializer.CreateDefault();
            current = ser.Deserialize<SaveData>(reader);
        }
        catch (IO.FileNotFoundException)
        {
            current = null;
        }
        catch (System.Exception err)
        {
            current = null;
            ItemChangerPlugin.LogError($"Error loading save data for save ID {saveId}: {err.ToString()}");
        }
    }

    [HL.HarmonyPatch(typeof(SaveSlot), nameof(SaveSlot.LoadSave))]
    private static class LoadPatch
    {
        private static void Prefix(SaveSlot __instance)
        {
            Load(__instance.saveId);
        }

        private static void Postfix()
        {
            OnLoadGame?.Invoke();
        }
    }

    [HL.HarmonyPatch(typeof(SaveSlot), nameof(SaveSlot.EraseSave))]
    private static class ErasePatch
    {
        private static void Postfix(SaveSlot __instance)
        {
            try
            {
                IO.File.Delete(Location(__instance.saveId));
                ItemChangerPlugin.LogInfo($"Save data deleted for save ID {__instance.saveId}");
            }
            catch (IO.IOException)
            {
                ItemChangerPlugin.LogInfo($"No save data deleted for save ID {__instance.saveId}");
            }
        }
    }

    [HL.HarmonyPatch(typeof(GameSave), nameof(GameSave.Save))]
    private static class SavePatch
    {
        private static void Postfix(GameSave __instance)
        {
            if (current != null)
            {
                current.Save(__instance.saveId);
            }
        }
    }
}

public class Placement
{
    public string LocationName = "";
    public string ItemName = "";
}
