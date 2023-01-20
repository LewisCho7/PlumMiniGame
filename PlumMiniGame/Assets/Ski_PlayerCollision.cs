using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ski_PlayerCollision : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            Ski_GameManager.instance.hasItem = true;
            StartCoroutine(IE_setItemFalse(collision.gameObject));
        }
        if (collision.gameObject.CompareTag("Rescue"))
        {
            Ski_GameManager.instance.rescue();
            StartCoroutine(IE_setBarrierFalse(collision.gameObject));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Line"))
        {
            Ski_GameManager.instance.GameOver();
            Ski_SceneManager.instance.returnScene();

        }
        if (collision.gameObject.CompareTag("Barrier") && Ski_GameManager.instance.hasItem)
        {
            StartCoroutine(IE_setBarrierFalse(collision.gameObject));
            Ski_GameManager.instance.hasItem = false;
        }
        else if (collision.gameObject.CompareTag("Barrier"))
        {
            Ski_GameManager.instance.GameOver();
            Ski_SceneManager.instance.returnScene();
        }
    }

    private IEnumerator IE_setItemFalse(GameObject item)
    {
        item.SetActive(false);
        while (true)
        {
            yield return null;
            if (item.transform.position.y > transform.position.y + 400f)
            {
                item.SetActive(true);
                yield break;
            }
        }
        
    }
    private IEnumerator IE_setBarrierFalse(GameObject barrier)
    {
        barrier.SetActive(false);
        while (true)
        {
            yield return null;
            if (barrier.transform.position.y > transform.position.y + 400f)
            {
                barrier.SetActive(true);
                yield break;
            }
        }

    }


}
