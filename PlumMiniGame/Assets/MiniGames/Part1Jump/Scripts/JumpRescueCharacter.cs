using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpRescueCharacter : MonoBehaviour
{
    [SerializeField]
    private Sprite[] character_sprite;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = character_sprite[Random.Range(0, character_sprite.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            JumpGameManager.rescue_num++;
            FadeOut(collision.gameObject);
            //StartCoroutine(ShowRescueEffect(0.8f));
            StartCoroutine(FadeOut(gameObject));
        }
    }

    private IEnumerator FadeOut(GameObject obj)
    {
        int i = 10;
        while (i > 0)
        {
            i -= 1;
            float f = i / 10.0f;
            Color c = new Color(1, 1, 1, f);
            obj.GetComponent<SpriteRenderer>().color = c;
            yield return new WaitForSeconds(0.02f);
        }
        Destroy(obj);
    }

/*    private IEnumerator ShowRescueEffect(float time)
    {
        rescueUI.SetActive(true);
        yield return new WaitForSeconds(time);
        rescueUI.SetActive(false);
    }*/
}
