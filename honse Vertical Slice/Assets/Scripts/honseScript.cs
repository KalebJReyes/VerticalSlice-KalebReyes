using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class honseScript : MonoBehaviour
{
    [SerializeField] float _rotateSpeed;

    private void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, _rotateSpeed * Time.deltaTime);
    }
}
