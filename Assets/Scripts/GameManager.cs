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
    public int score { get; private set; }

    private void Awake()
    {
        player = GetComponentInChildren<Player>();
        spawner = GetComponentInChildren<Spawner>();
    }
    
    public void Retry()
    {

        score = 0;
        scoreText.text = score.ToString();

        paused = false;
        DeathMenu.SetActive(false);
        PauseMenu.SetActive(false);

        Time.timeScale = 1f;
       // player.enabled = true;

        Obstacles[] obstacles = FindObjectsOfType<Obstacles>();

        for (int i = 0; i < obstacles.Length; i++)
        {
            Destroy(obstacles[i].gameObject);
        }
    }

    public void GameOver()
    {
       
        Time.timeScale = 0f;
       // player.enabled = false;

        DeathMenu.SetActive(true); 
    }

    public void Paused()
    {
        paused = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;

        Time.timeScale = 0f;

        PauseMenu.SetActive(false);
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
            if (!paused)  //pause menu if not paused
                Paused();
            else          // if its paused resume when pressed again
                Resume();
        }
    }

    public void Resume()
    {
        paused = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Time.timeScale = 1f;
       // player.enabled = true;
       
    }
}