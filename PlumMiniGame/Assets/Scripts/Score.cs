using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int score;

    public static Queue<GameObject> queue = new Queue<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        StartCoroutine(ScoreUpdateByTime());
        queue.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        if (queue.Count >= 5)
        {
            queue.Clear();
            score += 15;
        }
        GetComponent<TextMeshProUGUI>().text = score.ToString();
    }

    IEnumerator ScoreUpdateByTime()
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
