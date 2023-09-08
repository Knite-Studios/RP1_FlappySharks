using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Player player;
    private Spawner spawner;

    [SerializeField]
    private TMP_Text scoreText;
    [SerializeField]
    private GameObject PauseMenu;
    [SerializeField]
    private GameObject DeathMenu;

    private bool paused = false;
    private bool dead = false;
    public int score { get; private set; }

    private void Awake()
    {
        player = GetComponentInChildren<Player>();
        spawner = GetComponentInChildren<Spawner>();

        DeathMenu.SetActive(false);
        PauseMenu.SetActive(false);
    }

    public void Retry()
    {
        dead = false;
        score = 0;
        scoreText.text = score.ToString();

        player.transform.position = player.originalPosition;
        player.enabled = true;

        paused = false;
        DeathMenu.SetActive(false);
        PauseMenu.SetActive(false);

        Time.timeScale = 1f;
        Obstacles[] obstacles = FindObjectsOfType<Obstacles>();

        for (int i = 0; i < obstacles.Length; i++)
        {
            Destroy(obstacles[i].gameObject);
        }


    }

    public void GameOver()
    {
        dead = true;
        Time.timeScale = 0f;
        player.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PauseMenu.SetActive(false);
        DeathMenu.SetActive(true);
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
    }

    public void exit()
    {
        Application.Quit();
        EditorApplication.isPlaying = false;
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


}