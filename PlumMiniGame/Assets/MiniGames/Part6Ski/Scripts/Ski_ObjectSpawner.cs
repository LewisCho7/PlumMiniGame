using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Redcode.Pools;

public class Ski_ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform playerPos;

    public GameObject skiline;

    private SkiLine skiLine;

    [SerializeField]
    private Ski_Objects barrier;
    [SerializeField]
    private Ski_Objects rock;
    [SerializeField]
    private Ski_Objects item;
    [SerializeField]
    private Ski_Objects rescue;

    Pool<Ski_Objects> barrierPool;
    Pool<Ski_Objects> itemPool;
    Pool<Ski_Objects> rescuePool;
    Pool<Ski_Objects> rockPool;

    private Ski_Objects newBarrier;
    private Ski_Objects newItem;
    private Ski_Objects newRescue;
    private Ski_Objects newRock;


    private float[] randomSpawnPos;

    private bool barrierSpawned;
    private int barrierIndex;

    private void Awake()
    {
        skiLine = skiline.GetComponent<SkiLine>();

        barrierPool = Pool.Create<Ski_Objects>(barrier, 0);
        itemPool = Pool.Create<Ski_Objects>(item, 0);  
        rescuePool = Pool.Create<Ski_Objects>(rescue, 0);
        rockPool = Pool.Create<Ski_Objects>(rock, 0);
     

        randomSpawnPos = new float[] { 60, 130, 200, 270, 340 };
    }
    private void Start()
    {
        startCoroutines();
        
    }
    private void Update()
    {
        if (Ski_GameManager.instance.isGameOver)
        {
            StopAllCoroutines();
        }
    }

    private void startCoroutines()
    {
        StartCoroutine(IE_SpawnBarrier());
        StartCoroutine(IE_SpawnItem());
        StartCoroutine(IE_SpawnRescue());
        if (DataManager.instance.isHardMode)
        {
            Debug.Log("isHardMode");
            StartCoroutine(IE_SpawnRock());
        }
    }
    private IEnumerator IE_SpawnBarrier()
    {
        while (true)
        {
            if(Ski_GameManager.instance.timer < 3)
            {
                yield return new WaitForSeconds(3f);
            }

            barrierSpawned = false;
            
            int i = Random.Range(0, 5);
            Vector3 spawnPos = new Vector3(skiLine.lastPos.x + randomSpawnPos[i], skiLine.lastPos.y + 45f, transform.position.z);
            barrierIndex = i;

            if (Ski_GameManager.instance.timer < 30)
            {
                newBarrier = barrierPool.Get();
                newBarrier.transform.position = spawnPos;
                barrierSpawned = true;

                StartCoroutine(IE_ReleaseBarrier(newBarrier));
                yield return new WaitForSeconds(3f);
            }
            else
            {
                newBarrier = barrierPool.Get();
                newBarrier.transform.position = spawnPos;
                barrierSpawned= true;

                StartCoroutine(IE_ReleaseBarrier(newBarrier));
                yield return new WaitForSeconds(2f);
            }
        }

    }
    private IEnumerator IE_SpawnRock()
    {
        yield return new WaitForSeconds(1f);
        while (true)
        {
            if(Ski_GameManager.instance.timer < 3)
            {
                yield return new WaitForSeconds(3f);
            }

            int j = Random.Range(0, 10);
            if(j > 2)
            {
                yield return new WaitForSeconds(3f);
                continue;
            }

            barrierSpawned = false; 
            
            int i = Random.Range(0, 5);
            Vector3 spawnPos = new Vector3(skiLine.lastPos.x + randomSpawnPos[i], skiLine.lastPos.y + 45f, transform.position.z);
            barrierIndex = i;


            if (Ski_GameManager.instance.timer < 30)
            {
                newRock = rockPool.Get();
                newRock.transform.position = spawnPos;
                barrierSpawned = true;

                StartCoroutine(IE_ReleaseRock(newRock));
                yield return new WaitForSeconds(3f);
            }
            else
            {
                newRock = rockPool.Get();
                newRock.transform.position = spawnPos;
                barrierSpawned = true;

                StartCoroutine(IE_ReleaseRock(newRock));
                yield return new WaitForSeconds(2f);
            }
        }

    }
    private IEnumerator IE_SpawnItem()
    {
        while (true)
        {
            if (Ski_GameManager.instance.timer < 3)
            {
                yield return new WaitForSeconds(3f);
            }
            yield return new WaitUntil(() => barrierSpawned == true);

            int prob = Random.Range(0, 10);
            
            if(prob < 8)
            {
                yield return new WaitForSeconds(3f);
                continue;
            }

            int i = Random.Range(0, 5);
            Vector3 spawnPos;

            if (i == barrierIndex && Ski_GameManager.instance.timer < 30f)
            {
                List<float> resizedPos = new List<float>();
                for (int j = 0; j < 5; j++)
                {
                    if (j != i)
                    {
                        resizedPos.Add(randomSpawnPos[j]);
                    }
                }
                i = Random.Range(0, 4);
                spawnPos = new Vector3(skiLine.lastPos.x + resizedPos[i], skiLine.lastPos.y+45f, transform.position.z);
            }
            else
            {
                spawnPos = new Vector3(skiLine.lastPos.x + randomSpawnPos[i], skiLine.lastPos.y+45f, transform.position.z);
            }

            newItem = itemPool.Get();
            newItem.transform.position = spawnPos;
            StartCoroutine(IE_ReleaseItem(newItem));

            yield return new WaitForSeconds(2.5f);      
            
        }
    }

    private IEnumerator IE_SpawnRescue()
    {
        while (true)
        {
            if(Ski_GameManager.instance.timer < 3)
            {
                yield return new WaitForSeconds(4f);
            }
            yield return new WaitUntil(() => barrierSpawned == true);

            int prob = Random.Range(0, 10);

            if (prob < 5)
            {
                yield return new WaitForSeconds(3f);
                continue;
            }

            int i = Random.Range(0, 5);
            Vector3 spawnPos;

            if (i == barrierIndex && Ski_GameManager.instance.timer < 30f)
            {
                List<float> resizedPos = new List<float>();
                for (int j = 0; j < 5; j++)
                {
                    if (j != i)
                    {
                        resizedPos.Add(randomSpawnPos[j]);
                    }
                }
                i = Random.Range(0, 4);
                spawnPos = new Vector3(skiLine.lastPos.x + resizedPos[i], skiLine.lastPos.y+45f, transform.position.z);
            }
            else
            {
                spawnPos = new Vector3(skiLine.lastPos.x + randomSpawnPos[i], skiLine.lastPos.y+45f, transform.position.z);
            }


            newRescue = rescuePool.Get();
            newRescue.transform.position = spawnPos;
            newRescue.setSprite();
            newRescue.transform.localScale = new Vector3(70f, 80f, newRescue.transform.position.z);
            StartCoroutine(IE_ReleaseRescue(newRescue));

            yield return new WaitForSeconds(3f);

        }
    }

    IEnumerator IE_ReleaseBarrier(Ski_Objects barrier)
    {
        while (barrier)
        {

            if (barrier.transform.position.y > playerPos.position.y + 450f)
            {
                barrierPool.Take(barrier);

                yield break;
            }
            yield return new WaitForSeconds(5f);
        }
    }
    IEnumerator IE_ReleaseItem(Ski_Objects item)
    {
        while (item)
        {
            if (item.transform.position.y > playerPos.position.y + 450f)
            {
                itemPool.Take(item);
                yield break;
            }
            yield return new WaitForSeconds(5f);
        }
    }
    IEnumerator IE_ReleaseRescue(Ski_Objects rescue)
    {
        while (rescue)
        {
            if (rescue.transform.position.y > playerPos.position.y + 450f)
            {
                rescuePool.Take(rescue);
                yield break;
            }
            yield return new WaitForSeconds(5f);
        }
    }
    IEnumerator IE_ReleaseRock(Ski_Objects rock)
    {
        while (rock)
        {
            if (rock.transform.position.y > playerPos.position.y + 450f)
            {
                rockPool.Take(rock);
                yield break;
            }
            yield return new WaitForSeconds(5f);
        }
    }

    public void releaseRockNow(Ski_Objects rock)
    {
        rockPool.Take(rock);
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
