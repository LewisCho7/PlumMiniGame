using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run_RescueCharacter : MonoBehaviour
{
    public bool isRescued = false;

    void Update()
    {
        // 화면 밖으로 나가면 삭제
        if (transform.position.x < -100) Destroy(this);
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Player") {
            Destroy(this);
        }
    }
}
