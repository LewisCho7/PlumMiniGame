using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoundIndicator : MonoBehaviour
{
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = "Round: " + GameManager.round.ToString();
        if (GameManager.is_rest)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
