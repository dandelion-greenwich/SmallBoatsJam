using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float playerRotationSpeed = 180f;

    private enum PlayerType { Player1, Player2 }
    [SerializeField] private PlayerType playerType;

    private Rigidbody rb;

    private float moveInput;
    private float rotateInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        Debug.Log($"Player: {playerType} Velocity: {rb.linearVelocity}");
        
        moveInput = 0f;
        rotateInput = 0f;
        
        switch (playerType)
        {
            case PlayerType.Player1:
                if (Input.GetKey(KeyCode.W)) moveInput = 1f;
                else if (Input.GetKey(KeyCode.S)) moveInput = -1f;

                if (Input.GetKey(KeyCode.A)) rotateInput = -1f;
                else if (Input.GetKey(KeyCode.D)) rotateInput = 1f;
                break;

            case PlayerType.Player2:
                if (Input.GetKey(KeyCode.UpArrow)) moveInput = 1f;
                else if (Input.GetKey(KeyCode.DownArrow)) moveInput = -1f;

                if (Input.GetKey(KeyCode.LeftArrow)) rotateInput = -1f;
                else if (Input.GetKey(KeyCode.RightArrow)) rotateInput = 1f;
                break;
        }
    }

    private void FixedUpdate()
    {
        Vector3 move = transform.forward * moveInput * playerSpeed;
        rb.MovePosition(rb.position + move * Time.fixedDeltaTime);
        
        Quaternion rotation = Quaternion.Euler(0f, rotateInput * playerRotationSpeed * Time.fixedDeltaTime, 0f);
        rb.MoveRotation(rb.rotation * rotation);
    }

    public String GetPlayerName()
    {
        return playerType.ToString();
    }

    public bool IsMoving()
    {
        if (moveInput == 0f && rotateInput == 0f) return false;
        return true;
    }
}
