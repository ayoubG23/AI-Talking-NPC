using UnityEngine;
using UnityEngine.InputSystem;

// Controls first-person movement
public class PlayerMovement : MonoBehaviour
{
    // Movement speed
    public float speed = 5f;

    void Update()
    {
        Vector3 move = Vector3.zero;

        // Forward
        if (Keyboard.current.wKey.isPressed)
        {
            move += transform.forward;
        }

        // Backward
        if (Keyboard.current.sKey.isPressed)
        {
            move -= transform.forward;
        }

        // Left
        if (Keyboard.current.aKey.isPressed)
        {
            move -= transform.right;
        }

        // Right
        if (Keyboard.current.dKey.isPressed)
        {
            move += transform.right;
        }

        // Apply movement
        transform.position += move * speed * Time.deltaTime;
    }
}