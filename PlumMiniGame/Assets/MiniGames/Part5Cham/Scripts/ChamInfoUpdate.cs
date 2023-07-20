using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChamInfoUpdate : MonoBehaviour
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
            int final_coin = TextUI.score;
            score.GetComponent<TextMeshProUGUI>().text = TextUI.score.ToString();
            coinBonus.GetComponent<TextMeshProUGUI>().text = '+' + Bonus() + "%";
            coin.GetComponent<TextMeshProUGUI>().text = "+" + (ChamGameManager.CoinCalculate() * (Bonus() / 100 + 1)).ToString();

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

    int Bonus()
    {
        int bonus = 0;
        if (Find(7))
        {
            bonus += 10;
        }
        if (Find(11))
        {
            bonus += 5;
        }
        if (Find(14))
        {
            bonus += 20;
        }
        return bonus;
    }

    private bool Find(int id)
    {
        foreach (int i in DataManager.instance.saveData.rescuedCharacter)
        {
            if (i == id) return true;
        }
        return false;
    }
}
