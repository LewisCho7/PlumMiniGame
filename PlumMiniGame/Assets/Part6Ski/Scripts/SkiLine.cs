using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(EdgeCollider2D))]
public class SkiLine : MonoBehaviour
{
    // ���� ��ȭ ��� �迭
    private float[] slope;

    // ������ ���� ��� gameobject (���� ������ �Բ� ����)
    [SerializeField]
    private GameObject besideLine;

    // �� ���� ��ġ ���� ���� �÷��̾� ��ġ
    [SerializeField]
    private Transform playerPos;

    // �� �߱� ���� LineRenderer ������Ʈ
    private LineRenderer lineRenderer;
    private LineRenderer besideLineRenderer;
    
    // ���� �浹�� �ο��� EdgeCollider2D ������Ʈ
    EdgeCollider2D edgeCollider;
    EdgeCollider2D edgeCollider2;

    // ���� �ձ� ���� ������ ���� ��ġ�� ���� ���� ��ġ ����
    public Vector2 lastPos;
    public Vector2 nextPos;

    // ������ ���� index
    public int index = 1;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        besideLineRenderer = besideLine.GetComponent<LineRenderer>();
        edgeCollider = GetComponent<EdgeCollider2D>();
        edgeCollider2 = besideLine.GetComponent<EdgeCollider2D>();

        slope = new float[] { 20f, 20f, 15f, 5f, 20f, 15f, 5f };

        //ski = besideLine.GetComponent<SkiLine>();
    }
    private void Start()
    {
        //StartCoroutine(IE_DrawNewLine());
    }
    private void Update()
    {
        AddNewLine();
        if (Ski_GameManager.instance.isGameOver)
        {
            StopAllCoroutines();
        }
    }
    private void FixedUpdate()
    {
        SetEdgeCollider();
    }

   

    private void AddNewLine()
    {

        lastPos = lineRenderer.GetPosition(index);
        if(lastPos.y < playerPos.position.y - 1280)
        {
            return;
        }

        lineRenderer.positionCount++;
        besideLineRenderer.positionCount++;
        CalcNextPos();
        index++;
        lineRenderer.SetPosition(index, nextPos);
        besideLineRenderer.SetPosition(index, new Vector2(nextPos.x + 400, nextPos.y));
       
    }
    private void CalcNextPos()
    {
        float slopeIndex = getSlope();

        nextPos = new Vector2(lastPos.x + 150 * Mathf.Cos(slopeIndex * Mathf.Deg2Rad), lastPos.y - 150 * Mathf.Sin(slopeIndex * Mathf.Deg2Rad));

        if (nextPos.x < -360f)
        {
            nextPos = new Vector2(lastPos.x + 150 * Mathf.Cos(60 * Mathf.Deg2Rad), lastPos.y - 150 * Mathf.Sin(60 * Mathf.Deg2Rad));
        }
        else if (nextPos.x > -40f)
        {
            nextPos = new Vector2(lastPos.x - 150 * Mathf.Cos(60 * Mathf.Deg2Rad), lastPos.y - 150 * Mathf.Sin(60 * Mathf.Deg2Rad));
        }
    }

    private float getSlope()
    {
        float slopeIndex = Choose(slope);
        float slopeValue = 90;
        switch (slopeIndex)
        {
            case 0:
                slopeValue = 90;
                break;
            case 1:
                slopeValue = 75;
                break;
            case 2:
                slopeValue = 60;
                break;
            case 3:
                slopeValue = 45;
                break;
            case 4:
                slopeValue = 105;
                break;
            case 5:
                slopeValue = 120;
                break;
            case 6:
                slopeValue = 135;
                break;
        }
        return slopeValue;
    }

    IEnumerator IE_DrawNewLine()
    {
        WaitForSeconds ws;

        while (true)
        {
            ws = new WaitForSeconds(0.1f);
            AddNewLine();
            yield return ws;
        }

    }

    private void SetEdgeCollider()
    {
        
        List<Vector2> edgePoints1 = new List<Vector2>();
        List<Vector2> edgePoints2 = new List<Vector2>();

        if(lineRenderer.positionCount < 3)
        {
            for (int i = 0; i < lineRenderer.positionCount; i++)
            {
                Vector2 lineRendererPoint = lineRenderer.GetPosition(i);
                
                edgePoints1.Add(new Vector2(lineRendererPoint.x, lineRendererPoint.y));
                edgePoints2.Add(new Vector2(lineRendererPoint.x + 400, lineRendererPoint.y));
        

            }
        }
        else if(lineRenderer.positionCount < 300)
        {
            for (int i = 0; i < lineRenderer.positionCount; i++)
            {
                Vector2 lineRendererPoint = lineRenderer.GetPosition(i);
                if(lineRendererPoint.y < playerPos.position.y + 100 && lineRendererPoint.y > playerPos.position.y - 100)
                {
                    edgePoints1.Add(new Vector2(lineRendererPoint.x, lineRendererPoint.y));
                    edgePoints2.Add(new Vector2(lineRendererPoint.x + 400, lineRendererPoint.y));
                }
                
            }
        }
        else
        {
            for (int i = lineRenderer.positionCount - 300; i < lineRenderer.positionCount; i++)
            {
                Vector2 lineRendererPoint = lineRenderer.GetPosition(i);
                if (lineRendererPoint.y < playerPos.position.y + 100 && lineRendererPoint.y > playerPos.position.y - 100)
                {
                    edgePoints1.Add(new Vector2(lineRendererPoint.x, lineRendererPoint.y));
                    edgePoints2.Add(new Vector2(lineRendererPoint.x + 400, lineRendererPoint.y));
                }
            }
        }
        
        edgeCollider.SetPoints(edgePoints1);
        edgeCollider2.SetPoints(edgePoints2);
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
