using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panda_RoundPanel : MonoBehaviour
{
    private GameObject num1, num2;
    [SerializeField] private Sprite[] numSprites = new Sprite[10];

    
    void Awake() {
        num1 = transform.Find("Num1").gameObject;
        num2 = transform.Find("Num2").gameObject;
    }


    public IEnumerator ShowRoundPanel(int currentRound) {

        gameObject.SetActive(true);

        num1.GetComponent<Image>().sprite = numSprites[currentRound / 10];
        num1.GetComponent<RectTransform>().sizeDelta = numSprites[currentRound / 10].bounds.size * 0.6f;

        num2.GetComponent<Image>().sprite = numSprites[currentRound % 10];
        num2.GetComponent<RectTransform>().sizeDelta = numSprites[currentRound % 10].bounds.size * 0.6f;
        
        yield return new WaitForSeconds(1);

        gameObject.SetActive(false);
    }
}
