using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Manager : MonoBehaviour
{

    [SerializeField] private Transform spawnPointPlayer1;
    [SerializeField] private Transform spawnPointPlayer2;
    [SerializeField] private TextMeshProUGUI textMesh;
    
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
        if (textMesh != null)
        {
            textMesh.text = winningPlayer+ " has won!";
        }
    }
    

}
