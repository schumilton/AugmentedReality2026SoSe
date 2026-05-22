using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // Für den Linksklick
using UnityEngine.XR.ARFoundation; // Für AR-Funktionen
using UnityEngine.XR.ARSubsystems;

public class Billboarding : MonoBehaviour
{

    void Awake()
    {
    }

    void Update()
    {
          transform.LookAt(Camera.main.transform.position, -Vector3.up);

    }
}