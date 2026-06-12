using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UniDialogue", menuName = "ScriptableObjects/UniDialogue", order = 2)]

public class UniversalDialogue : ScriptableObject
{
    public string[] enteringDialogue;
    public string[] acceptDialogue;
    public string[] rejectDialogue;
}
