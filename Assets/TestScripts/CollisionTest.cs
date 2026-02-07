using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    //간단한 보드: 0에서 4 위치, occupied[i]가 true면 그 칸에 블록 있음
    private bool[] occupied = new bool[5];

    private void Start()
    {
        occupied[2] = true; //2번 칸에는 이미 블록이 있다고 가정

        Debug.Log("1번 칸으로 이동 가능? " + CanMoveTo(1));
        Debug.Log("2번 칸으로 이동 가능? " + CanMoveTo(2));
        Debug.Log("3번 칸으로 이동 가능? " + CanMoveTo(5));
    }

    bool CanMoveTo(int position)
    {
        //범위 확인
        if (position < 0 || position >= 5)
            return false;

        //이미 볼록이 있으면 이동 불가
        if (occupied[position])
            return false;

        return true;
    }
}
