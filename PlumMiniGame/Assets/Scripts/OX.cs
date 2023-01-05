using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OX : MonoBehaviour
{
    [SerializeField]
    private GameObject O;
    [SerializeField]
    private GameObject X;
    void Start()
    {
        O.SetActive(false);
        X.SetActive(false);
    }

    public void Popresult(bool check)
    {
        if (check)
        {
            O.SetActive(true);
        }
        else
        {
            X.SetActive(true);
        }
    }

    public void TurnDown()
    {
        O.SetActive(false);
        X.SetActive(false);
    }
}
