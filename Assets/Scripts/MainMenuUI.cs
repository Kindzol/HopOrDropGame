using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenuUI : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainPanel;

    [Header("Buttons")]
    public Button startButton;
    public Button quitButton;

    [Header("Instructions")]
    public InstructionsUI instructionsUI;
    public Button helpButton;

    void Start()
    {
        startButton.onClick.AddListener(OnStartClicked);
        quitButton.onClick.AddListener(OnQuitClicked);
        helpButton.onClick.AddListener(() => instructionsUI.Show());
    }

    void OnStartClicked()
    {
        Debug.Log("Start clicked!");
        Debug.Log("GameManager: " + GameManager.Instance);

        if (GameManager.Instance != null)
            GameManager.Instance.StartGame();
    }

    void OnQuitClicked()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

}