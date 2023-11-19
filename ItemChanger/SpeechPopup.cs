namespace DDoorItemChanger;

internal static class SpeechPopup
{
    public static void Modify(NPCCharacter speech, string message)
    {
        var speechKey = "ItemChanger-Temp";

        DialogueManager.instance.speechChains.Remove(speechKey);
        DialogueManager.instance.addSpeechData(new string[] { speechKey, message });
        speech.speech_id = new NPCCharacter.SpeechKey[1];
        speech.speech_id[0] = new NPCCharacter.SpeechKey
        {
            id = speechKey,
            requiredKey = "",
            unlocks = "",
            responseList = new string[0],
            nextScript = new NPCCharacter[0]
        };
    }
}
