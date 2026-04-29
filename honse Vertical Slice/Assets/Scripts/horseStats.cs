using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HorseStats", menuName = "ScriptableObjects/HorseStats", order = 1)]
public class horseStats : ScriptableObject
{
    public bool Real;

    // ID Values
    public string idName;
    public Sprite idPhoto;
    public string idDOB;
    public string idCoatCol;
    public string idManeCol;
    public string idPattern;

    // Food Card Values
    public string fcName;
    public string fcDob;
    public Sprite fcPhoto;
    public Sprite stableSignature;
    public string fcIdnum;
    public float Funds;
    public bool giveFunds;

    // Real Horse Values
    public Sprite Honse;
    public string honseCoatCol;
    public string honseManeCol;
    public string honsePattern;
}
