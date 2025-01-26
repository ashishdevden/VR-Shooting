using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Target : MonoBehaviour
{
    public Collider targetCollider;


    void Start()
    {

    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Arrow")
        {
            float dist = Vector3.Distance(collision.contacts[0].point, transform.position);
            print(dist);
            CalculateScore(dist);
            collision.gameObject.GetComponent<Rigidbody>().useGravity = false;
            collision.transform.SetParent(transform, true);


        }
    }

    public int CalculateScore(float dist)
    {
        if (dist >= 0.325f)
        {
            return 1;
        }
        else if (dist >= 0.15f)
        {
            return 3;
        }
        else
        {
            return 5;
        }
    }

    void Update()
    {

    }
}
