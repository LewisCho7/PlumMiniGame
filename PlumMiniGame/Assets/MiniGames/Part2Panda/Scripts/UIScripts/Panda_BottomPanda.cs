using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panda_BottomPanda : MonoBehaviour
{
    private GameObject[] bottomPanda = new GameObject[3];
    public static Vector2[] bottomPandaPosition = new Vector2[3];
    public static bool isCatched = false;

    void Awake() {
        bottomPanda[0] = transform.Find("LeftPanda").gameObject;
        bottomPanda[1] = transform.Find("CenterPanda").gameObject;
        bottomPanda[2] = transform.Find("RightPanda").gameObject;

        for (int i = 0; i < 3; i++) {
            bottomPandaPosition[i] = bottomPanda[i].GetComponent<RectTransform>().anchoredPosition;
        }
    }

    void Update()
    {
        if (Panda_GameManager.isEatingRoundStart) {
            isCatched = false;
            StartCoroutine(ShowPanda(bottomPanda[Choose(new float[] {33.3f, 33.3f, 33.3f})]));
        }
    }

    private IEnumerator ShowPanda(GameObject panda) {

        // start 1초 후에 판다가 먹는 것을 시작하기 때문에
        // 1.5초를 맞추기 위해서 0.5초의 딜레이를 줌
        yield return new WaitForSeconds(0.5f);

        while (Panda_GameManager.isEatingRoundRunning) {

            if (Choose(new float[] {60, 40}) == 0) {
                
                Vector2 distance;

                if (panda.name == "LeftPanda") distance = new Vector2(144, 0);
                else if (panda.name == "RightPanda") distance = new Vector2(-144, 0);
                else distance = new Vector2(0, 144);

                float seconds = Panda_GameManager.mode == 0 ? 0.6f : 0.5f;

                StartCoroutine(MovePanda(panda, distance, seconds));
                yield return new WaitForSeconds(seconds * 2);
            }

            yield return new WaitForSeconds(1.8f);
        }
    }

    private IEnumerator MovePanda(GameObject panda, Vector2 distance, float seconds) {

        panda.GetComponent<Image>().color = new Color(1, 1, 1, 1);

        Vector2 pos = panda.GetComponent<RectTransform>().anchoredPosition;

        float time = 0;
        while (time < seconds && !isCatched) {
            time += Time.deltaTime;

            panda.GetComponent<RectTransform>().anchoredPosition
            = pos + distance * time / seconds;

            yield return null;
        }

        while (time > 0 && !isCatched) {
            time -= Time.deltaTime;

            panda.GetComponent<RectTransform>().anchoredPosition
            = pos + distance * time / seconds;

            yield return null;
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
