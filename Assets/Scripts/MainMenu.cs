using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    AudioSource mainMenuMusic;
    [SerializeField]
    private AudioClip[] albumSongs;

    private bool creditsIsOn = false;
    private bool settingIsOn = false;

    private bool isMuted = false;
    private int songNumber = 0;

    [SerializeField]
    private GameObject credits;

    [SerializeField]
    private GameObject Settings;

    [SerializeField]
    private Scrollbar volume;

    /*[SerializeField]
    private Sprite[] volumeSprites;

    [SerializeField]
    private Button VolumeButton;*/
    void Awake()
    {
        mainMenuMusic = GetComponent<AudioSource>();
        credits.SetActive(false);
        Settings.SetActive(false);

        volume.value = mainMenuMusic.volume;

        if (albumSongs != null && albumSongs.Length > 0)
            PlaySong();
        else
            Debug.Log("no Music please fix by adding sounds to array named album songs");
    }
    void PlaySong()
    {
        mainMenuMusic.clip = albumSongs[songNumber];
        mainMenuMusic.Play();

        songNumber = (songNumber + 1) % albumSongs.Length;
    }

    public void ChangeVolume()
    {
        mainMenuMusic.volume = volume.value;

    }
   public void ToggleMute()
    {

        isMuted = !isMuted;

        mainMenuMusic.mute = isMuted;
    }
    public void ToggleSettings()
    {
        settingIsOn = !settingIsOn;
        Settings.SetActive(settingIsOn);
    }
    public void ToggleCredit()
    {
        creditsIsOn = !creditsIsOn;
        credits.SetActive(creditsIsOn);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");

    }
    private void Update()
    {
       
        if (!mainMenuMusic.isPlaying)
        {
            PlaySong();
        }
    }
    public void Exit()
    {
        Application.Quit();
        EditorApplication.isPlaying = false;
    }
}
