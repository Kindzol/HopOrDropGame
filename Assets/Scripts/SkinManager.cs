using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public static SkinManager Instance { get; private set; }

    // Kolory do wyboru
    public Color[] availableColors = new Color[]
    {
        Color.white,
        Color.red,
        Color.blue,
        Color.green,
        new Color(1f, 0.5f, 0f),   // pomarańczowy
        new Color(0.5f, 0f, 1f),   // fioletowy
    };

    public int selectedColorIndex = 0;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public Color GetSelectedColor()
    {
        return availableColors[selectedColorIndex];
    }

    public void SelectColor(int index)
    {
        if (index >= 0 && index < availableColors.Length)
            selectedColorIndex = index;
    }
}