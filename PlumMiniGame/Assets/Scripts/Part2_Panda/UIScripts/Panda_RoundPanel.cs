using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panda_RoundPanel : MonoBehaviour
{
    private Image num1, num2;

    
    void Awake() {
        num1 = transform.Find("Num1").GetComponent<Image>();
        num2 = transform.Find("Num2").GetComponent<Image>();
    }


    public IEnumerator ShowRoundPanel(int currentRound) {

        gameObject.SetActive(true);
        yield return new WaitForSeconds(1);

        gameObject.SetActive(false);
    }
}
