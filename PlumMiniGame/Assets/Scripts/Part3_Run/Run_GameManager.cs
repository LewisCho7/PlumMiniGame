using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Run_GameManager : MonoBehaviour
{

    public GameObject player;
    public GameObject panel;
    public GameObject shooter;
    public Sprite GoSprite, GameOverSprite;

    static public float time = 0f;

    IEnumerator Start() {
        panel.SetActive(true);

        yield return new WaitForSeconds(1f);
        panel.transform.Find("Image").gameObject.GetComponent<Image>().sprite = GoSprite;

        yield return new WaitForSeconds(0.7f);
        panel.SetActive(false);
        player.SetActive(true);
        Run_Player.isAlive = true;
        StartCoroutine(shooter.GetComponent<Run_Shooter>().shootStart());
    }

    void Update() {
        if (Run_Player.isAlive) {
            time += Time.deltaTime;
        } else if (time > 0) {
            panel.transform.Find("Image").gameObject.GetComponent<Image>().sprite = GameOverSprite;
            panel.GetComponent<Image>().color = new Color(0, 0, 0, 0.4f);
            panel.SetActive(true);
            time = 0;
        }
    }
}
