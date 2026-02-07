using UnityEngine;

public class InputHandler : MonoBehaviour   // [MonoBehaviour 상속]
{
    private float moveCooldown = 0.1f;   // [우리 멤버]
    private float moveTimer = 0f;         // [우리 멤버]

    void Update()   // [Unity가 호출] 상속받은 메소드 — 매 프레임 엔진이 호출
    {
        moveTimer += Time.deltaTime;   // Time.deltaTime: [Unity 프로퍼티]

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))   // Input.GetKey, KeyCode: [Unity API]
        {
            if (moveTimer >= moveCooldown) { MoveLeft(); moveTimer = 0f; }   // MoveLeft: [우리 메소드]
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if (moveTimer >= moveCooldown) { MoveRight(); moveTimer = 0f; }   // MoveRight: [우리 메소드]
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            TetrisBlock current = FindAnyObjectByType<TetrisBlock>();   // [Unity API]
            if (current != null && moveTimer >= moveCooldown)
            {
                current.MoveDown();   // MoveDown: [우리 메소드] TetrisBlock 쪽
                moveTimer = 0f;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))   // [Unity API]
        {
            Rotate();   // [우리 메소드]
        }
    }

    void MoveLeft()   // [우리 메소드]
    {
        TetrisBlock current = FindAnyObjectByType<TetrisBlock>();   // [Unity API]
        if (current != null)
        {
            current.MoveLeft();   // MoveLeft: [우리 메소드] TetrisBlock 쪽
        }
    }
    void MoveRight()   // [우리 메소드]
    {
        TetrisBlock current = FindAnyObjectByType<TetrisBlock>();
        if (current != null)
        {
            current.MoveRight();
        }
    }
    void Rotate()   // [우리 메소드]
    {
        TetrisBlock current = FindAnyObjectByType<TetrisBlock>();
        if (current != null)
        {
            current.Rotate();   // Rotate: [우리 메소드] TetrisBlock 쪽
        }
    }
}