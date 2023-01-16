using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panda_UIManager : MonoBehaviour
{
    [SerializeField] private Sprite[] numberSprites = new Sprite[10];
    [SerializeField] private Sprite[] basicSprites = new Sprite[6];
    enum Sprites { O, X, gameover, start, go, round}

    [SerializeField] private GameObject panel;
    
    private RectTransform imgTransform;
    private Image img;



    void Awake() {
        imgTransform = panel.transform.Find("Image").GetComponent<RectTransform>();
        img = panel.transform.Find("Image").GetComponent<Image>();
    }

    IEnumerator Start() {
        panel.SetActive(true);

        for (int i = 3; i > 0; i--) {

            imgTransform.sizeDelta = new Vector2(numberSprites[i].rect.width, numberSprites[i].rect.height);

            img.sprite = numberSprites[i];
            yield return new WaitForSeconds(1);
        }

        imgTransform.sizeDelta = new Vector2(720, 1280);

        img.sprite = basicSprites[(int) Sprites.round];
        yield return new WaitForSeconds(1);

        img.sprite = basicSprites[(int) Sprites.start];
        yield return new WaitForSeconds(0.8f);

        panel.SetActive(false);

        Panda_GameManager.isEatingRoundStart = true;
    }

    void Update() {
        
    }
}
