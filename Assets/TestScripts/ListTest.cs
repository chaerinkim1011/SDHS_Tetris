using UnityEngine;
using System.Collections.Generic;
//using System.Collections.Generic 네임스페이스를 포함해야 List 사용 가능

public class ListTest : MonoBehaviour
{
    private void Start()
    {
        List<int> scores = new List<int>();
        scores.Add(100);
        scores.Add(200);
        scores.Add(300);
        scores.Add(400);

        Debug.Log("개수: " + scores.Count);
        //Count 속성으로 리스트의 개수 확인
        Debug.Log("첫 번째: "+ scores[0]);

        foreach (int s in scores) //리스트의 각 요소를 s에 할당
        {
            Debug.Log("점수: " + s);
        }
    }
}
