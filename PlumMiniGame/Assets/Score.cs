using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int score = (int)GameManager.survived_time * 10;
        GetComponent<TextMeshProUGUI>().text = score.ToString();
    }
}
