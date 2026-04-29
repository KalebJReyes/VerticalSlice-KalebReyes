using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class idDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _horseName;
    [SerializeField] private TMP_Text _horseDOB;
    [SerializeField] private TMP_Text _horseCoat;
    [SerializeField] private TMP_Text _horseMane;
    [SerializeField] private TMP_Text _horsePattern;
    [SerializeField] private SpriteRenderer _imageRenderer;
    [SerializeField] private GameController _gameController;
    
    private void Start()
    {
        _horseName.text = "Name: " + LocatorScript.Instance.controller._chosenHorse.idName;
        _horseDOB.text = "Date of Birth: " + LocatorScript.Instance.controller._chosenHorse.idDOB;
        _horseCoat.text = "Coat Color: " + LocatorScript.Instance.controller._chosenHorse.idCoatCol;
        _horseMane.text = "Mane Color: " + LocatorScript.Instance.controller._chosenHorse.idManeCol;
        _horsePattern.text = "Pattern: " + LocatorScript.Instance.controller._chosenHorse.idPattern;
        _imageRenderer.sprite = LocatorScript.Instance.controller._chosenHorse.idPhoto;
    }

    
}
