using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class fcDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _Name;
    [SerializeField] private TMP_Text _DOB;
    [SerializeField] private TMP_Text _IDNum;
    [SerializeField] private TMP_Text _fundsAmt;
    [SerializeField] private SpriteRenderer _Signature;
    [SerializeField] private SpriteRenderer _Photo;


    void Start()
    {
        _Name.text = "Name: " + LocatorScript.Instance.controller._chosenHorse.fcName;
        _DOB.text = "Date of Birth: " + LocatorScript.Instance.controller._chosenHorse.fcDob;
        _IDNum.text = "ID #: " + LocatorScript.Instance.controller._chosenHorse.fcIdnum;
        _fundsAmt.text = "$ " + LocatorScript.Instance.controller._chosenHorse.Funds;
        _Signature.sprite = LocatorScript.Instance.controller._chosenHorse.stableSignature;
        _Photo.sprite = LocatorScript.Instance.controller._chosenHorse.fcPhoto;
    }
}
