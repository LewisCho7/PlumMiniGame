using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject[] bottomObstacles = new GameObject[3];
    public GameObject[] topObstacles = new GameObject[3];
    public float speed = 320f;

    public IEnumerator shootStart() {
        while (Player.isAlive && GameManager.time <= 30f) {
            Shoot(Choose(new float[] {6f, 4f}));
            yield return new WaitForSeconds(2f);
        }
    }

    private void Shoot(int index) {

        GameObject newObj;

        if (index == 0) {
            newObj = Instantiate(bottomObstacles[Choose(new float[] {33.3f, 33.3f, 33.3f})], new Vector2(850, 634), Quaternion.identity);
        } else {
            newObj = Instantiate(topObstacles[Choose(new float[] {33.3f, 33.3f, 33.3f})], new Vector2(850, 818), Quaternion.identity);
        }
        newObj.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
        Destroy(newObj, 5f);
    }

    private int Choose (float[] probs) {

        float total = 0;

        foreach (float elem in probs) {
            total += elem;
        }

        float randomPoint = Random.value * total;

        for (int i= 0; i < probs.Length; i++) {
            if (randomPoint < probs[i]) {
                return i;
            }
            else {
                randomPoint -= probs[i];
            }
        }
        return probs.Length - 1;
    }
}
