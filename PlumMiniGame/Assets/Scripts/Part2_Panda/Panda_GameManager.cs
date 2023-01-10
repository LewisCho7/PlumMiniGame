using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panda_GameManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    [SerializeField] private Sprite[] Imgs = new Sprite[9];
    enum Sprites {
        O, X, gameover, start, go, round1, round2, panda_default, panda_eat

    }

    [SerializeField] private GameObject[] pandas;


    void Start() {
        StartCoroutine(ShowPanel(Imgs[(int)Sprites.round1]));
    }

    void Update() {

    }

    IEnumerator ShowPanel(Sprite round_img) {

        panel.transform.Find("Image").GetComponent<Image>().sprite = round_img;

        panel.SetActive(true);
        yield return new WaitForSeconds(1f);

        panel.transform.Find("Image").GetComponent<Image>().sprite = Imgs[(int)Sprites.start];
        yield return new WaitForSeconds(0.5f);

        panel.SetActive(false);
    }

    // IEnumerator Eat(int cnt, float speed) {
    //     int mode = Choose(new float[] {4, 6});

    //     if (mode == 0) {
    //         int index = Choose(new float[] {33.3f, 33.3f, 33.3f});

    //         pandas[index].GetComponent<SpriteRenderer>().sprite = Imgs[(int)Sprites.panda_eat];
    //     }
    // }

    int Choose (float[] probs) {

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
