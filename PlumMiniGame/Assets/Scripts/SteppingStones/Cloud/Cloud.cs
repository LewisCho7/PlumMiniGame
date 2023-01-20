using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField]
    private GameObject main_camera;

    // Start is called before the first frame update
    void Start()
    {
        main_camera = GameObject.Find("Main Camera");
        transform.position
            = new Vector3(Random.Range(-280, 280), main_camera.transform.position.y + 10, 0);
    }

    void Update()
    {

    }
}
