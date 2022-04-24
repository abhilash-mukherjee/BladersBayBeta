using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CanvasDisplayManager : MonoBehaviour
{
    public UnityEvent OnCanvasBeginingReached;
    [SerializeField]
    public List<DisplayableSlot> displayableSlots = new List<DisplayableSlot>();
    [SerializeField]
    private float deactivatePreviousPanelTime = 0.5f;
    [SerializeField]
    private float activateNextPanelTime = 0.25f;
    private Stack<DisplayableSlot> displayableStackForward, displayableStackReverse;
    private DisplayableSlot currentDisplayableSlot, previousDisplayableSlot;
    public DisplayableSlot CurrentDisplayableSlot
    {
        get { return currentDisplayableSlot; }
    }

    private int displayableSlotListCount = 0;
    public int DisplayableSlotListCount { get => displayableSlotListCount; }

    
    private void Awake()
    {
        displayableStackForward = new Stack<DisplayableSlot>();
        displayableStackReverse = new Stack<DisplayableSlot>();
        for(int i = displayableSlots.Count -1; i>=0;i--)
        {
            if (HasDuplicateEntry(i))
                return;
            displayableStackForward.Push(displayableSlots[i]);
        }
        displayableSlotListCount = displayableSlots.Count;
    }

    private bool HasDuplicateEntry(int i)
    {
        if (displayableSlots.FindAll(p => p == displayableSlots[i]).Count > 1)
        {
            Debug.LogError("Duplicate vale entered in DisplayableSlot list");
            return true;
        }
        return false;
    }

    private void OnEnable()
    {
        TutorialManager.OnBackClicked += Back;
        TutorialManager.OnNextClicked += Next;
    }

    private void OnDisable()
    {
        TutorialManager.OnBackClicked -= Back;
        TutorialManager.OnNextClicked -= Next;

    }
    private void Start()
    {
    }

    public void StartDisplay()
    {
        currentDisplayableSlot = displayableStackForward.Pop();
        currentDisplayableSlot.AppearForward();
    }
    public void Next()
    {
        if(displayableStackForward.Count == 0)
        {
            Debug.Log("No more Panel");
            return;
        }
        previousDisplayableSlot = currentDisplayableSlot;
        displayableStackReverse.Push(previousDisplayableSlot);
        currentDisplayableSlot = displayableStackForward.Pop();
        previousDisplayableSlot.DisappearForward();
        currentDisplayableSlot.AppearForward();
    }

    public void Back()
    {
        if (displayableStackReverse.Count == 0)
        {
            Debug.Log("No more Panel");
            return;
        }
        previousDisplayableSlot = currentDisplayableSlot;
        currentDisplayableSlot = displayableStackReverse.Pop();
        displayableStackForward.Push(previousDisplayableSlot);
        previousDisplayableSlot.DisappearReverse();
        currentDisplayableSlot.AppearReverse();
    }

}
