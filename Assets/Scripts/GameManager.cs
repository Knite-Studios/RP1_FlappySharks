using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Player player;
    private Spawner spawner;

    [SerializeField]
    private TMP_Text scoreText;    
    [SerializeField]
    private GameObject gameOver;
    [SerializeField]
    private GameObject retryButton;
    [SerializeField]
    private GameObject exitButton;
    [SerializeField]
    private GameObject resumeButton;

    private bool paused = false;
    public int score { get; private set; }

    private void Awake()
    {
        player = GetComponentInChildren<Player>();
        spawner = GetComponentInChildren<Spawner>();
        Retry();
    }
    
    public void Retry()
    {

        score = 0;
        scoreText.text = score.ToString();

        resumeButton.SetActive(false);
        gameOver.SetActive(false);
        retryButton.SetActive(false);
        exitButton.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Obstacles[] obstacles = FindObjectsOfType<Obstacles>();

        for (int i = 0; i < obstacles.Length; i++)
        {
            Destroy(obstacles[i].gameObject);
        }
    }

    public void GameOver()
    {
        resumeButton.SetActive(false);
        gameOver.SetActive(true);
        retryButton.SetActive(true);
        exitButton.SetActive(true);
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void Paused()
    {
        Time.timeScale = 0f;
        player.enabled = false;
        resumeButton.SetActive(true);
        retryButton.SetActive(true);
        exitButton.SetActive(true);
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void exit()
    {
        Application.Quit();
        EditorApplication.isPlaying = false;  
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//get enter button
        {
            if (!paused)//pause menu if not paused
            {
                paused = true;
                Paused();
            }
            // if its paused resume when pressed again
            else
            {
                paused = false;
                Resume();
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        player.enabled = true;
        resumeButton.SetActive(false);
        retryButton.SetActive(false);
        exitButton.SetActive(false);
    }
}