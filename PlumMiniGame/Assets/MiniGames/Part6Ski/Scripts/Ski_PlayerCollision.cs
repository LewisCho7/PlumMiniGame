using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ski_PlayerCollision : MonoBehaviour
{
    [SerializeField]
    private List<AudioClip> audioClips;

    private AudioSource audioSource;

    enum soundEvent { getItem, useItem, rescue, gameOver}

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            audioSource.clip = audioClips[(int)soundEvent.getItem];
            audioSource.Play();
            Ski_GameManager.instance.hasItem = true;
            StartCoroutine(IE_setItemFalse(collision.gameObject));
        }
        if (collision.gameObject.CompareTag("Rescue"))
        {
            audioSource.clip = audioClips[(int)soundEvent.rescue];
            audioSource.Play();
            Ski_GameManager.instance.rescue();
            StartCoroutine(IE_setBarrierFalse(collision.gameObject));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Line"))
        {
            audioSource.clip = audioClips[(int)soundEvent.gameOver];
            audioSource.Play();
            Ski_GameManager.instance.GameOver();
            //Ski_SceneManager.instance.Invoke("returnScene", 2);

        }
        if (collision.gameObject.CompareTag("Barrier") && Ski_GameManager.instance.hasItem)
        {
            audioSource.clip = audioClips[(int)soundEvent.useItem];
            audioSource.Play();
            StartCoroutine(IE_setBarrierFalse(collision.gameObject));
            Ski_GameManager.instance.Score += 40;
            Ski_GameManager.instance.hasItem = false;
        }
        else if (collision.gameObject.CompareTag("Barrier"))
        {
            audioSource.clip = audioClips[(int)soundEvent.gameOver];
            audioSource.Play();
            Ski_GameManager.instance.GameOver();
            //Ski_SceneManager.instance.Invoke("returnScene", 2);
        }
        if (collision.gameObject.CompareTag("Rock"))
        {
            audioSource.clip = audioClips[(int)soundEvent.gameOver];
            audioSource.Play();
            Ski_GameManager.instance.GameOver();
            //Ski_SceneManager.instance.Invoke("returnScene", 2);
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
