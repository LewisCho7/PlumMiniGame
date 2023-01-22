using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteppingCloud : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Character")
        {
            if (col.transform.position.y - gameObject.transform.position.y > 80)
            {
                Destroy(gameObject);
            }
        }
    }
}
