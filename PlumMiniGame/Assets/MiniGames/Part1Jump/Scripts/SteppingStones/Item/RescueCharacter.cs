using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RescueCharacter : MonoBehaviour
{
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float timer = 0;

        while (timer < 0.5)
        {
            sr.color = new Color(1, 1, 1, 1 / timer);
            gameObject.transform.position += new Vector3(0, 10, 0);
            timer += Time.deltaTime;
        }
        Destroy(gameObject);
        JumpGameManager.rescued_character++;
    }
}
