using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Redcode.Pools;

public class TreeSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject firstTrees;

    [SerializeField]
    private Transform[] spawnpoint;

    [SerializeField]
    private TreeMovement TreePrefab;

    [SerializeField]
    private Transform playerPos;
    
    public GameObject skiline;

    private SkiLine skiLine;

    Pool<TreeMovement> TreeMovementPool;

    private TreeMovement tree;

    private Vector2 lineLastPos;

    private void FixedUpdate()
    {
        checkLastPos();
    }

    private void Awake()
    {
        skiLine = skiline.GetComponent<SkiLine>();
        TreeMovementPool = Pool.Create<TreeMovement>(TreePrefab, 0);

    }

    private void Start()
    {
        lineLastPos = skiLine.lastPos;
        StartCoroutine(IE_SpawnTree());
    }

    private void checkLastPos()
    {
        if (lineLastPos == skiLine.lastPos)
        {
            return;
        }
        else
        {
            lineLastPos = skiLine.lastPos;
            return;
        }
    }


    IEnumerator IE_SpawnTree()
    {
        WaitForSeconds ws;

        while (true)
        {
            ws = new WaitForSeconds(0.1f);

            if(lineLastPos.y < playerPos.position.y - 1280)
            {
                yield return null;
            }
            for(int i = 0; i < spawnpoint.Length; i++)
            {
                if(skiLine.index < 3)
                {
                    break;
                }
                if (spawnpoint[i].position.x < lineLastPos.x - 50f || spawnpoint[i].position.x > lineLastPos.x + 440f)
                {
                    tree = TreeMovementPool.Get();
                    tree.transform.parent = gameObject.transform;
                    tree.transform.position = new Vector3(spawnpoint[i].position.x, spawnpoint[i].position.y + 68f, spawnpoint[i].position.z);                    
                    StartCoroutine(IE_ReleaseTree(tree));
                }
            }
            yield return ws;
        }
    }

    IEnumerator IE_ReleaseTree(TreeMovement tree)
    {

        while (true)
        {
            if(tree.transform.position.y > playerPos.position.y + 100f)
            {
                TreeMovementPool.Take(tree);
                yield break;
            }
            yield return new WaitForSeconds(5f);
        }
    }
}
