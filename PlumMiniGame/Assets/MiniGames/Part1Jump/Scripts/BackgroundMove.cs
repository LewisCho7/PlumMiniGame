using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    [SerializeField]
    Sprite[] back_sprite;
    [SerializeField]
    Sprite[] interval_sprite;
    SpriteRenderer back_renderer;
    SpriteRenderer interval_renderer;

    [SerializeField]
    GameObject camera;
    [SerializeField]
    GameObject interval;
    // Start is called before the first frame update
    void Start()
    {
        back_renderer = GetComponent<SpriteRenderer>();
        interval_renderer = interval.GetComponent<SpriteRenderer>();
        StartCoroutine(MovingBackground());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MovingBackground()
    {
        while (true)
        {
            yield return null;
  /*          int time = (int)JumpGameManager.survived_time;
            
            if (time % 20 == 0 && time >= 20)
            {
                interval.transform.position = new Vector3(0, camera.transform.position.y + 1275, 0);
                Debug.Log(time);
                switch (time)
                {
                    case 20:
                        interval_renderer.sprite = interval_sprite[0];
                        break;
                    case 60:
                        interval_renderer.sprite = interval_sprite[1];
                        break;
                    case 120:
                        interval_renderer.sprite = interval_sprite[2];
                        break;
                }

                while (camera.transform.position.y - gameObject.transform.position.y < 1280)
                {
                    yield return null;
                }

                switch (time)
                {
                    case 20:
                        back_renderer.sprite = back_sprite[1];
                        break;
                    case 40:
                        back_renderer.sprite = back_sprite[2];
                        break;
                    case 60:
                        back_renderer.sprite = back_sprite[3];
                        break;

                }
                Debug.Log(time);
            }*/
            gameObject.transform.position = new Vector3(0, camera.transform.position.y, 0);
        }
    }
}
