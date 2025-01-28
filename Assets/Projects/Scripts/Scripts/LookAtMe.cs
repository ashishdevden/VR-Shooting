using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMe : MonoBehaviour
{

    public bool useMainCam;
    public Transform target;
    public Vector3 offset;

    private void Start()
    {
        if (useMainCam)
            target = Camera.main.transform;
    }

    void Update()
    {
        transform.LookAt(target);
        transform.Rotate(offset);
    }
}
