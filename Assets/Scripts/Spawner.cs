using UnityEngine;

public class Spawner : MonoBehaviour  
{
    public GameObject[] tetrisBlockPrefabs; 
    public Transform spawnPoint;              

    private GameBoard gameBoard;      
    private GameController gameController;  
    void Start()
    { 
        gameBoard = FindAnyObjectByType<GameBoard>();  
        gameController = FindAnyObjectByType<GameController>();
        SpawnNext();  
    }

    public void SpawnNext()   
    {
        if (gameBoard.IsGameOver())   
        {
            Debug.Log("Game Over!");   
            gameController.GameOver();   
            Time.timeScale = 0;  
            return;
        }
        int randomIndex = Random.Range(0, tetrisBlockPrefabs.Length);  
        Instantiate(   
            tetrisBlockPrefabs[randomIndex],
            spawnPoint.position,   
            Quaternion.identity
        );
    }
}