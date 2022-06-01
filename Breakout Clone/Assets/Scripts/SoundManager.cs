using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] public AudioSource musicSource, effectSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        effectSource = gameObject.AddComponent<AudioSource>();
        effectSource.playOnAwake = false;
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.loop = true;

    }

    private void Start()
    {
        PlayBackgroundMusic(SettingsHolder.Instance._music);
        UpdateVolume();

    }

    public void Play(AudioClip clip)
    {
        if (clip != null)
        {
            effectSource.PlayOneShot(clip);
        }
    }

    public void Stop()
    {
        effectSource.Stop();
    }

    public void PlayBackgroundMusic(AudioClip clip)
    {
        // Don't interupt playback if the clip is already playing
        if (clip != null && clip != musicSource.clip)
        {
            musicSource.clip = clip;
            musicSource.Play();
        }
    }

    private void UpdateVolume()
    {
            musicSource.volume = PlayerPrefs.GetFloat("musicVolume");
            effectSource.volume = PlayerPrefs.GetFloat("effectsVolume");
    }
}
