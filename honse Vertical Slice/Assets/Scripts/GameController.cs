using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Transform _idSpawn;
    [SerializeField] private GameObject _idSpawnPrefab;
    [SerializeField] private Transform _fcSpawn;
    [SerializeField] private GameObject _fcPrefab;
    [SerializeField] private SpriteRenderer _horseSpawn;
    [SerializeField] private horseStats[] _horseStatsList;
    [SerializeField] private GameObject _denyBox;
    //[SerializeField] private Toggle[] _reasonToggles;
    [SerializeField] private TMP_Text _acceptedRealtxt;
    [SerializeField] private TMP_Text _acceptedFaketxt;
    [SerializeField] private TMP_Text _rejectedRealtxt;
    [SerializeField] private TMP_Text _rejectedFaketxt;

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
            _acceptedRealtxt.text = "Real Accepted: " + _acceptedReal;
        }
        else 
        {
            _acceptedFake++;
            _acceptedFaketxt.text = "Fake Accepted: " + _acceptedFake;
        }

        Destroy(_currentID);
        Destroy(_currentFC);

        ChooseHorse();
        SpawnHorse();
    }

    public void Deny() 
    {
        _denyBox.SetActive(true);
    }

    public void DenyConfirm() 
    {
        if (!_chosenHorse.Real)
        {
            _rejectedFake++;
            _rejectedFaketxt.text = "Fake Rejected: " + _rejectedFake;
        }
        else
        {
            _rejectedReal++;
            _rejectedRealtxt.text = "Real Rejected: " + _rejectedReal;
        }
/*
        for (int i = 0; i < _reasonToggles.Length; i++)
        {
            _reasonToggles[i].isOn = false;
        }
*/
        _denyBox.SetActive(false);

        Destroy(_currentID);
        Destroy(_currentFC);

        ChooseHorse();
        SpawnHorse();
    }

    public void CancelDeny() 
    {
        /*
        for (int i = 0; i < _reasonToggles.Length; i++)
        {
            _reasonToggles[i].isOn = false;
        }
        */
        _denyBox.SetActive(false);
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
