using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitReference : MonoBehaviour
{
    private void OnMouseDown()
    {
        LocatorScript.Instance.controller.HideReference();
    }
}
