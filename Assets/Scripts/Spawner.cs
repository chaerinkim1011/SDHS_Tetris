using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject blockPrefab;       // Inspector에서 프리팹 연결 (예: I_Block)
    public Transform spawnPoint;         // 생성 위치 (빈 오브젝트로 둬도 됨)

    void Start()
    {
        SpawnNext();
    }

 
    // 생성 위치: spawnPoint가 있으면 그 위치, 없으면 (5, 18, 0) — 10x20 보드 기준 가로 중앙·상단
    public void SpawnNext()
    {
        if (blockPrefab == null) return;
        Vector3 pos = spawnPoint != null ? spawnPoint.position : new Vector3(5f, 18f, 0f);
        Instantiate(blockPrefab, pos, Quaternion.identity);
        Debug.Log($"블록 생성됨 (Spawner) — 위치: {pos}");
    }
}