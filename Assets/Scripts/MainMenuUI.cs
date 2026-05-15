using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenuUI : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainPanel;

    [Header("Buttons")]
    public Button startButton;

    void Start()
    {
        startButton.onClick.AddListener(OnStartClicked);
    }

    void OnStartClicked()
    {
        Debug.Log("Start clicked!");
        Debug.Log("GameManager: " + GameManager.Instance);

        if (GameManager.Instance != null)
            GameManager.Instance.StartGame();
    }
}