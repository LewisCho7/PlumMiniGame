using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject bird;
    [SerializeField] 
    private GameObject meteo;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ObstacleGenerate());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator ObstacleGenerate()
    {
        var cool_down = new WaitForSeconds(2);
        while (GameManager.game_continue)
        {
            yield return null;
            if(GameManager.survived_time >= 20)
            {
                if (Random.Range(1, 5) == 1)
                {
                    GenerateBird();
                }
                yield return cool_down;
                if (Random.Range(1, 5) == 1)
                {
                    GenerateMeteo();
                }
                yield return cool_down;
            }
        }
    }
    private void GenerateBird()
    {
        GameObject new_bird = Instantiate(bird);
        Destroy(new_bird, 10);
    }

    private void GenerateMeteo()
    {
        GameObject new_meteo = Instantiate(meteo);
        Destroy(new_meteo, 10);
    }
}
