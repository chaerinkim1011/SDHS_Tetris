using UnityEngine;

public class VectorTest : MonoBehaviour
{
    
    void Start()
    {
        //Vector2Int (정수 좌표)
        Vector2Int gridPos = new Vector2Int(5, 10);
        Debug.Log("그리드 위치: " + gridPos);

        //Vector3 (Unity 위치)
        transform.position = new Vector3(gridPos.x, gridPos.y, 0);

        //방향 벡터
        Debug.Log("오른쪽: " + Vector3.right);
        Debug.Log("아래: " + Vector3.down);

        //한 칸 이동
        transform.position += Vector3.right;
        Debug.Log("이동 후 위치: " +  transform.position);

        transform.position += Vector3.down;
    }

}
