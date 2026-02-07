using UnityEngine;

public class Spawner : MonoBehaviour   // [MonoBehaviour 상속]
{
    public GameObject blockPrefab;   // [우리 멤버] Inspector에서 프리팹 연결
    public Transform spawnPoint;      // [우리 멤버] 생성 위치 (Inspector에서 연결)

    void Start()   // [Unity가 호출] 상속받은 메소드 — 엔진이 한 번 호출
    {
        SpawnNext();   // [우리 메소드]
    }

    public void SpawnNext()   // [우리 메소드]
    {
        if (blockPrefab == null) return;   // blockPrefab: [우리 멤버]
        Vector3 pos = spawnPoint != null ? spawnPoint.position : new Vector3(5f, 18f, 0f);   // spawnPoint: [우리 멤버], position: [Unity 프로퍼티]
        Instantiate(blockPrefab, pos, Quaternion.identity);   // Instantiate: [Unity API]
        Debug.Log($"블록 생성됨 (Spawner) — 위치: {pos}");   // Debug.Log: [Unity API]
    }
}