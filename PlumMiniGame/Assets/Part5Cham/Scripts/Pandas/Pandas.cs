using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pandas : MonoBehaviour
{
    [SerializeField]
    GameObject pandas_left;
    [SerializeField]
    GameObject pandas_front;
    [SerializeField]
    GameObject pandas_right;

    private bool turned = false;

    public static int pandas_dir;
    void Start()
    {
        pandas_left.SetActive(false);
        pandas_right.SetActive(false);

    }

    void Update()
    {
        if (GameManager.is_rest)
        {
            pandas_left.SetActive(false);
            pandas_front.SetActive(true);
            pandas_right.SetActive(false);
            turned = false;
        }
        else
        {
            if (!turned)
            {
                pandas_dir = FaceTurning();
                turned = true;
            }
            
        }
    }

    int FaceTurning()
    {
        int dir = Random.Range(0, 2);
        if (dir == 0)
        {
            pandas_left.SetActive(true);
            pandas_front.SetActive(false);
            pandas_right.SetActive(false);
        }
        else if (dir == 1)
        {
            pandas_left.SetActive(false);
            pandas_front.SetActive(false);
            pandas_right.SetActive(true);
        }
        return dir == 0 ? dir : 2;
    }
}
