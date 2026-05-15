using UnityEngine;

public class PlayerAppearance : MonoBehaviour
{
    private Renderer ballRenderer;

    void Start()
    {
        ballRenderer = GetComponent<Renderer>();

        if (SkinManager.Instance != null)
        {
            Material mat = new Material(ballRenderer.material);
            mat.color = SkinManager.Instance.GetSelectedColor();
            ballRenderer.material = mat;
        }
    }
}