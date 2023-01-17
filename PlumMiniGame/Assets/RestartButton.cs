using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class RestartButton : MonoBehaviour
{
    public void RestartButtonClicked()
    {
        SceneManager.LoadScene("Game_5");
    }
}
