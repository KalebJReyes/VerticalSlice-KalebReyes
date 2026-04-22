using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class idDisplay : MonoBehaviour
{
    [SerializeField] private horseStats[] _horseStatsList;
    [SerializeField] private TMP_Text _horseName;
    [SerializeField] private TMP_Text _horseDOB;
    [SerializeField] private TMP_Text _horseCoat;
    [SerializeField] private TMP_Text _horseMane;
    [SerializeField] private TMP_Text _horsePattern;
    [SerializeField] private SpriteRenderer _imageRenderer;

    private horseStats _chosenHorse;


    private void Start()
    {
        ChooseHorse();

        _horseName.text = "Name: " + _chosenHorse.idName;
        _horseDOB.text = "Date of Birth: " + _chosenHorse.idDOB;
        _horseCoat.text = "Coat Color: " + _chosenHorse.idCoatCol;
        _horseMane.text = "Mane Color: " + _chosenHorse.idManeCol;
        _horsePattern.text = "Pattern: " + _chosenHorse.idPattern;
        _imageRenderer.sprite = _chosenHorse.idPhoto;
    }

    private void ChooseHorse() 
    {
        int randoNum = Random.Range(0, _horseStatsList.Length);

        _chosenHorse = _horseStatsList[randoNum];
    }
}
