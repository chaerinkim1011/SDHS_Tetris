using UnityEngine;

public class DeltaTimeTest : MonoBehaviour
{
    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 2f)
        {
            Debug.Log("1초가 지났습니다! (deltaTime 누적)");
            timer = 0f;
        }
    }
}
