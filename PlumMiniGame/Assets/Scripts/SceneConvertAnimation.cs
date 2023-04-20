using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneConvertAnimation : MonoBehaviour
{
    [SerializeField] private Image fade;
    [SerializeField] private Canvas canvas;
    public static SceneConvertAnimation instance = null;

    private string targetScene = null;

    void Awake() {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
        
        DontDestroyOnLoad(gameObject);

        Debug.Log("dontdestroy");
    }

    void Update() {
        if (targetScene == null) return;

        if (SceneManager.GetActiveScene().name == targetScene) {
            targetScene = null;
            StartCoroutine(FadeIn());
        }
    }

    public IEnumerator LoadScene(string scene) {

        targetScene = scene;

        canvas.sortingOrder = 1;

        int i = 0;
        while (i < 25)
        {
            i += 1;
            float f = i / 25.0f;
            Color c = new Color(0, 0, 0, f);
            fade.color = c;
            yield return new WaitForSeconds(0.0001f);
        }

        SceneManager.LoadScene(scene);
    }

    public IEnumerator FadeIn() {

        int i = 25;
        while (i > 0)
        {
            i -= 1;
            float f = i / 25.0f;
            Color c = new Color(0, 0, 0, f);
            fade.color = c;
            yield return new WaitForSeconds(0.0001f);
        }

        canvas.sortingOrder = -1;
    }
}
