using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreOtherScenes : MonoBehaviour
{
    public double score, scoreMultiplier, scoreGainRate;
    public float delayAmount;
    public double roundScoreTemp, processedScore;
    protected float timer;
    public double scoreDouble, scoreDoubleTemp1, scoreDoubleTemp2, scoreDecTemp3;
    public GameObject scoreTextObject;

    // Start is called before the first frame update
    void Start()
    {
        SaveAndLoad.IsInGame = true;
        delayAmount = 2f;
        score = ScoreState.Score;
        scoreMultiplier = ScoreState.ScoreMultiplier;
        scoreGainRate = ScoreState.ScoreGainRate;
        scoreTextObject = GameObject.Find("ScorelTMP");
        Debug.Log("Score: " + ScoreState.Score + " ScoreMultipler: " + ScoreState.ScoreMultiplier + " ScoreGainRate: " + ScoreState.ScoreGainRate);
        UpdateScore(score);

    }

    // Update is called once per framess
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= delayAmount)
        {

            timer = 0f;

            roundScoreTemp = score += (scoreGainRate * scoreMultiplier);
            processedScore = Math.Round(roundScoreTemp, 10);//ss
            UpdateScore(processedScore);
            ScoreState.Score = processedScore;
            ScoreState.ScoreGainRate = scoreGainRate;
            ScoreState.ScoreMultiplier = scoreMultiplier;

        }
    }

    public void UpdateScore(double score)
    {
        if (score < 1000)
        {
            scoreDouble = Math.Round(score, 0);
          
            scoreTextObject.GetComponent<TMP_Text>().text = "Score: " + scoreDouble.ToString();
        }
        else if (score > 999 && score < 1000000)
        {
            scoreDouble = score;
            scoreDoubleTemp1 = scoreDouble / 1000;
            scoreDoubleTemp2 = Math.Round(scoreDoubleTemp1, 2);
            
            scoreTextObject.GetComponent<TMP_Text>().text = "Score: " + scoreDoubleTemp2 + "K";
        }
        else if (score > 999999 && score < 1000000000)
        {
            scoreDouble = score;
            scoreDoubleTemp1 = scoreDouble / 1000000;
            scoreDoubleTemp2 = Math.Round(scoreDoubleTemp1, 2);
           
            scoreTextObject.GetComponent<TMP_Text>().text = "Score: " + scoreDoubleTemp2 + "M";
        }
        else if (score > 999999999 && score < 1000000000000)
        {
            scoreDouble = score;
            scoreDoubleTemp1 = scoreDouble / 1000000000;
            scoreDoubleTemp2 = Math.Round(scoreDoubleTemp1, 2);
           
            scoreTextObject.GetComponent<TMP_Text>().text = "Score: " + scoreDoubleTemp2 + "Bn";
        }
        else if (score > 999999999999 && score < 1000000000000000)
        {
            scoreDouble = score;
            scoreDoubleTemp1 = scoreDouble / 1000000000000;
            scoreDoubleTemp2 = Math.Round(scoreDoubleTemp1, 2);
          
            scoreTextObject.GetComponent<TMP_Text>().text = "Score: " + scoreDoubleTemp2 + "Tn";
        }
    }
}
