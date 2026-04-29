using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Transform _idSpawn;
    [SerializeField] private GameObject _idSpawnPrefab;
    [SerializeField] private Transform _fcSpawn;
    [SerializeField] private GameObject _fcPrefab;
    [SerializeField] private SpriteRenderer _horseSpawn;
    [SerializeField] private horseStats[] _horseStatsList;

    public horseStats _chosenHorse;
    private horseStats _currentHorse;

    private GameObject _currentID;
    private GameObject _currentFC;

    private int _acceptedReal;
    private int _rejectedReal;
    private int _acceptedFake;
    private int _rejectedFake;

    private void Start()
    {
        ChooseHorse();
        SpawnHorse();
    }

    public void SpawnHorse() 
    {
        _horseSpawn.sprite = _chosenHorse.Honse;
        _currentID = Instantiate(_idSpawnPrefab, _idSpawn.position, Quaternion.identity);
        _currentFC = Instantiate(_fcPrefab, _fcSpawn.position, Quaternion.identity);
    }

    public void Accept() 
    {
        if (_chosenHorse.Real)
        {
            _acceptedReal++;
        }
        else 
        {
            _acceptedFake++;
        }

        Destroy(_currentID);
        Destroy(_currentFC);

        ChooseHorse();
        SpawnHorse();
    }

    public void Deny() 
    {
        if (!_chosenHorse.Real)
        {
            _rejectedFake++;
        }
        else
        {
            _rejectedReal++;
        }

        Destroy(_currentID);
        Destroy(_currentFC);

        ChooseHorse();
        SpawnHorse();
    }

    private void ChooseHorse()
    {
        int randoNum = Random.Range(0, _horseStatsList.Length);

        _chosenHorse = _horseStatsList[randoNum];
        if (_currentHorse != null)
        {
            while (_chosenHorse == _currentHorse)
            {
                randoNum = Random.Range(0, _horseStatsList.Length);
                _chosenHorse = _horseStatsList[randoNum];
            }
        }

        _currentHorse = _chosenHorse;
    }
}
