using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private float moveCooldown = 0.1f;   
    private float moveTimer = 0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TetrisBlock current = FindAnyObjectByType<TetrisBlock>();
            if (current != null)
                current.HardDrop();
        }

        moveTimer += Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if (moveTimer >= moveCooldown) { MoveLeft(); moveTimer = 0f; }
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if (moveTimer >= moveCooldown) { MoveRight(); moveTimer = 0f; }
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            TetrisBlock current = FindAnyObjectByType<TetrisBlock>();
            if (current != null && moveTimer >= moveCooldown) { current.MoveDown(); moveTimer = 0f; }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            Rotate();
        }
    }

    void MoveLeft()  
    {
        TetrisBlock current = FindAnyObjectByType<TetrisBlock>();   
        if (current != null)
        {
            current.MoveLeft();   
        }
    }
    void MoveRight()   
    {
        TetrisBlock current = FindAnyObjectByType<TetrisBlock>();
        if (current != null)
        {
            current.MoveRight();
        }
    }
    void Rotate()   
    {
        TetrisBlock current = FindAnyObjectByType<TetrisBlock>();
        if (current != null)
        {
            current.Rotate();  
        }
    }
}