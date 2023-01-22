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
        if(!GameManager.game_continue) 
            StopAllCoroutines();
    }

    IEnumerator ObstacleGenerate()
    {
        var cool_down = new WaitForSeconds(2);
        int chance = 0;
        if(GameManager.survived_time > 41)
        {
            while (GameManager.game_continue)
            {
                yield return null;
                 chance = Random.Range(1, 5);
                if (chance == 1)
                {
                    GenerateBird();
                }
                yield return cool_down;
                if (chance == 1)
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
        Destroy(new_bird, 2f);
    }

    private void GenerateMeteo()
    {
        GameObject new_meteo = Instantiate(meteo);
        Destroy(new_meteo, 5f);
    }
}
