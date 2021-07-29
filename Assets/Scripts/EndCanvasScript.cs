using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndCanvasScript : MonoBehaviour
{
    bool canPlayAgain = false;
    bool didWin = false;
    [SerializeField] CreateLevelScript createLevelScript;
    [SerializeField] Canvas startLevelCanv;

    [SerializeField] TextMeshProUGUI levelFinised;
    [SerializeField] TextMeshProUGUI first;

    public void RestartButtonClicked()
    {
        this.GetComponent<Canvas>().enabled = false;
        if (didWin)
        {
            StartNextLevel();
        }
        else
        {
            RestartLevel();
        }
    }

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
        //Start the coroutine we define below named ExampleCoroutine.
        StartCoroutine(WaitForXSec());
    }

    IEnumerator WaitForXSec()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2);
        canPlayAgain = true;
    }

    public void StartNextLevel()
    {
        //change level number
        CreateLevelScript.CurrentLevel++;
        //change level stages number
        CreateLevelScript.numberOfStages++;
        //ReCreate Level
        createLevelScript.DestroyStages();
        createLevelScript.StartGame();
        PreCanvasScript.lastStage = 0;

        startLevelCanv.enabled = true;
        startLevelCanv.GetComponent<PreCanvasScript>().perText.enabled = true;

        canPlayAgain = false;
    }

    public void RestartLevel()
    {
        createLevelScript.DestroyStages();
        createLevelScript.StartGame();

        startLevelCanv.enabled = true;
        startLevelCanv.GetComponent<PreCanvasScript>().perText.enabled = true;

        PreCanvasScript.lastStage = 0;
    }
}
