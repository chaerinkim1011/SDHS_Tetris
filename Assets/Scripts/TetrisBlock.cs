using Unity.VisualScripting;
using UnityEngine;

public class TetrisBlock : MonoBehaviour
{
    //게임 보드 참조
    private GameBoard gameBoard;
    public float fallSpeed = 1f;
    private float fallTimer = 0f;

    private void Start()
    {
        //유니티에서 GameBoard 오브젝트 찾기
        gameBoard = FindFirstObjectByType<GameBoard>();

        //초기 위치 설정 (보드 중앙 상단)
        if (gameBoard != null)
        {
            //Spawner 위치에 따라 달라질 수 있지만, 여기서는 (5, 17)로 가정
            transform.position = new Vector3(5, 17, 0);
        }

        //자식 블록 개수 확인
        int childCount = transform.childCount;

        //첫 번째 자식 블록 가져오기
        Transform firstBlock = transform.GetChild(0);

        //모든 자식 블록 순회
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform block = transform.GetChild(i);
            //블록 위치: block.position 또는 block.localPosition
        }
    }

    private void Update()
    {
        //자동 낙하
        fallTimer += Time.deltaTime;
        if (fallTimer >= fallSpeed)
        {
            MoveDown();
            fallTimer = 0f;
        }
    }

    //이동 가능한지 확인하는 함수
    bool ValidMove(Vector3 offset)
    {

        //모든 자식 블록 확인
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);

            //이동 후 위치 계산
            Vector3 newPos = child.position + offset;

            //Unity 좌표를 정수로 반올림 (게임 보드 그리드에 맞추기 위함)
            int roundX = Mathf.RoundToInt(newPos.x);
            int roundY = Mathf.RoundToInt(newPos.y);

            //보드 범위  확인
            //왜 ||(또는)인가? "범위 밖" = "x가 너무 작거나 OR 너무 크거나 OR y가 너무 작거나 OR 너무 크다"
            // → 하나라도 해당되면 범위 밖이므로 || 사용 (범위 "안"이면 && 사용)
            if (roundX < 0 || roundX >= gameBoard.width ||
                roundY < 0 || roundY >= gameBoard.height)
            {
                return false; //범위 밖!!
            }

            //이미 블록이 있는지 확인
            //if (!gameBoard.IsCellEmpty(roundX, roundY))
            //return false; //이미 블록이 있음!!
        }
        return false; //이동 가능!!
    }

    public void MoveLeft()
    {
        if (ValidMove(Vector3.left)) //왼쪽으로 1칸
        {
            transform.position += Vector3.left;
        }
    }

    public void MoveRight()
    {
        if (ValidMove(Vector3.right)) //오른쪽으로 1칸
        {
            transform.position += Vector3.right;
        }
    }

    public void MoveDown()
    {
        if (ValidMove(Vector3.down)) // 아래로 1칸 
        {
            transform.position += Vector3.down;
        }
        else
        {
            //더 이상 내려갈 수 없으면 브록 고정 (6단계에서 구현)
            //LockPiece();
        }
    }

    public void Rotate()
    {
        //회전 후 위치들을 저장할 배열 (자식 개수만큼)
        Vector3[] newLocalPositions = new Vector3[transform.childCount];

        //각 자식 블록의 Local Position을 90도 회전
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            Vector3 localPos = child.localPosition;

            // 90도 시계 방향 회전 공식: (x, y) -> (y, -x)
            float newX = localPos.y;
            float newY = localPos.x;
            newLocalPositions[i] = new Vector3(newX, -newY, 0);
        }

        //회전 후 위치가 유효한지 확인
        bool canRotate = true;
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            Vector3 newWorldPos = transform.position + newLocalPositions[i];

            //Unity 좌표를 정수로 반올림
            int roundX = Mathf.RoundToInt(newWorldPos.x);
            int roundY = Mathf.RoundToInt(newWorldPos.y);

            //보드 범위 확인
            if (roundX < 0 || roundX >= gameBoard.width ||
                roundY < 0 || roundY >= gameBoard.height)
            {
                canRotate = false; //범위 밖
                break;
            }

           
        }

        //회전 가능하면 적용
        if (canRotate)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                child.localPosition = newLocalPositions[i];
            }
        }

    }
}

