using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Music")]
    public AudioClip mainMenuMusic;
    public AudioClip gameplayMusic;

    [Header("Sound effects")]
    public AudioClip loseLifeSound;
    public AudioClip levelCompleteSound;

    private AudioSource musicSource;
    private AudioSource sfxSource;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Tworzymy dwa osobne AudioSource na tym samym obiekcie
        // jeden do muzyki (zapętlonej), drugi do efektów
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.loop = true;
        musicSource.volume = 0.5f;

        sfxSource = gameObject.AddComponent<AudioSource>();
        sfxSource.loop = false;
        sfxSource.volume = 1f;
    }

    void OnEnable()
    {
        // Słuchamy zmian stanu gry
        if (GameManager.Instance != null)
            GameManager.Instance.OnStateChanged += HandleStateChanged;
    }

    void OnDisable()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.OnStateChanged -= HandleStateChanged;
    }

    void HandleStateChanged(GameManager.GameState newState)
    {
        switch (newState)
        {
            case GameManager.GameState.MainMenu:
                PlayMusic(mainMenuMusic);
                break;
            case GameManager.GameState.Playing:
                PlayMusic(gameplayMusic);
                break;
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        if (clip == null) return;
        if (musicSource.clip == clip) return; // już gra ta sama — nie restartuj

        musicSource.clip = clip;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip == null) return;
        sfxSource.PlayOneShot(clip);
    }

    public void PlayLoseLife()
    {
        PlaySFX(loseLifeSound);
    }

    public void PlayLevelComplete()
    {
        PlaySFX(levelCompleteSound);
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = Mathf.Clamp01(volume);
    }
}