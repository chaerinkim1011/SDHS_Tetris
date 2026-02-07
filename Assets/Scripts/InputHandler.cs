using UnityEngine;
using UnityEngine.UIElements;

public class InputHandler : MonoBehaviour
{
    private float moveCooldown = 0.1f;
    private float moveTimer = 0f;

    private void Update()
    {
        moveTimer += Time.deltaTime;

        //좌우 이동
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if (moveTimer >= moveCooldown)
            {
                MoveLeft();
                moveTimer = 0f;
            }
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if (moveTimer >= moveCooldown)
            {
                MoveRight();
                moveTimer = 0f;
            }
        }

        //회전
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
