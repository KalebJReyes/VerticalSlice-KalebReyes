using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocatorScript : MonoBehaviour
{
    public static LocatorScript Instance { get; private set; }
    public GameController controller {  get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this) 
        {
            Destroy(this);
            return;
        }

        Instance = this;

        GameObject controllerObj = GameObject.FindWithTag("GameController");
        controller = controllerObj.GetComponent<GameController>();
    }
}
