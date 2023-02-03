using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private SpriteRenderer sr;
    [SerializeField] 
    private Sprite[] goto_backgrounds;
    [SerializeField] 
    private Sprite[] backgrounds;
    [SerializeField]
    private GameObject background;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(BackgroundControl());
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    IEnumerator BackgroundControl()
    {
        while (GameManager.game_continue)
        {
            yield return null;
            int timer = (int)GameManager.survived_time;

            switch (timer)
            {
                case 20:
                    sr.sprite = goto_backgrounds[0];
                    gameObject.transform.position
                        = new Vector3(0, background.transform.position.y + 1280, 0);
                    while (gameObject.transform.position.y - background.transform.position.y > 10)
                    {
                        yield return null;
                    }
                    background.GetComponent<SpriteRenderer>().sprite = backgrounds[1];
                    yield return new WaitForSeconds(1);
                    break;
                case 60:
                    sr.sprite = goto_backgrounds[1];
                    gameObject.transform.position
                       = new Vector3(0, background.transform.position.y + 1280, 0);
                    while (gameObject.transform.position.y - background.transform.position.y > 10)
                    {
                        yield return null;
                    }
                    background.GetComponent<SpriteRenderer>().sprite = backgrounds[2];
                    yield return new WaitForSeconds(1);
                    break;
                case 120:
                    gameObject.transform.position
                       = new Vector3(0, background.transform.position.y + 1280, 0);
                    while (gameObject.transform.position.y - background.transform.position.y > 10)
                    {
                        yield return null;
                    }
                    background.GetComponent<SpriteRenderer>().sprite = backgrounds[3];
                    yield return new WaitForSeconds(1);
                    break;
            }
        }
    }
}
