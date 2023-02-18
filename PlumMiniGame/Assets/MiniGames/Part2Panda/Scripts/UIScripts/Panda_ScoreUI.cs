using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Panda_ScoreUI : MonoBehaviour
{
    private TextMeshProUGUI text;

    void Awake() {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update() {
        text.text = Panda_GameManager.score.ToString();
    }
}
