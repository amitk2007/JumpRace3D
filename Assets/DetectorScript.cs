using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorScript : MonoBehaviour
{
    [SerializeField] Color aboveStage;
    [SerializeField] Color aboveWater;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Renderer>().material.SetColor("_Color", aboveStage);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Stage") || other.transform.CompareTag("Finish"))
        {
            this.GetComponent<Renderer>().material.SetColor("_Color", aboveStage);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Stage") || other.transform.CompareTag("Finish"))
        {
            this.GetComponent<Renderer>().material.SetColor("_Color", aboveWater);
        }
    }
}
