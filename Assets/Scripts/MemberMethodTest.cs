using UnityEngine;

public class MemberMethodTest : MonoBehaviour
{
    //멤버 변수 (저장소): 클래스 안, 메소드 밖
    private int myScore = 0;

    //메소드: 이 저장소(myScore)를 다루는 함수
    void AddScore(int points)
    {
        myScore += points;
    }

    void SubtractScore(int points)
    {
        myScore -= points;
    }

    private void Start()
    {
        Debug.Log("처음 점수: " + myScore); //0
        AddScore(50);
        Debug.Log("AddScore(50) 후: " + myScore); //50
        AddScore(30);
        Debug.Log("AddScore(30) 후: " + myScore); //80
        SubtractScore(20);
        Debug.Log("SubtractScore(20) 후: " + myScore); //60)
    }
}
