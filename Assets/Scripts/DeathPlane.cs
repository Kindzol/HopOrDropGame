using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    private Vector3 spawnPoint = new Vector3(0f, 1f, 0f);

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance != null)
                GameManager.Instance.LoseLife();

            // Respawn kulki
            other.transform.position = spawnPoint;
            PlayerController pc = other.GetComponent<PlayerController>();
            if (pc != null)
                pc.ResetVelocity();
        }
    }
}