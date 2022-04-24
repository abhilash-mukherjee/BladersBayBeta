using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTrainingManager : MonoBehaviour
{
    [SerializeField]
    private int maximumStepIndex;
    [SerializeField]
    private GameObject markerPrefab, winPanel;
    [SerializeField]
    private List<Vector3> positions = new List<Vector3>();
    [SerializeField]
    private Collider playerCollider;
    [SerializeField]
    private string prefix;
    [SerializeField]
    private Animator animator;
    private int m_index = 0;

    public void PlayAudio(string _audioclip){
        GameAudioManager.Instance.PlaySoundOneShot(_audioclip);
    }
    private void OnEnable()
    {
        MovementMarkerManager.OnTargetReached += MarkerReached;
    }
    private void OnDisable()
    {
        MovementMarkerManager.OnTargetReached -= MarkerReached;
        
    }
    public void SpawnPrefab(int _index)
    {
        var _gO = Instantiate(markerPrefab, positions[_index], Quaternion.identity);
        _gO.GetComponent<MovementMarkerManager>().SetCollider(playerCollider);
    }

    private void MarkerReached()
    {
        m_index++;
        if(m_index > maximumStepIndex) {
            winPanel.SetActive(true);
            gameObject.SetActive(false);
        }
        animator.SetBool(prefix + m_index, true);
    }

}
