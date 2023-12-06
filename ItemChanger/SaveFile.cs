using Collections = System.Collections.Generic;
using IO = System.IO;
using Json = Newtonsoft.Json;
using UE = UnityEngine;
using HL = HarmonyLib;

namespace DeathsDoor.ItemChanger;

internal class SaveFile
{
    private string saveId;
    private SaveData? data;

    private static SaveFile? current;

    public static SaveData? CurrentData => current?.data;

    public static event System.Action? OnLoadGame;

    public SaveFile(string saveId)
    {
        try
        {
            using var file = IO.File.OpenText(Location(saveId));
            using var reader = new Json.JsonTextReader(file);
            var ser = Json.JsonSerializer.CreateDefault();
            data = ser.Deserialize<SaveData>(reader);
        }
        catch (IO.FileNotFoundException)
        {
            data = new();
        }

        this.saveId = saveId;
    }

    public void Save()
    {
        if (data == null)
        {
            return;
        }
        // Serialize the data into a buffer so that we don't destroy an existing
        // file if serialization fails.
        var json = Json.JsonConvert.SerializeObject(data);
        IO.File.WriteAllText(Location(saveId), json);
    }

    private static string Location(string saveId) =>
        IO.Path.Combine(UE.Application.persistentDataPath, "SAVEDATA", "Save_" + saveId + "-ItemChanger.json");

    [HL.HarmonyPatch(typeof(SaveSlot), nameof(SaveSlot.LoadSave))]
    private static class LoadPatch
    {
        private static void Postfix(SaveSlot __instance)
        {
            try
            {
                SaveFile.current = new(__instance.saveId);
                ItemChangerPlugin.LogInfo($"Loaded save data for save ID {__instance.saveId}");
            }
            catch (System.Exception err)
            {
                SaveFile.current = null;
                ItemChangerPlugin.LogError($"Error loading save data for save ID {__instance.saveId}: {err.ToString()}");
            }
            
            if (!__instance.saveFile.IsLoaded())
            {
                altGameModes[selectedGameMode].Effect();
            }
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
            if (SaveFile.current != null)
            {
                if (SaveFile.current.saveId != __instance.saveId)
                {
                    ItemChangerPlugin.LogError($"IMPOSSIBLE: current GameSave has ID {__instance.saveId}, current modded SaveData has ID {SaveFile.current.saveId}");
                    return;
                }
                SaveFile.current.Save();
            }
        }
    }

    private struct AltGameMode
    {
        internal string Name;
        internal System.Action Effect;
    }

    private static readonly Collections.List<AltGameMode> altGameModes = new()
    {
        new() {Name = "START", Effect = () => {}}
    };

    private static int selectedGameMode = 0;

    public static void AddGameMode(string name, System.Action effect)
    {
        altGameModes.Add(new() { Name = name, Effect = effect });
    }

    [HL.HarmonyPatch(typeof(UIObject), nameof(UIObject.onRightEvent))]
    private static class AltGameModePatch
    {
        private static void Postfix(UIObject __instance)
        {
            if (!(__instance is SaveMenu sm))
            {
                return;
            }
            if (sm.selectedSlot && sm.optionIndex == 0)
            {
                selectedGameMode = (selectedGameMode + 1) % altGameModes.Count;
                sm.selectedOptions[0].buttonText.text = altGameModes[selectedGameMode].Name;
            }
        }
    }
}

internal class SaveData
{
    public Collections.List<Placement> Placements = new();
}

internal class Placement
{
    public string LocationName = "";
    public string ItemName = "";
}
