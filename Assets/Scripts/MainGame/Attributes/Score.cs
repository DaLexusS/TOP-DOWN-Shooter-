using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] public int score;
    [SerializeField] public int bestScore;
    [SerializeField] public float difficultyMultiplier = 1.0f;

    private string BestScoreKey = "BestScore";
    private int minimumForMultiplier = 300;
    private int scoreTrackerAdd = 300;

    public void AddScore(int amount)
    {
        score += amount;
        if (bestScore < score)
        {
            bestScore = score;
            if (PlayerPrefs.GetInt(BestScoreKey, 0) < bestScore)
            {
                PlayerPrefs.SetInt(BestScoreKey, bestScore);
                PlayerPrefs.Save();
            }
        }

        if (score >= minimumForMultiplier)
        {
            minimumForMultiplier += scoreTrackerAdd;
            UpdateDifficulty();
        }
    }

    public void ResetScore()
    {
        score = 0;
    }

    private void UpdateDifficulty()
    {
        difficultyMultiplier *= 1.15f;
    }
}
