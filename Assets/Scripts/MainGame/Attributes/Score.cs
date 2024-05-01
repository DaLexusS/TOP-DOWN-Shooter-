using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] public int score;
    [SerializeField] public int bestScore;

    private string BestScoreKey = "BestScore";

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
    }

    public void ResetScore()
    {
        score = 0;
    }
}
