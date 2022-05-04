using UnityEngine;

public class NameDialoguePanelDispayable : DialoguePanelDisplayable
{
    [SerializeField]
    private BeyBladeData playerData;
    [SerializeField]
    private char namePlace;
    protected override string GetDialogue()
    {
        string[] sentences = Dialogue.Split(namePlace);
        if (sentences.Length == 1) return Dialogue;
        var newDialogue = sentences[0] + playerData.PlayerName + sentences[1];
        return newDialogue;
    }
}