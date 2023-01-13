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
        // 대표 캐릭터를 제외한 배열의 모든 캐릭터 sprite
        int i = Random.Range(0, rescueSprites.Length);

        rescueSprite.sprite = rescueSprites[i];

    }

}
