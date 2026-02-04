using UnityEngine;

public class GameBoard : MonoBehaviour
{
   public int width = 10; //가로 10칸
    public int height = 20; //세로 20칸

    private Transform[,] grid;

    private void Awake()
    {
        grid = new Transform[width, height];
        Debug.Log($"게임 보드 생성: {width}x{height}");
    }

    public bool IsValidPosition(Vector2Int position)
    {
        return position.x >= 0 && position.x < width &&
                position.y >= 0 && position.y < height;
    }
}
