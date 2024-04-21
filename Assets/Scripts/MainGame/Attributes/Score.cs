using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] public int score;

    public void AddScore(int amount)
    {
        score += amount;
    }
}
