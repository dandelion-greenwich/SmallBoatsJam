using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] private float playerSpeed;
    [SerializeField] private float playerRotationSpeed;
    private CharacterController controller;
    
    [Header("Input Actions")]
    public InputActionReference moveAction;
    public InputActionReference rotateAction;

    private void Awake()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        moveAction.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
    }

    void Update()
    {
        float moveInput = moveAction.action.ReadValue<float>();
        Vector3 move = transform.forward * moveInput;
        controller.Move(move * playerSpeed * Time.deltaTime);
        
        float rotateInput = rotateAction.action.ReadValue<float>();
        // Apparently cc doesn't handle rotation so I change it with transform  
        transform.Rotate(Vector3.up * rotateInput * playerRotationSpeed * Time.deltaTime);
    }
}
