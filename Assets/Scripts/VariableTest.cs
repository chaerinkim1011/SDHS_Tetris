using UnityEngine;

public class VariableTest : MonoBehaviour
{
    private void Start()
    {

        //변수 선언과 값 저장
        int score = 0;
        int level = 1;
        float speed = 1.5f;
        string playerName = "플레이어";

        //변수 값 출력
        Debug.Log("점수: " +  score);
        Debug.Log("레벨: " + level);
        Debug.Log("이름: " + playerName);
        Debug.Log("속도: " + speed);

        //변수 값 변경
        score = 100;
        level = 2;
        Debug.Log("변경 후 점수: " + score);
        Debug.Log("변경 후 레벨: " + level);
    }
}
