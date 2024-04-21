using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] public int score;
    [SerializeField] public int bestScore;

    public void AddScore(int amount)
    {
        score += amount;
        if (bestScore < score)
        {
            bestScore = score;
        }
    }

    public void ResetScore()
    {
        score = 0;
    }
}
