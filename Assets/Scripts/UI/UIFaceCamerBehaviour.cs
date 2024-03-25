using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFaceCamerBehaviour : MonoBehaviour
{
    void Update()
    {
        Transform cam = Camera.main.transform;
        transform.LookAt(transform.position + cam.forward);
    }
}
