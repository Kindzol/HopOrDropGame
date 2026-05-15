using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (AudioManager.Instance != null)
                AudioManager.Instance.PlayLevelComplete();

            if (GameManager.Instance != null)
                GameManager.Instance.TriggerLevelComplete();
        }
    }
}