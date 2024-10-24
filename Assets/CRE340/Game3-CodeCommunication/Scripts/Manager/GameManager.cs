using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null )
                {
                    GameObject singletonObject = new GameObject();
                    instance = singletonObject.AddComponent<GameManager>();
                    singletonObject.name = typeof(GameManager).ToString() + " (singleton)";
                }
            }
            return instance;
        }
    }

    public GameObject playerPrefab;
    private Player playerInstance;

    [SerializeField] private string playerName = "Player1";
    [SerializeField] private int playerHealth = 100;
    [SerializeField] private int score = 0;

    public string PlayerName
    {
        get { return playerName; }
        private set
        {
             playerName = value; 
        }   
    }

    public int PlayerHealth
    {
        get { return playerHealth; }
        private set
        {
            playerHealth = value;
        }
    }

    public int Score
    {
        get { return score; }
        private set
        {
            score = value;
        }
    }
     
    private void Start()
    {
        Debug.Log("GameManager initialized with default player state.");
    }

    public void SpawnPlayer(Vector3 spawnPosition)
    {
        if (playerInstance == null)
        {
            GameObject playerObject = Instantiate(playerPrefab, spawnPosition, Quaternion.identity);
            playerInstance = playerObject.GetComponent<Player>();   
            SetPlayerName(playerInstance.name);
        }
    }

    public void SetPlayerName(string name)
    {
        PlayerName = name;
    }

    public void SetPlayerHealth(int health)
    {
        playerHealth = Mathf.Clamp(health, 0, 100);
        if (PlayerHealth <= 0)
        {
            Invoke("RestartLevel", 5F);
        }
    }

    public void AddScore(int points)
    {
        Score += points;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
