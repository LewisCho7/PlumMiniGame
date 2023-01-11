using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panda_GameManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    // Sprite 정보가 담긴 배열
    [SerializeField] private Sprite[] Imgs = new Sprite[8];
    enum Sprites { O, X, gameover, start, go, round, panda_default, panda_eat }

    // 판다 정보가 담긴 배열
    [SerializeField] private GameObject[] Pandas = new GameObject[3];

    private bool isEnd;

    void Awake() {
        isEnd = false;
    }


    IEnumerator Start() {
        //StartCoroutine(ShowPanel(Imgs[(int)Sprites.round1], 1f, false));
        //StartCoroutine(Eat(8, 0.8f));
        //Eat(8, 0.8f);

        StartCoroutine(ShowPanel(Imgs[(int)Sprites.round], 1f, true));

        while (!isEnd) {
            StartCoroutine(ShowPanel(Imgs[(int)Sprites.start], 0.8f, false));

            StartCoroutine(Eat(8, 0.8f));

            yield return new WaitForSeconds(1f);

            isEnd = true;
        }
    }

    void Update() {

    }

    // panel을 이용한 최상위UI(gameover, start 등) 처리
    IEnumerator ShowPanel(Sprite img, float time, bool afterActive) {

        panel.transform.Find("Image").GetComponent<Image>().sprite = img;

        panel.SetActive(true);
        yield return new WaitForSeconds(time);
        
        panel.SetActive(afterActive);

        // panel.transform.Find("Image").GetComponent<Image>().sprite = Imgs[(int)Sprites.start];
        // yield return new WaitForSeconds(0.5f);

        // panel.SetActive(false);
    }

    // 게임 구현 함수(이 함수가 하나의 라운드)
    IEnumerator Eat(int cnt, float speed) {

        while (cnt > 0) {
            int mode = Choose(new float[] {4, 6});

            if (mode == 0) {
                cnt--;
                int index = Choose(new float[] {33.3f, 33.3f, 33.3f});

                Pandas[index].GetComponent<SpriteRenderer>().sprite = Imgs[(int)Sprites.panda_eat];
                yield return new WaitForSeconds(0.3f);

                Pandas[index].GetComponent<SpriteRenderer>().sprite = Imgs[(int)Sprites.panda_default];
                yield return new WaitForSeconds(speed - 0.3f);
                
            } else {
                cnt -= 2;
                int index = Choose(new float[] {33.3f, 33.3f, 33.3f});
                
                if (index == 2) index = -1;
                int panda1Index = ++index;
                if (index == 2) index = -1;
                int panda2Index = ++index;

                Pandas[panda1Index].GetComponent<SpriteRenderer>().sprite 
                = Pandas[panda2Index].GetComponent<SpriteRenderer>().sprite 
                = Imgs[(int)Sprites.panda_eat];
                yield return new WaitForSeconds(0.3f);

                Pandas[panda1Index].GetComponent<SpriteRenderer>().sprite 
                = Pandas[panda2Index].GetComponent<SpriteRenderer>().sprite 
                = Imgs[(int)Sprites.panda_default];
                yield return new WaitForSeconds(speed - 0.3f);
            }
        }
        
        
    }

    // 랜덤 구현 함수
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
