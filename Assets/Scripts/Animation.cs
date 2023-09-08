using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites;
    [SerializeField]
    private float spriteAnimationSpeed = 1.5f;
    private int spriteIndex;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        InvokeRepeating(nameof(SpriteAnimation), spriteAnimationSpeed, spriteAnimationSpeed);

    }
    private void SpriteAnimation()
    {
        spriteIndex++;
        if (spriteIndex >= sprites.Length)
            spriteIndex = 0;

        spriteRenderer.sprite = sprites[spriteIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
