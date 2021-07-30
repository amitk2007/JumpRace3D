using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;

public class CreateLevelScript : MonoBehaviour
{
    #region variables
    public static int CurrentLevel = 0;

    [SerializeField] GameObject player;
    [SerializeField] GameObject detector;
    [SerializeField] GameObject startStage;
    [SerializeField] GameObject finishStage;
    [SerializeField] PreCanvasScript preCanvasScript;
    [SerializeField] LineRenderer lineRenderer;

    //stages for creation
    [NonSerialized]
    public List<GameObject> stages;
    [SerializeField] GameObject[] stagesPrefs;
    [SerializeField] GameObject waterStage;
    List<GameObject> waterStages;

    [SerializeField] GameObject propelor;

    public static int numberOfStages = 7;
    
    GameObject stage;
    Vector3 newPosition;
    Quaternion newRotation;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        SetUpLevel();
    }

    //set up the stages for the begging of the game
    public void SetUpLevel()
    {
        SetUpStages();
        SetUpLine(stages);
        preCanvasScript.SetUpSlider(0, numberOfStages);
        SetUpWaterStages();
        SetUpPropelors();
    }

    //destory all stages that we dont need to use anymore
    public void DestroyStages()
    {
        ///later we can re-use the last level stages to make it more efficient
        //destroy all the stages exept the first and last stage - we use them as is in the next level
        for (int i = 1; i < stages.Count - 2; i++)
        {
            Destroy(stages[i]);
        }
        //destory all of the water stages
        foreach (GameObject stage in waterStages)
        {
            Destroy(stage);
        }
    }

    //create all stages
    void SetUpStages()
    {
        stages = new List<GameObject>();

        //we get first one from the scene - not creating
        stages.Add(SetUpFirstStage());

        for (int i = 1; i < numberOfStages; i++)
        {
            //get randome prefub rom our stages we have (normal/moving/breaking/...)
            stage = stagesPrefs[Random.Range(0, stagesPrefs.Length)];

            //set the position and rotation for the stage
            newPosition = GetRandomNewPos(stages[i - 1].transform.position, stages[i - 1].transform.forward);
            newPosition = new Vector3(newPosition.x, stages[i - 1].transform.position.y - 10, newPosition.z);
            newRotation = GetRandomNewRotation(stages[i - 1].transform.rotation);
            //add to stages list and add text to stage text
            stages.Add(Instantiate(stage, newPosition, newRotation));
            stages[stages.Count - 1].gameObject.GetComponentInChildren<TMP_Text>().text = (i + 1).ToString();
        }
        //add the finish stage
        stages.Add(SetUpLastStage());
    }

    //set up water stages based on the normal stages
    void SetUpWaterStages()
    {
        Vector3 stagePos;
        waterStages = new List<GameObject>();

        for (int i = 0; i < stages.Count; i++)
        {
            stagePos = stages[i].transform.position;

            for (int j = 0; j < Random.Range(1, 2); j++)
            {
                newPosition = new Vector3(stagePos.x + Random.Range(-20, 20), 0, stagePos.z + Random.Range(-5, 5));
                waterStages.Add(Instantiate(waterStage, newPosition, Quaternion.identity));
            }
        }
    }

    //place the first stage and the first player
    public GameObject SetUpFirstStage()
    {
        //set the stage
        newPosition = new Vector3(0, 10 * numberOfStages, 0);
        startStage.transform.position = newPosition;
        startStage.GetComponentInChildren<TMP_Text>().text = "1";

        //set the player position
        player.transform.position = new Vector3(startStage.transform.position.x, startStage.transform.position.y + 5, startStage.transform.position.z);
        detector.transform.localScale = new Vector3(0.5f, player.transform.position.y + 10, 0.5f);
        detector.transform.localPosition = new Vector3(0, -1 * detector.transform.lossyScale.y, 0);

        return startStage;
    }
    //place the last stage like a normal stage but on the ground
    public GameObject SetUpLastStage()
    {
        //Create finishStage
        newPosition = GetRandomNewPos(stages[stages.Count - 1].transform.position, stages[stages.Count - 1].transform.forward);
        newPosition = new Vector3(newPosition.x, 2.5f, newPosition.z);
        newRotation = stages[stages.Count - 1].transform.rotation;
        finishStage.transform.position = newPosition;
        finishStage.transform.rotation = newRotation;
        return finishStage;
    }

    //put ropelors betwen 2 stages (not includes the first and last stages)
    public void SetUpPropelors()
    {
        //never on first or last
        for (int i = 2; i < stages.Count - 1; i++)
        {
            if (Random.Range(1, 10) == 7)
            {
                Instantiate(propelor, GetMidPosition(stages[i - 1], stages[i]), Quaternion.identity);
            }
        }
    }
    public Vector3 GetMidPosition(GameObject obj1, GameObject obj2)
    {
        //place propelor
        Vector3 position_p = Vector3.zero;
        position_p.x = obj1.transform.position.x + (obj2.transform.position.x - obj1.transform.position.x) / 2;
        position_p.y = obj1.transform.position.y + (obj2.transform.position.y - obj1.transform.position.y) / 2;
        position_p.z = obj1.transform.position.z + (obj2.transform.position.z - obj1.transform.position.z) / 2;

        return position_p;
    }

    //random position the rotation for the stage based on the last one
    private Vector3 GetRandomNewPos(Vector3 position, Vector3 direction)
    {
        Vector3 newPos;
        newPos = position + direction * Random.Range(20, 30);
        return newPos;
    }
    private Quaternion GetRandomNewRotation(Quaternion rotation)
    {
        Quaternion newRot;
        newRot = Quaternion.Euler(0, rotation.y + Random.Range(-33, 33), 0);
        return newRot;
    }

    //create the line besten the stages to show the player how to move
    private void SetUpLine(List<GameObject> stages)
    {
        lineRenderer.positionCount = stages.Count;
        for (int i = 0; i < stages.Count; i++)
        {
            lineRenderer.SetPosition(i, stages[i].transform.position);
        }
    }
}
