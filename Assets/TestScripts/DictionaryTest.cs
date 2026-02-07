using UnityEngine;
using System.Collections.Generic;
public class DictionaryTest : MonoBehaviour
{
    private void Start()
    {
        Dictionary<string, int> scores = new Dictionary<string, int>();
        scores["철수"] = 100;
        scores["영희"] = 200;
        scores["민수"] = 150;
        scores["가나디"] = 300;        

        Debug.Log("철수 점수: " + scores["철수"]);
        Debug.Log("영희 점수: " + scores["영희"]);
      
        //키가 있는지 확인
        if (scores.ContainsKey("민수")) //ContainsKey 메서드 사용
        {
            Debug.Log("민수 점수: " + scores["민수"]);
            Debug.Log("가나디 점수: " + scores["가나디"]);
        }
    }
}
