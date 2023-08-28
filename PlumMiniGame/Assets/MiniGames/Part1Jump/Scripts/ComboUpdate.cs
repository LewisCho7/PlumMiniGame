using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboUpdate : MonoBehaviour
{
    private Queue<GameObject> q = new Queue<GameObject>();
    private static ComboUpdate instance;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        instance.q.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        if (instance.q.Count >= 5)
        {
            JumpGameManager.score += 15;
            q.Clear();
        } 
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag =="player")
        {
            StartCoroutine(combo());
        }
    }

    private IEnumerator combo()
    {
        instance.q.Enqueue(gameObject);
        yield return new WaitForSeconds(5);
        if (instance.q.Count > 0)
            instance.q.Dequeue();
    }
}
