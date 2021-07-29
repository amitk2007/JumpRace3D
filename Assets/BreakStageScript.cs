using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakStageScript : MonoBehaviour
{
    [SerializeField] List<GameObject> stageParts;

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Rigidbody rigidbody;
            foreach (GameObject part in stageParts)
            {
                if (part.GetComponent<Rigidbody>() == null)
                {
                    part.AddComponent<Rigidbody>();
                }
                rigidbody = part.GetComponent<Rigidbody>();
                rigidbody.AddExplosionForce(50f, other.transform.position, 6f);

            }
            GameObject.Destroy(this, 5f);
        }
    }
}
