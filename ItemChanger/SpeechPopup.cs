namespace DDoor.ItemChanger;

internal static class SpeechPopup
{
    private const string speechKey = "ItemChanger-Temp";

    public static void Modify(NPCCharacter speech, string message)
    {
        speech.speech_id = new NPCCharacter.SpeechKey[1];
        Modify(speech, 0, message);
    }

    public static void Modify(NPCCharacter speech, int i, string message)
    {
        DialogueManager.instance.speechChains.Remove(speechKey);
        DialogueManager.instance.addSpeechData(new string[] { speechKey, message });
        speech.speech_id[i] = new NPCCharacter.SpeechKey
        {
            id = speechKey,
            requiredKey = "",
            unlocks = "",
            responseList = new string[0],
            nextScript = new NPCCharacter[0]
        };
    }
}
