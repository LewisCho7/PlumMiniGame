using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JumpInfoUpdate : MonoBehaviour
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
            int final_coin = TextUI.score;
            score.GetComponent<TextMeshProUGUI>().text = TextUI.score.ToString();
            coinBonus.GetComponent<TextMeshProUGUI>().text = "+" + Bonus() + "%";
            coin.GetComponent<TextMeshProUGUI>().text = "+" + (JumpGameManager.CoinCalculate() * (Bonus() / 100 + 1)).ToString();

            if (JumpGameManager.hard_mode)
            {
                if (TextUI.score > DataManager.instance.saveData.hardHighScore[0])
                    DataManager.instance.saveData.hardHighScore[0] = TextUI.score;

                bestScore.GetComponent<TextMeshProUGUI>().text
                    = DataManager.instance.saveData.hardHighScore[0].ToString();
            }
            else
            {
                if (TextUI.score > DataManager.instance.saveData.normalHighScore[0])
                    DataManager.instance.saveData.normalHighScore[0] = TextUI.score;

                bestScore.GetComponent<TextMeshProUGUI>().text
                    = DataManager.instance.saveData.normalHighScore[0].ToString();
            }
        }
    }

    int Bonus()
    {
        int bonus = 0;
        if (Find(6))
        {
            bonus += 10;
        }
        if (Find(13))
        {
            bonus += 20;
        }
        if (JumpGameManager.hard_mode)
        {
            bonus += 50;
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
