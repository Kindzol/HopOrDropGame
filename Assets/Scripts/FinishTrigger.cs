using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.isKinematic = true;
            }

            PlayerController pc = other.GetComponent<PlayerController>();
            if (pc != null)
                pc.enabled = false;

            if (AudioManager.Instance != null)
                AudioManager.Instance.PlayLevelComplete();

            if (GameManager.Instance != null)
                GameManager.Instance.TriggerLevelComplete();
        }
    }
}