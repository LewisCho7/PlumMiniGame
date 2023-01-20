using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float survived_time;
    public static bool game_continue;

    [SerializeField]
    private GameObject character;
    [SerializeField]
    private GameObject main_camera;
    // Start is called before the first frame update
    void Start()
    {
        game_continue = true;
    }

    // Update is called once per frame
    void Update()
    {
        survived_time += Time.deltaTime;
        if (!game_continue) StopAllCoroutines();

    }

    IEnumerator GameProcess()
    {
        while(game_continue)
        {
            yield return null;

            if(main_camera.transform.position.y - character.transform.position.y
                > 700)
            {
                game_continue = false;
            }
        }
    }
}
