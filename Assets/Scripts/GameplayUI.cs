using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameplayUI : MonoBehaviour
{
    [Header("Lifes")]
    public Image[] lifeIcons;

    [Header("Screens")]
    public GameObject gameOverScreen;
    public GameObject levelCompleteScreen;

    [Header("Button Game Over")]
    public Button restartButton;
    public Button mainMenuButtonGameOver;

    [Header("Button Level Complete")]
    public Button mainMenuButtonComplete;

    void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnLivesChanged += UpdateLives;
            GameManager.Instance.OnStateChanged += HandleStateChanged;
        }

        gameOverScreen.SetActive(false);
        levelCompleteScreen.SetActive(false);

        restartButton.onClick.AddListener(() => GameManager.Instance.RestartGame());
        mainMenuButtonGameOver.onClick.AddListener(() => GameManager.Instance.GoToMainMenu());
        mainMenuButtonComplete.onClick.AddListener(() => GameManager.Instance.GoToMainMenu());

        
    }

    void OnDestroy()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnLivesChanged -= UpdateLives;
            GameManager.Instance.OnStateChanged -= HandleStateChanged;
        }
    }

    void UpdateLives(int currentLives)
    {
        for (int i = 0; i < lifeIcons.Length; i++)
        {
            lifeIcons[i].enabled = i < currentLives;
        }
    }

    void HandleStateChanged(GameManager.GameState state)
    {
        if (state == GameManager.GameState.GameOver)
            gameOverScreen.SetActive(true);

        if (state == GameManager.GameState.LevelComplete)
            levelCompleteScreen.SetActive(true);
    }
}