using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Inspector editable values for movement tuning
    public float speed = 5.0f;
    public float turnSpeed = 100f;
    // Input System for binding input keys in Inspector
    public InputAction MoveAction;
    // Input value ( x = left/right, y = forward/back), privatized as only used internally
    private Vector2 moveInput;

    void Start()
    {
        // Enable MoveAction for reading player inputs
        MoveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        // Read the 2D vector from the MoveAction
        moveInput = MoveAction.ReadValue<Vector2>();
        // Move the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * moveInput.y);
        // Rotate around local Yaw using x component
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * moveInput.x);
    }
}
