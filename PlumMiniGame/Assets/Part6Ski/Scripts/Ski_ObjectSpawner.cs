using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Redcode.Pools;

public class Ski_ObjectSpawner : MonoBehaviour
{
    //public GameObject barrierPrefab;
    //public GameObject itemPrefab;

    public GameObject skiline;

    private SkiLine skiLine;

    [SerializeField]
    private Ski_Objects barrier;
 /* [SerializeField]
    private Ski_Objects item;*/

    Pool<Ski_Objects> barrierPool;
    Pool<Ski_Objects> itemPool;

    private Ski_Objects newBarrier;
    private Ski_Objects newItem;


    private float[] randomSpawnPos;

    private void Awake()
    {
        //barrier = barrierPrefab.GetComponent<Ski_Objects>();
        //item = itemPrefab.GetComponent<Ski_Objects>();
        skiLine = skiline.GetComponent<SkiLine>();

        barrierPool = Pool.Create<Ski_Objects>(barrier, 0);
        //itemPool = Pool.Create<Ski_Objects>(item, 0);

        randomSpawnPos = new float[] { 100, 160, 200, 240, 300 };
    }
    private void Start()
    {
        StartCoroutine(IE_SpawnBarrier());
    }

    private IEnumerator IE_SpawnBarrier()
    {
        while (true)
        {
            if(Ski_GameManager.instance.timer < 3)
            {
                yield return null;
            }
            int i = Random.Range(0, 5);
            Vector3 spawnPos = new Vector3(skiLine.lastPos.x + randomSpawnPos[i], skiLine.lastPos.y, transform.position.z);

            if (Ski_GameManager.instance.timer < 30)
            {
                newBarrier = barrierPool.Get();
                newBarrier.transform.position = spawnPos;
                StartCoroutine(IE_ReleaseBarrier(newBarrier));
                yield return new WaitForSeconds(3f);
            }
            else
            {
                newBarrier = barrierPool.Get();
                newBarrier.transform.position = spawnPos;
                StartCoroutine(IE_ReleaseBarrier(newBarrier));
                yield return new WaitForSeconds(2f);
            }
        }

    }

    IEnumerator IE_ReleaseBarrier(Ski_Objects barrier)
    {
        yield return new WaitForSeconds(20f + Ski_GameManager.instance.gameSpeed / 100f);
        
        barrierPool.Take(barrier);
    }
    IEnumerator IE_ReleaseItem(Ski_Objects item)
    {
        yield return new WaitForSeconds(25f);

        barrierPool.Take(item);
    }

    float Choose(float[] probs)
    {

        float total = 0;

        foreach (float elem in probs)
        {
            total += elem;
        }

        float randomPoint = Random.value * total;

        for (int i = 0; i < probs.Length; i++)
        {
            if (randomPoint < probs[i])
            {
                return i;
            }
            else
            {
                randomPoint -= probs[i];
            }
        }
        return probs.Length - 1;
    }
}
