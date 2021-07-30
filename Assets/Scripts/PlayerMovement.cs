using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region variables
    [SerializeField] float movementSpeed = 30f;
    [SerializeField] float rotationSpeed;
    [SerializeField] PreCanvasScript preCanvasScript;
    [SerializeField] Canvas endGameCanv;
    [SerializeField] PlayerAnimController animController;
    #endregion

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    // move the player then touch hit the sceen
    private void MovePlayer()
    {
        if (Input.touchCount > 0)
        {
            transform.position += this.transform.forward * Time.deltaTime * movementSpeed;
            //Other Ways the for now are less effective
            //transform.Translate(0, 0, Time.deltaTime * movementSpeed);
            //transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        //change the progress bar
        if (collision.transform.CompareTag("Stage"))
        {
            PreCanvasScript.lastStage = int.Parse(collision.gameObject.GetComponentInChildren<TMP_Text>().text);
            preCanvasScript.UpdateLevelProgressBar();
        }
        //die
        else if (collision.transform.CompareTag("Respawn"))
        {
            endGameCanv.enabled = true;
            endGameCanv.gameObject.GetComponent<Canvas>().enabled = true;
            endGameCanv.GetComponent<EndCanvasScript>().StartEndCanv(false);
        }
        //win the level
        else if (collision.transform.CompareTag("Finish"))
        {
            animController.PlayWinAnimation();
            endGameCanv.enabled = true;
            endGameCanv.gameObject.GetComponent<Canvas>().enabled = true;
            endGameCanv.GetComponent<EndCanvasScript>().StartEndCanv(true);
        }
    }
}
