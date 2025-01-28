using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public AudioSource arrowShootingSFX;
    public TextMeshProUGUI remaingArrowTexts;
    public Transform weponHolder;
    private void Start()
    {
        ResetCrossBow();
        GameManager.instance.onGameResets += ResetCrossBow;

    }

    public void ResetCrossBow()
    {

        CancelInvoke(nameof(Shoot));

        i = -1;
        for (int i = 0; i < arrows.Count; i++)
        {
            arrows[i].transform.SetParent(crossBow.transform, true);
            arrows[i].gameObject.SetActive(false);
            arrows[i].position = new Vector3(0, 0.9f, 0.25f);
            arrows[i].useGravity = false;
            arrows[i].velocity = Vector3.zero;
            arrows[i].isKinematic = false;

            arrows[i].angularVelocity = Vector3.zero;

        }
        ShowRemaingArrowsText();
        SpawnArrow();

    }

    private void ShowRemaingArrowsText()
    {
        remaingArrowTexts.text = "Remain Arrows :" + (5 - i - 1).ToString();
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

        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && isCrossBowAttachedToTheHand)
        {
            print("Shoot");
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
        crossBow.transform.SetParent(weponHolder, true);
        crossBow.transform.localPosition = new Vector3(0, 1.4f, 0);
        crossBow.transform.localEulerAngles = Vector3.zero;


    }
    public void SpawnArrow()
    {
        if (i >= 4)
            return;
        i++;
        currentArrow = arrows[i];
        currentArrow.gameObject.SetActive(true);

    }

    [ContextMenu("Shoot")]
    public void Shoot()
    {
        if (!GameManager.instance.isGameStarted)
            return;

        if (currentArrow == null)
            return;

        var forceDirection = currentArrow.transform.up;
        forceDirection.Normalize();

        currentArrow.useGravity = true;
        currentArrow.AddForce(forceDirection * firingStrength, ForceMode.Impulse);

        arrowShootingSFX.Play();
        currentArrow.gameObject.GetComponent<TrailRenderer>().enabled = true;

        currentArrow = null;
        ShowRemaingArrowsText();

        Invoke(nameof(SpawnArrow), 1f);

        if (i >= 4)
        {
            print("GameOver");
            ScoreManager.instance.UpdateFinalReset();
        }
    }

    private void OnDestroy()
    {
        GameManager.instance.onGameResets -= ResetCrossBow;

    }


}
