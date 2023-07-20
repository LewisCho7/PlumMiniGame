using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoUpdate : MonoBehaviour
{
    [SerializeField]
    private GameObject bestScore;
    [SerializeField]
    private GameObject score;
    [SerializeField]
    private GameObject coin;
    [SerializeField]
    private GameObject coinBonus;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!JumpGameManager.game_continue)
        {
            
            score.GetComponent<TextMeshProUGUI>().text = TextUI.score.ToString();
            coinBonus.GetComponent<TextMeshProUGUI>().text = DataManager.instance.saveData.currentBonus.ToString();
            coin.GetComponent<TextMeshProUGUI>().text = JumpGameManager.CoinCalculate().ToString();
        }
    }
}
