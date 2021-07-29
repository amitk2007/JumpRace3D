using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PreCanvasScript : MonoBehaviour
{
    [SerializeField] Canvas cav;
    [SerializeField] public TextMeshProUGUI perText;
    [SerializeField] Slider progressbar;
    [SerializeField] TextMeshProUGUI thisLevelText;
    [SerializeField] TextMeshProUGUI nextLevelText;

    public static int lastStage = 0;

    // Start is called before the first frame update
    void Start()
    {
        perText.enabled = true;
        thisLevelText.text = CreateLevelScript.CurrentLevel.ToString();
        nextLevelText.text = (CreateLevelScript.CurrentLevel + 1).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            perText.enabled = false;
        }
    }

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
