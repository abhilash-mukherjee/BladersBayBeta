using System;
using System.Collections;
using UnityEngine;

public class DialoguePanelDisplayable: PanelDisplayable
{
    [SerializeField]
    private TMPro.TextMeshProUGUI dialogueText;
    [SerializeField]
    private float waitTimeBeforeDialogueBegins;
    [SerializeField]
    [TextArea(3, 10)]
    private string dialogue;
    [SerializeField]
    private string TYPE_SOUND;
    [SerializeField]
    private int typeSpeedSlowingFactor = 3, endOfSentenceSlowingFactor = 30;
    private Coroutine TypeSentenceCoroutine;

    protected string Dialogue { get => dialogue; set => dialogue = value; }

    protected override void Play(Transform _finalTransform, AnimationType animationType)
    {
        dialogueText.text = "";
        GameAudioManager.Instance.PauseSound(TYPE_SOUND);
        if (TypeSentenceCoroutine != null)StopCoroutine(TypeSentenceCoroutine);
        base.Play(_finalTransform, animationType);
        if (animationType == AnimationType.DISAPPEAR) return;
        string _dialogue = GetDialogue();
        TypeSentenceCoroutine = StartCoroutine(TypeSentence(_dialogue));
    }

    protected virtual string GetDialogue()
    {
        return dialogue;
    }

    IEnumerator TypeSentence(string sentence)
    {
        yield return new WaitForSeconds(waitTimeBeforeDialogueBegins);
        GameAudioManager.Instance.PlaySoundOneShot(TYPE_SOUND);
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            int i;
            if (System.Convert.ToInt32(letter) == 10)
            {
                GameAudioManager.Instance.PauseSound(TYPE_SOUND);
                i = endOfSentenceSlowingFactor;
                while (i > 0)
                {
                    yield return null;
                    i--;
                }
                GameAudioManager.Instance.PlaySoundOneShot(TYPE_SOUND);
                Debug.Log("End Of Sentence");
            }
            else
            {
                i = typeSpeedSlowingFactor;
                while (i > 0)
                {
                    yield return null;
                    i--;
                }
            }
        }
        GameAudioManager.Instance.PauseSound(TYPE_SOUND);
    }

}
