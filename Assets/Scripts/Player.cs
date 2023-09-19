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

    [SerializeField]
    private int powerUpTime = 5;

    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Sprite[] sprites;

    private int spriteIndex;

    public Vector3 originalPosition;
    // Start is called before the first frame update

    AudioSource pickUp;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalPosition = transform.position;
        pickUp = GetComponent<AudioSource>();
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

        if (other.gameObject.CompareTag("obstacle") && !GameManager.Instance.hasPowerUp || other.gameObject.CompareTag("border"))
        {
            GameManager.Instance.GameOver();
        }                                    
        else if (other.gameObject.CompareTag("score"))
        {
            GameManager.Instance.IncreaseScore();
        }
        else if (other.gameObject.CompareTag("collectable"))
        {
            Destroy(other.gameObject);
            GameManager.Instance.hasPowerUp = true;
            pickUp.Play();
            //wait 5 seconds and make it false
            StartCoroutine(GameManager.Instance.PowerUpTimer(powerUpTime));
        }
    }
   
    public void ResetGravity()
    {
        direction.y = 0;
    }

}
