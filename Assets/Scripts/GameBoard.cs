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

    public bool IsCellEmpty(int x, int y)
    {
        if (x < 0 || x >= width || y < 0 || y >= height)
            return false;
        return grid[x, y] == null;
    }

    public void AddToGrid(TetrisBlock block)
    {
        Vector3 parentPos = block.transform.position;
        for (int i = block.transform.childCount - 1; i >= 0; i--)   // 반드시 역순
        {
            Transform child = block.transform.GetChild(i);
            Vector3 childWorld = parentPos + block.transform.TransformDirection(child.localPosition);
            Vector3Int cell = Vector3Int.RoundToInt(childWorld);
            if (cell.x >= 0 && cell.x < width && cell.y >= 0 && cell.y < height)
            {
                child.SetParent(transform);
                grid[cell.x, cell.y] = child;
                child.position = new Vector3(cell.x, cell.y, 0f);
            }
        }
    }

    bool IsRowFull(int row)
    {
        for (int x = 0; x < width; x++)
        {
            if (grid[x, row] == null)
                return false;
        }
        return true;
    }

    void ClearRow(int row)
    {
        for (int x = 0; x < width; x++)
        {
            if (grid[x, row] != null)
            {
                Destroy(grid[x, row].gameObject);
                grid[x, row] = null;
            }
        }
    }

    void MoveRowsDown(int clearedRow)
    {
        for (int y = clearedRow + 1; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (grid[x, y] != null)
                {
                    grid[x, y - 1] = grid[x, y];
                    grid[x, y] = null;
                    grid[x, y - 1].position = new Vector3(x, y - 1, 0f);
                }
            }
        }
    }

    public int ClearFullRows()
    {
        int linesCleared = 0;
        for (int y = 0; y < height; y++)
        {
            if (IsRowFull(y))
            {
                ClearRow(y);
                MoveRowsDown(y);
                y--;
                linesCleared++;
            }
        }
        return linesCleared;
    }

}
