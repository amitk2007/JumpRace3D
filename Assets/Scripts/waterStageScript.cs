using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterStageScript : MonoBehaviour
{
    public float waterstageForce = 500f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * waterstageForce);
        }
    }
}
