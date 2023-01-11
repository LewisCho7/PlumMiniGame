using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ski_GameManager : MonoBehaviour
{
    public static Ski_GameManager instance;

    public float timer;

    public float gameSpeed;

    private void Awake()
    {
        instance = this;
        init();
        StartCoroutine("changeSpeed");
    }

    private void Update()
    {
        timer += Time.deltaTime;
    }

    private IEnumerator changeSpeed()
    {
        while (timer <= 25f)
        {
            gameSpeed += 20f;

            yield return new WaitForSeconds(1f);
        }
    }

    private void init()
    { // 난이도 별 차이 두기
        timer = 0f;
        gameSpeed = 400f;
    }

    public void calculateSpeed()
    {



    }
}
