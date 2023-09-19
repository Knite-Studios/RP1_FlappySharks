using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;

    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<AudioManager>();

            }
            return _instance;
        }
    }

    AudioSource mainSpeaker;
    [SerializeField]
    private AudioClip[] albumSongs;

    private bool isMuted = false;
    private int songNumber = 0;

    //[SerializeField]    private Scrollbar volume;

    /*[SerializeField]
    private GameObject notMuted;
    [SerializeField]
    private GameObject muted;*/


    /*[SerializeField]
    private Sprite[] volumeSprites;

    [SerializeField]
    private Button VolumeButton;*/
    void Awake()
    {
        mainSpeaker = GetComponent<AudioSource>();
        //volume.value = mainSpeaker.volume;

        if (albumSongs != null && albumSongs.Length > 0)
            PlaySong();
        else
            Debug.Log("no Music please fix by adding sounds to array named album songs");
    }
    void PlaySong()
    {
        mainSpeaker.clip = albumSongs[songNumber];
        mainSpeaker.Play();

        songNumber = (songNumber + 1) % albumSongs.Length;
    }
    public void ToggleMute()
    {

        isMuted = !isMuted;


        //  VolumeButton.image.sprite = volumeSprites[0];

        mainSpeaker.mute = isMuted;
    }
    //public void ChangeVolume()
    //{
    //    mainSpeaker.volume = volume.value;

    //}
    private void Update()
    {
        /* muted.SetActive(!isMuted);
         notMuted.SetActive(isMuted);*/

        if (!mainSpeaker.isPlaying)
        {
            PlaySong();
        }
    }

}


