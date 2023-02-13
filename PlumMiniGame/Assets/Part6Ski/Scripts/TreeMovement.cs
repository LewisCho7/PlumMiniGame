using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMovement : MonoBehaviour
{
    public float movementSpeed;

    private void Update()
    {
        transform.position += Vector3.up * movementSpeed * Time.deltaTime;
    }

}
