using UnityEngine;

public class InstantiateTest : MonoBehaviour
{
    public GameObject cubePrefab; //Insperctorø°º≠ «¡∏Æ∆’ ø¨∞·
    public GameObject spawnedCube;

    private void Start()
    {
        if (cubePrefab != null)
        {
            spawnedCube = Instantiate(cubePrefab);
            spawnedCube.transform.position = new Vector3(2, 0, 0);
            Debug.Log("Cube ª˝º∫µ  (Instantiate)");
        }
    }

    private void Update()
    {
        if (spawnedCube != null && Time.time > 3f)
        {
            Destroy(spawnedCube);
            Debug.Log("Cube ªË¡¶µ  (Destroy)");
            spawnedCube = null;
        }
    }
}
