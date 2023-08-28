using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    private bool can_destroy;
    // Start is called before the first frame update
    void Start()
    {
        can_destroy = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnBecameVisible()
    {
        can_destroy = true;
    }

    private void OnBecameInvisible()
    {
        if (can_destroy)
        {
            Destroy(gameObject);
        }
    }
}
