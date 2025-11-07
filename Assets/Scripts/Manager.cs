using UnityEngine;
using UnityEngine.InputSystem;

public class Manager : MonoBehaviour
{
    public PlayerInputManager playerInputManager;
    public Transform spawnPointPlayer1;
    public Transform spawnPointPlayer2;

    void Start()
    {
        if (playerInputManager == null)
        {
            playerInputManager = FindObjectOfType<PlayerInputManager>();
        }
        
        Keyboard keyboardDevice = Keyboard.current;

        if (keyboardDevice == null)
        {
            Debug.LogError("No keyboard found. This method requires a keyboard.");
            return;
        }

        Debug.Log("Spawning Player 1 with 'keyboard' scheme (WASD");
        playerInputManager.JoinPlayer(0, -1, "Keyboard", keyboardDevice);

        Debug.Log("Spawning Player 2 with 'keyboard1' scheme (Arrow Keys");
        playerInputManager.JoinPlayer(1, -1, "Keyboard 1", keyboardDevice);
    }
    
    // Add this new public method:
    public void OnPlayerJoined(PlayerInput playerInput)
    {
        Debug.Log("PlayerInput joined: " + playerInput.playerIndex);

        // Check which player joined and move them
        if (playerInput.playerIndex == 0)
        {
            // This is Player 1
            if (spawnPointPlayer1 != null)
            {
                playerInput.gameObject.transform.position = spawnPointPlayer1.position;
                Debug.Log("Player 1 control scheme: " + playerInput.currentControlScheme);
            }
        }
        else if (playerInput.playerIndex == 1)
        {
            // This is Player 2
            if (spawnPointPlayer2 != null)
            {
                playerInput.gameObject.transform.position = spawnPointPlayer2.position;
                Debug.Log("Player 2 control scheme: " + playerInput.currentControlScheme);
            }
        }
    }
}
