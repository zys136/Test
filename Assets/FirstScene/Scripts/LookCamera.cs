using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookCamera : MonoBehaviour
{
    public Camera targrt;
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(targrt.transform.forward);
    }
}
