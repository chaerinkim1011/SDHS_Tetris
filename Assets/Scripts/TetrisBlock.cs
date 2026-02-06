using UnityEngine;

public class TetrisBlock : MonoBehaviour
{
    //게임 보드 참조
    private GameBoard gameBoard;

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

}
