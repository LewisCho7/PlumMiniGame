using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextUI : MonoBehaviour
{
    public static int score;

    public static Queue<GameObject> queue = new Queue<GameObject>();

    [SerializeField]
    private GameObject score_ui;
    [SerializeField]
    private GameObject rescue_ui;

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

        score_ui.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text 
            = score.ToString();

        rescue_ui.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text
            = JumpGameManager.rescued_character.ToString();
    }

    IEnumerator ScoreUpdateByTime()
    {
        var cool_down = new WaitForSeconds(1);
        while (JumpGameManager.game_continue)
        {
            yield return null;
            yield return cool_down;
            score += 10;
        }
    }
}
