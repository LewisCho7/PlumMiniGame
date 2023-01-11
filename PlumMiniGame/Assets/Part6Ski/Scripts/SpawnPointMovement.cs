using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject skiline;

    private SkiLine skiLine;

    private Vector2 lastPosCheck;

    void Awake()
    {
        skiLine = skiline.GetComponent<SkiLine>();
    }
    private void Start()
    {
        lastPosCheck = skiLine.lastPos;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveToPoint();
    }
    private void moveToPoint()
    {
        if(lastPosCheck == skiLine.lastPos)
        {
            return;
        }
        else
        {
            transform.position = new Vector3(transform.position.x, skiLine.lastPos.y, transform.position.z);
            lastPosCheck = skiLine.lastPos;
        }

    }

}
