using UnityEngine;
using UnityEngine.InputSystem;

public class CubeController : MonoBehaviour 
{
    public float speed = 5.0f;

    private void Update()
    {
        // Check if keyboard exists
        if (Keyboard.current.dKey.isPressed) 
        {
            transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
        }
        
        
    }
}
