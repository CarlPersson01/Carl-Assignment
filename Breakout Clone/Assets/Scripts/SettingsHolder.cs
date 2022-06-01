using UnityEngine;

public class SettingsHolder : MonoBehaviour
{
    public AudioClip _music;
    public AudioClip _score;
    public AudioClip _miss;
    public AudioClip _loose;
    public AudioClip _paddle;

    public static SettingsHolder Instance;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

}
