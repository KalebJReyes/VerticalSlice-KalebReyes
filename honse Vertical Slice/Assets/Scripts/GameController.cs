using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Events
    public delegate void ControllerDelegate();
    public event ControllerDelegate GameEnd;
    public event ControllerDelegate GameReset;

    // Variables
    [SerializeField] private Transform _idSpawn;
    [SerializeField] private GameObject _idSpawnPrefab;
    [SerializeField] private Transform _fcSpawn;
    [SerializeField] private GameObject _fcPrefab;
    [SerializeField] private SpriteRenderer _horseSpawn;
    [SerializeField] private Transform _horseTransform;
    [SerializeField] private horseStats[] _horseStatsList;
    [SerializeField] private GameObject _denyBox;
    [SerializeField] private UIController _uiController;
    

    [SerializeField] private float _lerpSpeed;

    public horseStats _chosenHorse;
    private horseStats _currentHorse;
    public List<horseStats> _hasGone = new List<horseStats>();

    private GameObject _currentID;
    private GameObject _currentFC;

    public int _acceptedReal;
    public int _rejectedReal;
    public int _acceptedFake;
    public int _rejectedFake;
    public int _correctReason;
    
    private List<Toggle> _reasonToggles = new List<Toggle>();
    private List<Toggle> _denyReasons = new List<Toggle>();

    private void Start()
    {
        ChooseHorse();
        SpawnHorse();
    }

    public void SpawnHorse() 
    {
        _horseSpawn.sprite = _chosenHorse.Honse;
    }

    public void SpawnHorseItems() 
    {
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

        EventBus.Trigger(EventNames.AcceptHorse, this);

        Destroy(_currentID);
        Destroy(_currentFC);
    }

    public void Deny() 
    {
        _denyBox.SetActive(true);
        _uiController.DisableButtons();

        foreach (Transform item in _denyBox.transform)
        {
            Toggle itemToggle = item.GetComponent<Toggle>();

            if (itemToggle != null) 
            {
                _reasonToggles.Add(itemToggle);
            }
        }
    }

    public void DenyConfirm() 
    {
        if (!_chosenHorse.Real)
        {
            _rejectedFake++;
        }
        else
        {
            _rejectedReal++;
        }

        foreach (Toggle item in _reasonToggles)
        {
            if (item.isOn) 
            {
                _denyReasons.Add(item);
            }
        }

        foreach (Toggle item in _denyReasons) 
        {
            Transform itemTransform = item.GetComponent<Transform>();
            Transform labelObject = itemTransform.GetChild(1);
            Text labelText = labelObject.GetComponent<Text>();
            string reason = labelText.text;

            if (reason == _currentHorse.fakeReason) 
            {
                _correctReason++;
            }
        }

        _denyReasons.Clear();
        ClearDeny();

        Destroy(_currentID);
        Destroy(_currentFC);

        EventBus.Trigger(EventNames.DenyHorse, this);
    }

    public void ChooseHorse()
    {
        int randoNum = Random.Range(0, _horseStatsList.Length);

        _chosenHorse = _horseStatsList[randoNum];

        if (AvailabilityCheck()) 
        {
            Debug.Log("GAME OVER");
            return;
        }

        if (_currentHorse != null)
        {
            while (_hasGone.Contains(_chosenHorse))
            {
                randoNum = Random.Range(0, _horseStatsList.Length);
                _chosenHorse = _horseStatsList[randoNum];
            }
        }

        _currentHorse = _chosenHorse;
        _hasGone.Add(_currentHorse);
    }

    public void ClearDeny() 
    {
        for (int i = 0; i < _reasonToggles.Count; i++)
            {
                _reasonToggles[i].isOn = false;
            }

        _reasonToggles.Clear();
        _uiController.EnableButtons();

        _denyBox.SetActive(false);
    }

    public bool AvailabilityCheck() 
    {
        foreach (horseStats horse in _horseStatsList) 
        {
            if (!_hasGone.Contains(horse))
            {
                return false;
            }
        }
        return true;
    }

    public void handleLerp() 
    {
        _horseTransform.rotation = Quaternion.Lerp(_horseTransform.rotation, Quaternion.Euler(0,0,0), Time.deltaTime * _lerpSpeed);
    }

    public void endGame() 
    {
        GameEnd?.Invoke();
    }

    public void ResetGame() 
    {
        _hasGone.Clear();
        _acceptedReal = 0;
        _acceptedFake = 0;
        _rejectedFake = 0;
        _rejectedReal = 0;
        _correctReason = 0;

        ChooseHorse();
        SpawnHorse();
        GameReset?.Invoke();
        EventBus.Trigger(EventNames.ResetGame, this);
    }
}
