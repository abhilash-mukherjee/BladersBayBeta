using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementMarkerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject markerPrefab;
    [SerializeField] private Collider playerCollider;
    GameObject spawnedObject;
    public  void SpawnPrefabAtPassedTransform(GameObject _gameObject)
    {
        spawnedObject = Instantiate(markerPrefab, _gameObject.transform);
        spawnedObject.GetComponent<MovementMarkerManager>().SetCollider(playerCollider);
    }

    public void DestroyPreviousObject()
    {
        Destroy(spawnedObject);
    }
}
