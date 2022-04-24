using UnityEngine;

public class TeachMovement : CustomCommand, ICommand
{
    public delegate void MarkerDestroyHandler();
    public static event MarkerDestroyHandler OnMarkerDestroyed;
    [SerializeField]
    private float markerShowTime = 0.5f;
    [SerializeField]
    GameObject targetPositionPrefab;
    [SerializeField]
    private Vector3 targetPosition;
    private GameObject currentMarker;
    private void Awake()
    {
        AddThisInstanceToCustomCommandList();
    }
    private void OnDisable()
    {
        RemoveThisInstanceFromCustomCommandList();
    }
    private void Start()
    {
        command = this;
    }
    public void Execute()
    {
        Debug.Log("Inside excute of teach movement");
        foreach(var _Command in priorCommandsToExecute)
        {
            if (_Command.HasExecuted == false)
            {
                Debug.LogError("All the Prior commands did not execute");
                return;
            }
        }
        Debug.Log($"{gameObject.name} Executed");
        Debug.Log($"Is object moving? {GameObject.FindObjectOfType<TutorialInputController>().IsMoving}");
        hasExecuted = true;
        OnStepExecuted?.Invoke();
    }

    public void UnExecute()
    {
        hasExecuted = false;
        Debug.Log($"Unexecuted TeachMovement"); 
        if(currentMarker != null)
        {
            Destroy(currentMarker);
        }
        Debug.Log($"{gameObject.name} UnExecuted");
        Debug.Log($"Is object moving? {GameObject.FindObjectOfType<TutorialInputController>().IsMoving}");
        OnStepUnExecuted?.Invoke();
    }

    public void ShowMarker()
    {
        StartCoroutine(InstantiateMarker(markerShowTime));
    }
    public void DestroyPreExistingMarker()
    {
        OnMarkerDestroyed?.Invoke();
    }
    System.Collections.IEnumerator InstantiateMarker(float _markerShowTime)
    {
        yield return new WaitForSeconds(_markerShowTime);
        currentMarker = Instantiate(targetPositionPrefab, targetPosition, Quaternion.identity);
    }
}
