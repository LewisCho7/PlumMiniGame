using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panda_BottomPandaClickEvent : MonoBehaviour
{
    void Awake() {
        transform.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
    }

    public void PandaOnClick() {
        Panda_BottomPanda.isCatched = true;
        StartCoroutine(FadeOut());
        Panda_GameManager.score += 10 + Panda_GameManager.mode * 2;
    }

    private IEnumerator FadeOut() {
        int i = 10;

        while (i > 0) {
            i--;

            float f = i / 10.0f;
            Color c = new Color(1, 1, 1, f);
            transform.GetComponent<Image>().color = c;

            yield return new WaitForSeconds(0.02f);
        }

        string[] names = new string[] {"LeftPanda", "CenterPanda", "RightPanda"};
        for (int j = 0; j < 3; j++) {
            if (transform.name == names[j]) {
                transform.GetComponent<RectTransform>().anchoredPosition = Panda_BottomPanda.bottomPandaPosition[j];
            }
        }
    }
}
