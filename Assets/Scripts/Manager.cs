using UnityEngine;
using UnityEngine.InputSystem;

public class Manager : MonoBehaviour
{

    public Transform spawnPointPlayer1;
    public Transform spawnPointPlayer2;
    
    public static Manager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {

    }

    public void EndGame(string winningPlayer)
    {
        Debug.Log("Game Over");
        Debug.Log($"Winning player: {winningPlayer}");
        Time.timeScale = 0;
    }
    

}
