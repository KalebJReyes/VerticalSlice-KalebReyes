using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Transform _idSpawn;
    [SerializeField] private GameObject _idSpawnPrefab;

    public List<GameObject> IDs = new List<GameObject>();

    private int _currentID = 0;
    public void SpawnID() 
    {
        GameObject ID = Instantiate(_idSpawnPrefab, _idSpawn.position, Quaternion.identity);
        IDs.Add(ID);

        if (IDs.Count > 2) 
        {
            Destroy(IDs[_currentID]);
            _currentID++;
        }
    }
}
