using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMeScreen : MonoBehaviour
{

    public Camera camera;
    public GameObject forwardObj;// object should be placed as the child of the camera to follow
    public float dist;
    public float speed;
    public Transform screen;
    void Update()
    {
        Vector3 temp = forwardObj.transform.position;
        temp.y = camera.transform.position.y;
        forwardObj.transform.position = temp;
        temp = forwardObj.transform.localPosition;

        forwardObj.transform.localPosition = new Vector3(0, temp.y, dist);

        screen.transform.position = Vector3.Lerp(screen.transform.position, forwardObj.transform.position, speed);
    }
}