using UnityEngine;

public class FinderTest : MonoBehaviour
{
    private void Start()
    {
        TargetObject target = FindAnyObjectByType<TargetObject>();
        if (target != null )
        {
            Debug.Log("TargetObject를 찾았습니다! value = " + target.value);
        }
        else
        {
            Debug.Log("TargetObject를 찾지 못했습니다 ㅜㅜ 씬에 TargetObject를 가진 오브젝트를 추가하세요");
        }
    }
}
