using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PreCanvasScript : MonoBehaviour
{
    #region
    [SerializeField] Canvas cav;
    [SerializeField] public TextMeshProUGUI perText;
    [SerializeField] Slider progressbar;
    [SerializeField] TextMeshProUGUI thisLevelText;
    [SerializeField] TextMeshProUGUI nextLevelText;

    public static int lastStage = 0;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //setThe Turotial text
        perText.enabled = true;
        //set the progess bar text
        thisLevelText.text = CreateLevelScript.CurrentLevel.ToString();
        nextLevelText.text = (CreateLevelScript.CurrentLevel + 1).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //of clicked hide the tutorial text
        if (Input.touchCount > 0)
        {
            perText.enabled = false;
        }
    }

    //progress bar scripting
    public void SetUpSlider(int min, int max)
    {
        progressbar.minValue = min;
        progressbar.maxValue = max;
    }
    public void UpdateLevelProgressBar()
    {
        progressbar.value = lastStage;
    }
}
