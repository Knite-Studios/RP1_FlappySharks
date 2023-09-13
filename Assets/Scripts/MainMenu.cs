using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    AudioSource mainMenuMusic;
    [SerializeField]
    private AudioClip[] albumSongs;

    private bool displayIsOn = false;
    private bool isMuted = false;
    private int songNumber = 0;

    [SerializeField]
    private GameObject credits;

   [SerializeField]
    private GameObject notMuted;
    [SerializeField]
    private GameObject muted;


    /*[SerializeField]
    private Sprite[] volumeSprites;

    [SerializeField]
    private Button VolumeButton;*/
    void Awake()
    {
        mainMenuMusic = GetComponent<AudioSource>();
         credits.SetActive(false);

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
    public void ToggleMute()
    {
        
        isMuted = !isMuted;


      //  VolumeButton.image.sprite = volumeSprites[0];
        
        mainMenuMusic.mute = isMuted;
    }
    public void ToggleCredit()
    {
        displayIsOn = !displayIsOn;
        credits.SetActive(displayIsOn);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");

    }
    private void Update()
    {
            muted.SetActive(isMuted);
            notMuted.SetActive(!isMuted);    
    }
    public void Exit()                 
    {
        Application.Quit();
        EditorApplication.isPlaying = false;
    }
}
