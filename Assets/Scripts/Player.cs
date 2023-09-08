using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 direction;

    [SerializeField]
    private float gravity = -9.8f;

    [SerializeField]
    private float strength = 5f;

    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Sprite[] sprites;

    private int spriteIndex;
    GameManager gameManager;

    // Start is called before the first frame update
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(SpriteAnimation), 0.15f, 0.15f);
    }

    private void SpriteAnimation()
    {
        spriteIndex++;
        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;

        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "obstacle")
        {
            gameManager.GameOver();
        }
        else if (other.gameObject.tag == "score")
        {
            gameManager.IncreaseScore();
        }
    }
}
