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
            int chance = Random.Range(1, 5);

            if (chance == 1)
            {
                GenerateBird();
            }
            yield return cool_down;
            chance = Random.Range(1, 5);
            if (chance == 1)
            {
                GenerateMeteo();
            }
        }
    }
    private void GenerateBird()
    {
        var new_bird = Instantiate(bird);
        Destroy(new_bird, 5f);
    }

    private void GenerateMeteo()
    {
        var new_meteo = Instantiate(meteo);
    }
}
