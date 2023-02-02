using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        StartCoroutine(ScoreUpdate());
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = score.ToString();
    }

    IEnumerator ScoreUpdate()
    {
        var cool_down = new WaitForSeconds(1);
        while (GameManager.game_continue)
        {
            yield return null;
            score += 10;
            yield return cool_down;
        }
    }
}
