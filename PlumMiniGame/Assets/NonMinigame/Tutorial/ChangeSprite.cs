using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    public Sprite[] sprites;
    SpriteRenderer spriteRenderer;
    public GameObject datamanager;
    CharacterData characterData;

    private void OnEnable()
    {
        characterData = datamanager.GetComponent<CharacterData>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[characterData.selectedCharacterNum];

    }
}
