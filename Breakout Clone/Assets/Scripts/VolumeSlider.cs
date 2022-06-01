using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider _musicVolume;
    [SerializeField] private Slider _effectsVolume;


    private void Start()
    {
        Load();
    }

    public void MusicVolume()
    {
        SoundManager.Instance.musicSource.volume = _musicVolume.value;
        Save();
    }

    public void effectsVolume()
    {
        SoundManager.Instance.effectSource.volume = _effectsVolume.value;
        Save();
    }


    public void Load()
    {
        _musicVolume.value = PlayerPrefs.GetFloat("musicVolume");
        _effectsVolume.value = PlayerPrefs.GetFloat("effectsVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", _musicVolume.value);
        PlayerPrefs.SetFloat("effectsVolume", _effectsVolume.value);
    }
}
