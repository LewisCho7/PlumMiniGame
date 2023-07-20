using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ski_ScoreBoard : MonoBehaviour
{
    [SerializeField] private GameObject BestScore;
    [SerializeField] private GameObject Score;
    [SerializeField] private GameObject CoinBonus;
    [SerializeField] private GameObject Coin;


    void Start()
    {
        int best_score;
        int score = Ski_GameManager.instance.Score;
        int bonus = 50 * (Ski_GameManager.instance.isHardMode ? 1 : 0);
        int coin = score / 10 + (score >= 500 ? (score / 100 * 5) : 0) + (score >= 1500 ? (score / 1000 * 15) : 0);

        List<int> rescuedCharacter = DataManager.instance.saveData.rescuedCharacter;
        foreach (int ID in rescuedCharacter)
        {
            if (ID == 12) bonus += 5;
            else if (ID == 14 || ID == 10) bonus += 10;
        }
        coin += Mathf.RoundToInt(coin * (bonus / 100f));

        // 최고 기록 갱신
        if (!Ski_GameManager.instance.isHardMode)
        {
            if (score > DataManager.instance.saveData.normalHighScore[4])
            {
                DataManager.instance.saveData.normalHighScore[4] = score;
                DataManager.instance.SaveGame();
            }
            best_score = DataManager.instance.saveData.normalHighScore[4];
        }
        else
        {
            if (score > DataManager.instance.saveData.hardHighScore[4])
            {
                DataManager.instance.saveData.hardHighScore[4] = score;
                DataManager.instance.SaveGame();
            }
            best_score = DataManager.instance.saveData.hardHighScore[4];
        }

        BestScore.GetComponent<TextMeshProUGUI>().text = best_score.ToString();
        Score.GetComponent<TextMeshProUGUI>().text = score.ToString();
        CoinBonus.GetComponent<TextMeshProUGUI>().text = "+" + bonus.ToString() + "%";
        Coin.GetComponent<TextMeshProUGUI>().text = "+" + coin.ToString();

        DataManager.instance.saveData.currentCoin += coin;
        DataManager.instance.SaveGame();
    }
}
