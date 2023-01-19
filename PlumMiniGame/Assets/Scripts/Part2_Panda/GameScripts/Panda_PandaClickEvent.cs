using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panda_PandaClickEvent : MonoBehaviour
{
    void Start() {
        transform.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
    }

    public void OnClick() {

        // 아직 선택 라운드가 시작되지 않았다면 함수 종료
        if (!Panda_GameManager.isChooseRoundStart) return;

        // 답을 이미 선택했다면 함수 종료
        if (Panda_UIManager.inputAnswer != -1) return;

        Debug.Log(transform.name);
        Panda_UIManager.inputAnswer = transform.name[5] - '1';
    }
}
