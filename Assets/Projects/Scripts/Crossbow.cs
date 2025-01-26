using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbow : MonoBehaviour
{
    public GameObject crossBow;
    public Transform rightControllerTransform;
    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            crossBow.transform.SetParent(rightControllerTransform,true);
            crossBow.transform.localPosition = Vector3.zero;
            crossBow.transform.localEulerAngles = Vector3.zero;
            crossBow.SetActive(!crossBow.activeInHierarchy);
        }
    }


}
