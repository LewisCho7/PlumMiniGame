using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Panda_ScoreBoard : MonoBehaviour
{
    [SerializeField] private GameObject BestScore;
    [SerializeField] private GameObject Score;
    [SerializeField] private GameObject CoinBonus;
    [SerializeField] private GameObject Coin;

    
    void Start()
    {
        int best_score;
        int score = Panda_GameManager.score;
        int bonus = 30 + 50 * Panda_GameManager.mode;
        int coin = score / 10 + (score >= 500 ? (score / 100 * 5) : 0) + (score >= 1500 ? (score / 1000 * 15) : 0);
        coin += Mathf.RoundToInt(coin * (bonus / 100f));

        // 최고 기록 갱신
        if (Panda_GameManager.mode == 0) {
            if (score > DataManager.instance.saveData.normalHighScore[1]) {
                DataManager.instance.saveData.normalHighScore[1] = score;
                DataManager.instance.SaveGame();
            }
            best_score = DataManager.instance.saveData.normalHighScore[1];
        } else {
            if (score > DataManager.instance.saveData.hardHighScore[1]) {
                DataManager.instance.saveData.hardHighScore[1] = score;
                DataManager.instance.SaveGame();
            }
            best_score = DataManager.instance.saveData.hardHighScore[1];
        }

        BestScore.GetComponent<TextMeshProUGUI>().text = best_score.ToString();
        Score.GetComponent<TextMeshProUGUI>().text = score.ToString();
        CoinBonus.GetComponent<TextMeshProUGUI>().text = "+" + bonus.ToString() + "%";
        Coin.GetComponent<TextMeshProUGUI>().text = coin.ToString();

        DataManager.instance.saveData.currentCoin += coin;
        DataManager.instance.SaveGame();
    }
}
