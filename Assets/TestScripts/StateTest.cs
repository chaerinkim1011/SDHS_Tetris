using UnityEngine;

public class StateTest : MonoBehaviour
{
    private int score = 0;
    private int level = 0;
    private bool isGameover = false;

    private void Start()
    {
        Debug.Log("초기 상태 - 점수: " +score + ", 레벨: " + level);

        //행 1줄 제거 시뮬레이션
        score += 100 * level;
        Debug.Log("1줄 제거 후 - 점수: " + score);

        //10줄 제거했다고 가정 -> 레벨 업
        level = 2;
        score += 300 * level; //2줄 제거
        Debug.Log("레벨 업 후 - 점수: " + score + ", 레벨: " + level);

        if (score >= 1000)
        {
            Debug.Log("1000점 달성!");
        }
    }

}
