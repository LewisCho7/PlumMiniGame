using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
     
    // Update is called once per frame
    void Update()
    {
        if(Ski_GameManager.instance.timer > 2f)
        {
            transform.position += Vector3.down * Ski_GameManager.instance.gameSpeed * Time.deltaTime;

        }

    }
}
