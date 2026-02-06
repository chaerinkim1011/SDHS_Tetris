using UnityEngine;

public class MemberLocalTest : MonoBehaviour
{
    //멤버 변수: 클래스 안, 메소드 밖 -> 여러 메소드에서 사용 가능
    private int totalCount = 0;

    private void Start()
    {
        //로컬 변수: Start() 안에서만 존재
        int bonus = 5;
        Debug.Log("[Start] 로컬 bonus: " + bonus);
        Debug.Log("[Start] 멤버 totalCount: " + totalCount);

        totalCount += bonus; //멤버에 값 더함
        Debug.Log("[Start] totalCount 변경 후: " + totalCount);
    }

    private void Update()
    {
        //Update() 안에서는 bonus 를 쓸 수 없음 (로컬이라 Start()에만 있음)
        totalCount += 1;
        if (totalCount % 60 == 0)
        {
            Debug.Log("[Update] 멤버 totalCount: " + totalCount);
        }
    }
}
