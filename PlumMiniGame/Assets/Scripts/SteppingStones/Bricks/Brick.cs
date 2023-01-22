using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField]
    private GameObject main_camera;

    public float x, y;
    // Start is called before the first frame update
    void Start()
    {
        main_camera = GameObject.Find("Main Camera");
        x = Random.Range(-280, 280);
        y = main_camera.transform.position.y + 650;
        transform.position = new Vector3(x, y, 0);
    }

    void Update()
    {
        
    }
}
