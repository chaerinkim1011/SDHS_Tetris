using UnityEngine;

public class ArrayTest : MonoBehaviour
{
    private void Start()
    {
        //1차원 배열
        int[] scores = new int[] { 100, 999, 300 };
        Debug.Log("1번째 점수: " + scores[0]);
        Debug.Log("2번째 점수: " + scores[1]);
        Debug.Log("3번째 점수: " + scores[2]);

        //2차원 배열 (3x3 표)
        int[,] board = new int[3, 3];
        board[0, 0] = 1;
        board[1, 1] = 2;
        board[2, 2] = 3;
        Debug.Log("board[1,1] =" + board[1, 1]);
    }
}
