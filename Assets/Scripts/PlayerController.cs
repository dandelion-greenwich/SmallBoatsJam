using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] private float playerSpeed;
    [SerializeField] private float playerRotationSpeed;
    private enum PlayerType {Player1, Player2};
    [SerializeField] private PlayerType playerType; 
    
    private CharacterController controller;
    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction rotateAction;
    
    private float moveInput;
    private float rotateInput;
    

    private void Awake()
    {
        controller = gameObject.GetComponent<CharacterController>();
        playerInput = gameObject.GetComponent<PlayerInput>();
    }

    private void Start()
    {
        moveAction = playerInput.actions["Movement"];
        rotateAction = playerInput.actions["Rotate"];
    }

    private void Update()
    {
        moveInput = 0;
        rotateInput = 0;
        switch (playerType)
        {
            case PlayerType.Player1:
                if (Input.GetKey(KeyCode.W))
                    moveInput = 1f;
                else if (Input.GetKey(KeyCode.S))
                    moveInput = -1f;
                if (Input.GetKey(KeyCode.A))
                    rotateInput = -1f;
                else if (Input.GetKey(KeyCode.D))
                    rotateInput = 1f;
                break;
            
            case PlayerType.Player2:
                if (Input.GetKey(KeyCode.UpArrow))
                    moveInput = 1f;
                else if (Input.GetKey(KeyCode.DownArrow))
                    moveInput = -1f;
                if (Input.GetKey(KeyCode.LeftArrow))
                    rotateInput = -1f;
                else if (Input.GetKey(KeyCode.RightArrow))
                    rotateInput = 1f;
                break;
        }
        
        Debug.Log($"Move: {moveInput}, Rotate: {rotateInput}");
        
        Vector3 move = transform.forward * moveInput;
        controller.Move(move * playerSpeed * Time.deltaTime);

        // Apply rotation
        transform.Rotate(Vector3.up * rotateInput * playerRotationSpeed * Time.deltaTime);
    }
}
