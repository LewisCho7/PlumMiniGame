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
        if (!ChamGameManager.game_on_process)
        {           
            score.GetComponent<TextMeshProUGUI>().text = TextUI.score.ToString();
            coinBonus.GetComponent<TextMeshProUGUI>().text = '+' + DataManager.instance.saveData.currentBonus.ToString() + "%";
            coin.GetComponent<TextMeshProUGUI>().text = ChamGameManager.CoinCalculate().ToString();

            if (ChamGameManager.hard_mode)
            {
                if (TextUI.score > DataManager.instance.saveData.hardHighScore[3])
                    DataManager.instance.saveData.hardHighScore[3] = TextUI.score;

                bestScore.GetComponent<TextMeshProUGUI>().text
                    = DataManager.instance.saveData.hardHighScore[3].ToString();
            }
            else
            {
                if (TextUI.score > DataManager.instance.saveData.normalHighScore[3])
                    DataManager.instance.saveData.normalHighScore[3] = TextUI.score;

                bestScore.GetComponent<TextMeshProUGUI>().text
                    = DataManager.instance.saveData.normalHighScore[3].ToString();
            }
        }
    }
}
