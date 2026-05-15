using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button _acceptButton;
    [SerializeField] private Button _denyButton;
    [SerializeField] private GameObject _screenDarken;
    [SerializeField] private Image _darkenImage;
    [SerializeField] private RectTransform _gameoverBox;
    [SerializeField] private float _darkenSpeed;
    [SerializeField] private float _reportSpeed;
    [SerializeField] private TMP_Text _realacceptedtxt;
    [SerializeField] private TMP_Text _realrejectedtxt;
    [SerializeField] private TMP_Text _fakeacceptedtxt;
    [SerializeField] private TMP_Text _fakerejectedtxt;
    [SerializeField] private TMP_Text _reasoningtxt;
    [SerializeField] private TMP_Text _accuracytxt;
    [SerializeField] private TMP_Text _scoretxt;

    // Start is called before the first frame update
    void Start()
    {
        LocatorScript.Instance.controller.GameEnd += DarkenScreen;
        LocatorScript.Instance.controller.GameReset += ResetUI;
    }

    public void EnableButtons() 
    {
        _acceptButton.interactable = true;
        _denyButton.interactable = true;
    }

    public void DisableButtons() 
    {
        _acceptButton.interactable = false;
        _denyButton.interactable = false;
    }

    public void DarkenScreen() 
    {
        _screenDarken.SetActive(true);
        _darkenImage.color = Color.clear;

        StopCoroutine("ResetLerp");
        StartCoroutine("ReportLerp");
        
        EndScreen();
    }

    public void EndScreen() 
    {
        // Report setup
        _realacceptedtxt.text = "Real Horses Accepted: " + LocatorScript.Instance.controller._acceptedReal;
        _realrejectedtxt.text = "Real Horses Rejected: " + LocatorScript.Instance.controller._rejectedReal;
        _fakeacceptedtxt.text = "Fake Horses Accepted: " + LocatorScript.Instance.controller._acceptedFake;
        _fakerejectedtxt.text = "Fake Horses Rejected: " + LocatorScript.Instance.controller._rejectedFake;
        _reasoningtxt.text = "Correct Reasoning: " + LocatorScript.Instance.controller._correctReason;

        // Calculate accuracy percentage
        float total = LocatorScript.Instance.controller._hasGone.Count;
        float correct = LocatorScript.Instance.controller._acceptedReal + LocatorScript.Instance.controller._rejectedFake;
        float accPercent = correct / total;
        accPercent = accPercent * 100;
        Debug.Log(total);
        Debug.Log(correct);
        Debug.Log(accPercent);

        _accuracytxt.text = "Accuracy: " + accPercent + "%";

        int score = (LocatorScript.Instance.controller._acceptedReal * 200) + (LocatorScript.Instance.controller._rejectedFake * 100) + (LocatorScript.Instance.controller._correctReason * 100);
        _scoretxt.text = "Score: " + score;
        
    }

    public void ResetUI() 
    {
        StopCoroutine("ReportLerp");
        StartCoroutine("ResetLerp");
        _screenDarken.SetActive(false);
    }

    IEnumerator ReportLerp() 
    {
        float time = 0;
        while (time < 1)
        {
            _darkenImage.color = Color.Lerp(_darkenImage.color, new Color(0, 0, 0, 0.8f), time);
            _gameoverBox.localPosition = Vector3.Lerp(_gameoverBox.localPosition, Vector3.zero, time);
            time += Time.deltaTime * _darkenSpeed;

            yield return null;
        }
    }

    IEnumerator ResetLerp() 
    {
        float time = 0;
        while (time < 1) 
        {
            _darkenImage.color = Color.Lerp(_darkenImage.color, Color.clear, time);
            _gameoverBox.localPosition = Vector3.Lerp(_gameoverBox.localPosition, new Vector3(0, -630, 0), time);
            time += Time.deltaTime * _reportSpeed;

            yield return null;
        }
    }
}
