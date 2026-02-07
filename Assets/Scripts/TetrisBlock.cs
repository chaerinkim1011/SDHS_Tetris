using UnityEngine;

public class TetrisBlock : MonoBehaviour   // [MonoBehaviour 상속]
{
    // ----- [우리 멤버] -----
    private GameBoard gameBoard;   // 게임 보드 참조 (Start에서 찾음)
    public float fallSpeed = 1f;  // 낙하 속도: 몇 초에 한 칸
    private float fallTimer = 0f; // 낙하 타이머 (Update에서 누적)

    void Start()   // [Unity가 호출] 씬에 올라온 뒤 한 번
    {
        gameBoard = FindAnyObjectByType<GameBoard>();   // [Unity API] 씬에서 GameBoard 찾기
    }

    // [우리 메소드] offset 방향으로 한 칸 갔을 때 보드 범위 안인지 (부모 예정 위치 기준)
    bool ValidMove(Vector3 offset)
    {
        Vector3 parentNew = transform.position + offset;
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            Vector3 childWorld = parentNew + transform.TransformDirection(child.localPosition);
            Vector3Int cell = Vector3Int.RoundToInt(childWorld);
            if (cell.x < 0 || cell.x >= gameBoard.width || cell.y < 0 || cell.y >= gameBoard.height)
                return false;
            if (!gameBoard.IsCellEmpty(cell.x, cell.y))   // ← 6단계 추가
                return false;
        }
        return true;
    }

    public void MoveLeft()   // [우리 메소드] 5단계 InputHandler가 호출
    {
        if (ValidMove(Vector3.left))
        {
            transform.position += Vector3.left;   // [Unity 프로퍼티]
        }
    }
    public void MoveRight()
    {
        if (ValidMove(Vector3.right))
        {
            transform.position += Vector3.right;
        }
    }
    public void MoveDown()
    {
        if (ValidMove(Vector3.down))
        {
            transform.position += Vector3.down;
        }
        else
        {
            LockPiece();
        }
    }

    public void Rotate()   // 90도 시계 방향 (부모만 돌림, 자식은 따라 감)
    {
        transform.Rotate(0f, 0f, -90f);
        if (!ValidMove(Vector3.zero))
        {
            transform.Rotate(0f, 0f, 90f);
        }
    }

    void Update()   
    {
        // GameController에서 현재 레벨 가져오기
        GameController gameController = FindAnyObjectByType<GameController>();
        if (gameController != null)
        {
            // 레벨이 높을수록 낙하 속도 빠름
            float currentFallSpeed = fallSpeed / gameController.level;
            fallTimer += Time.deltaTime;
            if (fallTimer >= currentFallSpeed)
            {
                MoveDown();
                fallTimer = 0f;
            }
        }
        else
        {
            // GameController가 없으면 기본 속도 사용
            fallTimer += Time.deltaTime;
            if (fallTimer >= fallSpeed)
            {
                MoveDown();
                fallTimer = 0f;
            }
        }
    }

    public void LockPiece()
    {
        if (gameBoard != null)
        {
            gameBoard.AddToGrid(this);
            int linesCleared = gameBoard.ClearFullRows();   // 반환값 받기

            GameController gameController = FindAnyObjectByType<GameController>();
            if (gameController != null)
            {
                gameController.AddScore(linesCleared);
            }

            Spawner spawner = FindAnyObjectByType<Spawner>();
            if (spawner != null)
            {
                spawner.SpawnNext();
            }
        }
        Destroy(gameObject);
    }
}