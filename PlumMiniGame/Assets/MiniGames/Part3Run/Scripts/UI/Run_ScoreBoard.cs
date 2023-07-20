using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Run_ScoreBoard : MonoBehaviour
{
    [SerializeField] private GameObject BestScore;
    [SerializeField] private GameObject Score;
    [SerializeField] private GameObject CoinBonus;
    [SerializeField] private GameObject Coin;

    
    void Start()
    {
        int best_score;
        int score = Run_GameManager.score;
        int bonus = 50 * (Run_GameManager.isEasyMode ? 0 : 1);
        int coin = score / 10 + (score >= 500 ? (score / 100 * 5) : 0) + (score >= 1500 ? (score / 1000 * 15) : 0);
        
        List<int> rescuedCharacter = DataManager.instance.saveData.rescuedCharacter;
        foreach (int ID in rescuedCharacter) {
            if (ID == 12) bonus += 5;
            else if (ID == 6 || ID == 8 || ID == 14) bonus += 10;
        }
        coin += Mathf.RoundToInt(coin * (bonus / 100f));

        // 최고 기록 갱신
        if (Run_GameManager.isEasyMode) {
            if (score > DataManager.instance.saveData.normalHighScore[2]) {
                DataManager.instance.saveData.normalHighScore[2] = score;
                DataManager.instance.SaveGame();
            }
            best_score = DataManager.instance.saveData.normalHighScore[2];
        } else {
            if (score > DataManager.instance.saveData.hardHighScore[2]) {
                DataManager.instance.saveData.hardHighScore[2] = score;
                DataManager.instance.SaveGame();
            }
            best_score = DataManager.instance.saveData.hardHighScore[2];
        }

        BestScore.GetComponent<TextMeshProUGUI>().text = best_score.ToString();
        Score.GetComponent<TextMeshProUGUI>().text = score.ToString();
        CoinBonus.GetComponent<TextMeshProUGUI>().text = "+" + bonus.ToString() + "%";
        Coin.GetComponent<TextMeshProUGUI>().text = "+" + coin.ToString();

        DataManager.instance.saveData.currentCoin += coin;
        DataManager.instance.SaveGame();
    }
}
