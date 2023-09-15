using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();

            }
            return _instance;
        }
    }
    private Player player;
    private Spawner spawner;

    [SerializeField]
    private TMP_Text highscoreText;
    [SerializeField]
    private TMP_Text scoreText;
    [SerializeField]
    private GameObject PauseMenu;
    [SerializeField]
    private GameObject DeathMenu;
    [SerializeField]
    private GameObject Bubble;

    private bool paused = false;
    private bool dead = false;

    public bool hasPowerUp = false;

    public int score { get; private set; }
    private int highscore; // increments the value by 2 if its public, need to figure it out

    private SpriteRenderer spriteRenderer;
    Timer timer;

    private void Awake()
    {
        timer = GetComponentInChildren<Timer>();
        spriteRenderer = Bubble.GetComponent<SpriteRenderer>();

        player = GetComponentInChildren<Player>();
        spawner = GetComponentInChildren<Spawner>();
        highscore = PlayerPrefs.GetInt("highscore", 0);
        highscoreText.text = highscore.ToString();
        DeathMenu.SetActive(false);
        PauseMenu.SetActive(false);
    }
 
    public void Retry()
    {
        dead = false;
        score = 0;
        scoreText.text = score.ToString();
        highscoreText.text = highscore.ToString();
        player.transform.position = player.originalPosition;
        player.enabled = true;
        player.ResetGravity();

        paused = false;
        DeathMenu.SetActive(false);
        PauseMenu.SetActive(false);

        timer.ResetTimer();

        Time.timeScale = 1f;
        Obstacles[] obstacles = FindObjectsOfType<Obstacles>();

        for (int i = 0; i < obstacles.Length; i++)
        {
            Destroy(obstacles[i].gameObject);
        }


    }

    public void GameOver()
    {
        hasPowerUp = false;
        dead = true;
        Time.timeScale = 0f;
        player.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PauseMenu.SetActive(false);
        DeathMenu.SetActive(true);
        highscore = PlayerPrefs.GetInt("highscore", 0);//highscore = 0
        if (highscore < score)//if new score greater than current highscore, then highscore=new score.
        {
            PlayerPrefs.SetInt("highscore", score);//save highscore
        }
        //else no change
        //

    }

    public void Paused()
    {
        paused = true;
        PauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f;


    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
        if (highscore < score)
        {
            highscore = score;
            highscoreText.text = highscore.ToString();
        }
    }

    public void exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !dead)//get enter button
        {
            if (!paused)  //pause menu if not paused
                Paused();
            else          // if its paused resume when pressed again
                Resume();
        }

        if (hasPowerUp)
            Bubble.SetActive(true);
        else
            Bubble.SetActive(false);
    }

    public void Resume()
    {
        if (!dead)
        {
            paused = false;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            Time.timeScale = 1f;
            player.enabled = true;
            PauseMenu.SetActive(false);
        }                                                                  
    }

    public IEnumerator DisablePowerUpAfterDelay(float delay)
    {
        float timer = 0f;
        float initialAlpha = spriteRenderer.color.a;

        while (timer < delay)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(initialAlpha, 0f, timer / delay);
            if (spriteRenderer != null)
            {
                Color color = spriteRenderer.color;
                color.a = alpha;
                spriteRenderer.color = color;
            }

            yield return null;
        }

        hasPowerUp = false;
    }

    public void StartBlinking(float blinkingDuration, float blinkInterval)
    {
        StopCoroutine(BlinkSprite());
        StartCoroutine(BlinkSprite());

        IEnumerator BlinkSprite()
        {
            float endTime = Time.time + blinkingDuration;
            while (Time.time < endTime)
            {
                spriteRenderer.enabled = !spriteRenderer.enabled;
                yield return new WaitForSeconds(blinkInterval);
            }
            spriteRenderer.enabled = true;
        }
    }
}

  
