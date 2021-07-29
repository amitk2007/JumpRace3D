using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 30f;
    [SerializeField] float rotationSpeed;
    [SerializeField] PreCanvasScript preCanvasScript;
    [SerializeField] Canvas endGameCanv;

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }


    private void MovePlayer()
    {
        if (Input.touchCount > 0)
        {
            transform.position += this.transform.forward * Time.deltaTime * movementSpeed;
            //transform.Translate(0, 0, Time.deltaTime * movementSpeed);
            //transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Stage"))
        {
            PreCanvasScript.lastStage = int.Parse(collision.gameObject.GetComponentInChildren<TMP_Text>().text);
            preCanvasScript.UpdateLevelProgressBar();
        }
        else if (collision.transform.CompareTag("Respawn"))
        {
            //wait then restart level
            endGameCanv.enabled = true;
            endGameCanv.gameObject.GetComponent<Canvas>().enabled = true;
            endGameCanv.GetComponent<EndCanvasScript>().StartEndCanv(false);
        }
        else if (collision.transform.CompareTag("Finish"))
        {
            endGameCanv.enabled = true;
            endGameCanv.gameObject.GetComponent<Canvas>().enabled = true;
            endGameCanv.GetComponent<EndCanvasScript>().StartEndCanv(true);
        }
    }
}
