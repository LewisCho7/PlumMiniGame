using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ski_Objects : MonoBehaviour
{
    [SerializeField]
    private Sprite[] rescueSprites;

    private SpriteRenderer rescueSprite;

    /*private GameObject barrier;

    private GameObject item;*/

    private void OnEnable()
    {
        rescueSprite = GetComponent<SpriteRenderer>();
    }

    public void setSprite()
    {
        // ��ǥ ĳ���͸� ������ �迭�� ��� ĳ���� sprite
        int i = Random.Range(0, rescueSprites.Length);

        rescueSprite.sprite = rescueSprites[i];

    }

}
