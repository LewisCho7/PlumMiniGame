using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float survived_time;
    public static bool game_continue;
    // Start is called before the first frame update
    void Start()
    {
        game_continue = true;
    }

    // Update is called once per frame
    void Update()
    {
        survived_time += Time.deltaTime;
    }
}
