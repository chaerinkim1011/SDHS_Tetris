using UnityEngine;
using UnityEngine.UI;
using TMPro; //TMP 붙이기 위해

public class GameController : MonoBehaviour
{
    public int score = 0;
    public int lines = 0;
    public int level = 1;

    public TMP_Text scoreText;
    public TMP_Text linesText;
    public TMP_Text levelText;

    private void Start()
    {
        UpdateUI();
    }

    public void AddScore(int linesCleared)
    {
        int points = 0;
        switch (linesCleared)
        {
            case 1: points = 100; break;
            case 2: points = 300; break;
            case 3: points = 500; break;
            case 4: points = 800; break;
        }
        score += points * level;
        lines += linesCleared;
        level = (lines / 10) + 1;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (scoreText)
        {
            scoreText.text = $"Score {score}";
        }
        if (linesText)
        {
            linesText.text = $"Lines {lines}";
        }
        if (levelText)
        {
            levelText.text = $"Level {level}";
        }
    }
}
