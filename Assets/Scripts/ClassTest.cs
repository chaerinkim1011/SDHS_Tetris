using UnityEngine;

public class ClassTest : MonoBehaviour
{
    private void Start()
    {
        //Player 객체 생성
        Player p = new Player();
        p.name = "가나디";
        p.score = 0;
        p.level = 1;

        Debug.Log(p.name + "의 점수: " + p.score);
        p.AddScore(100);
        Debug.Log("점수 추가 후: " + p.score);
        Debug.Log(p.name + "의 레벨: " + p.level);
        p.LevelUp();
        Debug.Log("레벨 업 후: " + p.level);
    }
}

//별도 클래스 정의
public class  Player
{
    public string name;
    public int score;
    public int level;

    public void LevelUp()
    {
        level++;
    }
    public void AddScore(int points)
    {
        score += points;
    }
}
