using CA = System.Diagnostics.CodeAnalysis;
using Collections = System.Collections.Generic;
using IO = System.IO;
using Json = Newtonsoft.Json;
using UE = UnityEngine;
using HL = HarmonyLib;

namespace DDoor.ItemChanger;

public class SaveData
{
    [Json.JsonProperty]
    internal Collections.Dictionary<string, Item> UnnamedPlacements = new();

    [Json.JsonProperty]
    internal Collections.Dictionary<string, string> Placements = new();

    [Json.JsonProperty]
    internal Collections.List<TrackerLogEntry> TrackerLog = new();

    // Determines which weapon is added to the inventory at the start of
    // the game.
    // Does *not* change the starting equipped weapon; that must be done
    // separately, if appropriate.
    public string StartingWeapon { get; set; } = "sword";

    public int GreenTabletDoorCost { get; set; } = 50;

    public void Place(string item, string location)
    {
        Placements[location] = item;
    }

    public void Place(Item item, string location)
    {
        UnnamedPlacements[location] = item;
    }

    [Json.JsonIgnore]
    public Collections.IReadOnlyDictionary<string, string> NamedPlacements => Placements;

    public void AddToTrackerLog(TrackerLogEntry entry)
    {
        TrackerLog.Add(entry);
        if (this == current)
        {
            try
            {
                OnTrackerLogUpdate?.Invoke(TrackerLog);
            }
            catch (System.Exception err)
            {
                ItemChangerPlugin.LogError($"Error running subscriber to SaveData.OnTrackerLogUpdate: {err}");
            }
        }
    }

    private void Save(string saveId)
    {
        // Serialize the data into a buffer so that we don't destroy an existing
        // file if serialization fails.
        var json = Json.JsonConvert.SerializeObject(this, jsonSettings);
        IO.File.WriteAllText(Location(saveId), json);
    }

    // everything below should be static

    internal static event System.Action? OnLoadGame;
    public static event System.Action<Collections.List<TrackerLogEntry>?>? OnTrackerLogUpdate;

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

    private static Json.JsonSerializerSettings jsonSettings = new()
    {
        TypeNameHandling = Json.TypeNameHandling.Auto
    };

    private static void Load(string saveId)
    {
        try
        {
            using var file = IO.File.OpenText(Location(saveId));
            using var reader = new Json.JsonTextReader(file);
            var ser = Json.JsonSerializer.CreateDefault(jsonSettings);
            current = ser.Deserialize<SaveData>(reader);
            OnTrackerLogUpdate?.Invoke(current!.TrackerLog);
        }
        catch (IO.FileNotFoundException)
        {
            current = null;
            OnTrackerLogUpdate?.Invoke(null);
        }
        catch (System.Exception err)
        {
            current = null;
            OnTrackerLogUpdate?.Invoke(null);
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

public class TrackerLogEntry
{
    public string LocationName = "";
    public string ItemName = "";
    public string ItemIcon = "";
    public float GameTime = 0;
}
