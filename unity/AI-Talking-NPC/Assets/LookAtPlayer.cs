using UnityEngine;

// Makes NPC rotate toward player
public class LookAtPlayer : MonoBehaviour
{
    // Reference to player
    public Transform player;

    void Update()
    {
        // Direction toward player
        Vector3 direction =
            player.position - transform.position;

        // Prevent weird vertical rotation
        direction.y = 0;

        // Rotate toward player
        transform.rotation =
            Quaternion.LookRotation(direction);
    }
}