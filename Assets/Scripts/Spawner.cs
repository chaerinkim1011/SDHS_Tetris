using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject blockPrefab;
    public Transform spawnPoint;

    void Start()
    {
        SpawnNext();
    }

    public void SpawnNext()
    {
        if (blockPrefab == null) return;
        Vector3 pos = spawnPoint != null ? spawnPoint.position : new Vector3(5f, 18f, 0f);
        Instantiate(blockPrefab, pos, Quaternion.identity);
        Debug.Log($"블록 생성됨 (Spawner) — 위치: {pos}");
    }
}