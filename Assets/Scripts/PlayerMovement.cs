using UnityEngine;
using UnityEngine.InputSystem;

// Polling: read input manually in Update() without events
// Reads the input every frame (60+ times per second)
// Less efficient, but more direct
// Ideal for continuous movement
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    
    private PlayerInput _playerInput;
    private InputAction _moveAction;
    
    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _moveAction = _playerInput.actions["Move"];
    }
    
    void Update()
    {
        var input = _moveAction.ReadValue<Vector2>();
        var movement = new Vector3(input.x, 0f, input.y);
        
        transform.position += movement * moveSpeed * Time.deltaTime;
    }
}

// Send Messages
// Executes only when the input CHANGES
// More efficient (does not read every frame)
// Ideal for discrete actions: jump, shoot, interactions
// public class PlayerMovement : MonoBehaviour
// {
//     [SerializeField] private float moveSpeed = 5f;
//     private Vector2 moveInput;
//     
//     void Update()
//     {
//         Vector3 movement = new Vector3(moveInput.x, 0f, moveInput.y);
//         transform.position += movement * moveSpeed * Time.deltaTime;
//     }
//     
//     // The name must match "On" + the Action name
//     void OnMove(InputValue value)
//     {
//         moveInput = value.Get<Vector2>();
//     }
// }

// Send Messages - event driven
// public class PlayerMovement : MonoBehaviour
// {
//     private Vector2 moveInput;
//
//     void OnMove(InputValue value)
//     {
//         moveInput = value.Get<Vector2>();
//         Debug.Log("¡Input detected!"); // Called only when the input changes
//     }
//
//     void Update()
//     {
//         // Use the last value stored
//         transform.position += new Vector3(moveInput.x, 0, moveInput.y) * speed * Time.deltaTime;
//     }
// }

// Broadcast messages
// With Broadcast Messages: all 3 scripts receive OnMove() automatically,
// even WeaponController, which is on a child object.
// Advantage: You don’t need references or extra code to communicate between scripts.
// public class PlayerMovement : MonoBehaviour
// {
//     private Vector2 moveInput;
//     
//     void OnMove(InputValue value)
//     {
//         moveInput = value.Get<Vector2>();
//         // Move the player
//     }
// }
//
// // In Player GameObject
// public class PlayerAnimator : MonoBehaviour
// {
//     private Animator animator;
//     
//     void OnMove(InputValue value)
//     {
//         Vector2 input = value.Get<Vector2>();
//         animator.SetFloat("Speed", input.magnitude); // Update animation
//     }
// }
//
// // In WeaponHolder (Child GameObject)
// public class WeaponController : MonoBehaviour
// {
//     void OnMove(InputValue value)
//     {
//         Vector2 input = value.Get<Vector2>();
//         if (input.magnitude > 0)
//         {
//             // Cancel reload if the player moves
//             StopReloading();
//         }
//     }
//
//     private void StopReloading() { }
// }

// Unity events
// public class PlayerMovement : MonoBehaviour
// {
//     [SerializeField] private float moveSpeed = 5f;
//     private Vector2 moveInput;
//     
//     void Update()
//     {
//         Vector3 movement = new Vector3(moveInput.x, 0f, moveInput.y);
//         transform.position += movement * moveSpeed * Time.deltaTime;
//     }
//     
//     // Public method called from the inspector
//     public void OnMove(UnityEngine.InputSystem.InputAction.CallbackContext context)
//     {
//         moveInput = context.ReadValue<Vector2>();
//     }
// }

//Invoke C# events
// public class PlayerMovement : MonoBehaviour
// {
//     [SerializeField] private float moveSpeed = 5f;
//     private Vector2 moveInput;
//     private PlayerInput playerInput;
//     
//     void Awake()
//     {
//         playerInput = GetComponent<PlayerInput>();
//     }
//
//     private void OnEnable()
//     {
//         // Subscribe to events
//         playerInput.actions["Move"].performed += OnPlayerMoveFromCSharp;
//         playerInput.actions["Move"].canceled += OnPlayerMoveFromCSharp;
//     }
//
//     private void OnDisable()
//     {
//         // IMPORTANT: Unsubscribe to avoid memory leaks and error warnings
//         playerInput.actions["Move"].performed -= OnPlayerMoveFromCSharp;
//         playerInput.actions["Move"].canceled -= OnPlayerMoveFromCSharp;
//     }
//
//     void Update()
//     {
//         Vector3 movement = new Vector3(moveInput.x, 0f, moveInput.y);
//         transform.position += movement * moveSpeed * Time.deltaTime;
//     }
//     
//     void OnPlayerMoveFromCSharp(InputAction.CallbackContext context)
//     {
//         moveInput = context.ReadValue<Vector2>();
//     }
// }