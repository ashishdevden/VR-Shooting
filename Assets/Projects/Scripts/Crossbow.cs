using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbow : MonoBehaviour
{
    public GameObject crossBow;
    public Transform rightControllerTransform;
    bool isCrossBowAttachedToTheHand;
    public List<Rigidbody> arrows;
    Rigidbody currentArrow;
    int i = 0;
    public float firingStrength;
    private void Start()
    {
        ResetCrossBow();

    }

    public void ResetCrossBow()
    {
        i = -1;
        for (int i = 0; i < arrows.Count; i++)
        {
            arrows[i].gameObject.SetActive(false);
            arrows[i].position = new Vector3(0, 0.9f, 0.25f);
            arrows[i].useGravity = false;
            arrows[i].velocity = Vector3.zero;
            arrows[i].angularVelocity = Vector3.zero;

        }
        SpawnArrow();
    }
    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            if (isCrossBowAttachedToTheHand)
            {
                UngrabCrossBow();
            }
            else
            {
                GrabCrossBow();
            }
            isCrossBowAttachedToTheHand = !isCrossBowAttachedToTheHand;
        }

        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger)) 
        {
            Shoot();
        }
    }

    public void GrabCrossBow()
    {
        crossBow.transform.SetParent(rightControllerTransform, true);
        crossBow.transform.localPosition = Vector3.zero;
        crossBow.transform.localEulerAngles = Vector3.zero;
    }

    public void UngrabCrossBow()
    {


    }
    public void SpawnArrow()
    {
        i++;
        currentArrow = arrows[i];
        currentArrow.gameObject.SetActive(true);
    }

    [ContextMenu("Shoot")]
    public void Shoot()
    {
        if (currentArrow == null)
            return;

        var forceDirection = currentArrow.transform.up;
        forceDirection.Normalize();
        forceDirection*=firingStrength;
        currentArrow.AddForce(forceDirection, ForceMode.Impulse);
    }



}
