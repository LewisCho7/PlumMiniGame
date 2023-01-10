using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panda_GameManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    [SerializeField] private Sprite Img_O;
    [SerializeField] private Sprite Img_X;
    [SerializeField] private Sprite Img_gameover;
    [SerializeField] private Sprite Img_start;
    [SerializeField] private Sprite Img_go;
    [SerializeField] private Sprite Img_round1;
    [SerializeField] private Sprite Img_round2;
    [SerializeField] private Sprite Img_panda_default;
    [SerializeField] private Sprite Img_panda_eat;

    [SerializeField] private GameObject panda1;
    [SerializeField] private GameObject panda2;
    [SerializeField] private GameObject panda3;


    void Start() {
        StartCoroutine(ShowPanel(Img_round1));
    }

    void Update() {

    }

    IEnumerator ShowPanel(Sprite round_img) {

        panel.transform.Find("Image").GetComponent<Image>().sprite = round_img;

        panel.SetActive(true);
        yield return new WaitForSeconds(1f);

        panel.transform.Find("Image").GetComponent<Image>().sprite = Img_start;
        yield return new WaitForSeconds(0.5f);

        panel.SetActive(false);
    }

    // IEnumerator Eat(int cnt, float speed) {

    // }

    float Choose (float[] probs) {

        float total = 0;

        foreach (float elem in probs) {
            total += elem;
        }

        float randomPoint = Random.value * total;

        for (int i= 0; i < probs.Length; i++) {
            if (randomPoint < probs[i]) {
                return i;
            }
            else {
                randomPoint -= probs[i];
            }
        }
        return probs.Length - 1;
    }
}
