using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Ski_ScoreText : MonoBehaviour
{
    [SerializeField]
    private GameObject scoreText;

    [SerializeField]
    private GameObject rescueText;

    private TMP_Text score;
    private TMP_Text rescue;

    private void Awake()
    {
        score = scoreText.GetComponent<TMP_Text>();
        rescue = rescueText.GetComponent<TMP_Text>();
    }

    public void changeScoreText()
    {
        score.text = Ski_GameManager.instance.Score.ToString();
    }
    public void changeRescueText()
    {
        rescue.text = "X " + Ski_GameManager.instance.Rescuednum.ToString();
    }

}
