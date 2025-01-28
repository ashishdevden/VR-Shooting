using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Target : MonoBehaviour
{
    public Collider targetCollider;
    public Transform arrowHolder;
    public ParticleSystem particle;
    ScoreManager scoreManager;
    void Start()
    {

        scoreManager = ScoreManager.instance;

        if (targetCollider == null)
        {
            //EditorGUIUtility.PingObject(this.gameObject);

            print("Target Collider is null");
        }

        GameManager.instance.onGameResets += () =>
        {

            if (targetCollider == null)
            {
                //EditorGUIUtility.PingObject(this.gameObject);
            }

            targetCollider.enabled = true;
        };
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Arrow")
        {
            float dist = Vector3.Distance(collision.contacts[0].point, transform.position);
            int val = scoreManager.CalculateScore(dist);
            ShowParticleOnBullsEye(val);
            scoreManager.AddScore(val);
            collision.rigidbody.useGravity = false;
            collision.rigidbody.velocity = Vector3.zero;
            collision.rigidbody.angularVelocity = Vector3.zero;
            collision.rigidbody.freezeRotation = true;
            collision.rigidbody.isKinematic = true;
            collision.gameObject.GetComponent<TrailRenderer>().enabled = false;

            targetCollider.enabled = false;
            collision.transform.SetParent(arrowHolder, true);
        }
    }

    public void ShowParticleOnBullsEye(int val)
    {
        if (val == 5)
            particle.Play();
    }
}
