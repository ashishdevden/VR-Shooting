using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Target : MonoBehaviour
{
    public Collider targetCollider;

    ScoreManager scoreManager;
    void Start()
    {
        scoreManager = ScoreManager.instance;
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Arrow")
        {
            float dist = Vector3.Distance(collision.contacts[0].point, transform.position);
            int val = scoreManager.CalculateScore(dist);
            scoreManager.AddScore(val);
            collision.gameObject.GetComponent<Rigidbody>().useGravity = false;
            collision.transform.SetParent(transform, true);
        }
    }
}
