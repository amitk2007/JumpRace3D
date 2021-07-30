using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndCanvasScript : MonoBehaviour
{
    #region variable
    bool canPlayAgain = false;
    bool didWin = false;
    [SerializeField] CreateLevelScript createLevelScript;
    [SerializeField] Canvas startLevelCanv;
    [SerializeField] PlayerAnimController animController;
    [SerializeField] TextMeshProUGUI levelFinised;
    [SerializeField] TextMeshProUGUI first;
    #endregion

    //restart the level or starting next level on click on screan
    public void RestartButtonClicked()
    {
        this.GetComponent<Canvas>().enabled = false;
        animController.SetFisrtAnim();
        if (didWin)
        {
            StartNextLevel();
        }
        else
        {
            RestartLevel();
        }
    }

    //place the text according to isWinner variable
    public void StartEndCanv(bool isWinner)
    {
        didWin = isWinner;
        if (isWinner)
        {
            levelFinised.text = "Level Completed";
            first.text = "You";
        }
        else
        {
            levelFinised.text = "Level Failed";
            first.text = "Not You";
        }
        canPlayAgain = true;
    }

    //destroy everything and create new level with more stages
    public void StartNextLevel()
    {
        //change level number
        CreateLevelScript.CurrentLevel++;
        //change level stages number
        CreateLevelScript.numberOfStages++;
        //ReCreate Level
        createLevelScript.DestroyStages();
        createLevelScript.SetUpLevel();
        PreCanvasScript.lastStage = 0;

        startLevelCanv.enabled = true;
        startLevelCanv.GetComponent<PreCanvasScript>().perText.enabled = true;

        canPlayAgain = false;
    }

    //destroy the level and create a new one
    ///next vertion - just reCreat the breaking stages and place player at first pos 
    public void RestartLevel()
    {
        createLevelScript.DestroyStages();
        createLevelScript.SetUpLevel();

        startLevelCanv.enabled = true;
        startLevelCanv.GetComponent<PreCanvasScript>().perText.enabled = true;

        PreCanvasScript.lastStage = 0;
    }
}
