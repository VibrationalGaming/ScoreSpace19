using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scorer : MonoBehaviour
{

    public TextMeshProUGUI scoreTxt;
    public float scoreAmt;
    public float pointsChanged;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("FinalScore") == 0)
            scoreAmt = 10000f;
        else
            scoreAmt = PlayerPrefs.GetInt("FinalScore");

        pointsChanged = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreAmt > 0)
        {
            PlayerPrefs.SetInt("FinalScore", (int) scoreAmt);

            scoreTxt.text = "Score: " + (int) scoreAmt;
            scoreAmt -= (pointsChanged * Time.deltaTime) * 5;
        }
    }
}
