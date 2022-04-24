using UnityEngine;
using JMRSDK.InputModule;
using UnityEngine.Events;

public class QuitDisplayManager : MonoBehaviour, IBackHandler, IHomeHandler, IMenuHandler
{
    public UnityEvent OnTournamentQuit;
    [SerializeField]
    private Vector3 maxScale = Vector3.one * 0.66f;
    [SerializeField]
    private float lerpSpeed = 10f;
    private bool hasPoppedQuitMessege = false;
    private bool hasRemovedQuitMessege = false;
    private bool shouldPoopUpQuitMessege = false;
    private bool shouldRemoveQuitMessege = false;

    private void Awake()
    {
        transform.localScale = Vector3.zero;
    }
    private void Start()
    {
        JMRInputManager.Instance.AddGlobalListener(gameObject);
    }
    private void Update()
    {
        ShowQuitMessege();
        //RemoveQuitMessege();
    }
    public void OnBackAction()
    {
        shouldPoopUpQuitMessege = true;
        hasPoppedQuitMessege = false;
        Time.timeScale = 0f;

    }

    public void OnHomeAction()
    {
        shouldPoopUpQuitMessege = true;
        hasPoppedQuitMessege = false;
        Time.timeScale = 0f;
    }

    public void OnMenuAction()
    {
        shouldPoopUpQuitMessege = true;
        hasPoppedQuitMessege = false;
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        transform.localScale = Vector3.zero;
        shouldPoopUpQuitMessege = false;
        Time.timeScale = 1f;
    }

    public void Back()
    {
        Time.timeScale = 1f;
        OnTournamentQuit?.Invoke();
        Debug.Log("Back Pressed");
    }
    private void ShowQuitMessege()
    {

        if (transform.localScale.magnitude >= maxScale.magnitude || hasPoppedQuitMessege)
        {
            hasPoppedQuitMessege = true;
            return;
        }
        if (shouldPoopUpQuitMessege)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, maxScale, Time.unscaledDeltaTime * lerpSpeed);
        }

    }
    private void RemoveQuitMessege()
    {

        if (transform.localScale.magnitude >= maxScale.magnitude || hasRemovedQuitMessege)
        {
            hasRemovedQuitMessege = true;
            return;
        }
        if (shouldRemoveQuitMessege)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, Time.unscaledDeltaTime * lerpSpeed);
        }

    }
}

