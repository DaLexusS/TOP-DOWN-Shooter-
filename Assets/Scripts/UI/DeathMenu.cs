using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DeathMenu : MonoBehaviour
{
    [SerializeField] GameObject deathUi;
    [SerializeField] GameObject _player;
    private Score scoreCode;
    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI bestScoreText;

    void Start()
    {
        scoreCode = _player.GetComponent<Score>();
        scoreText = deathUi.transform.Find("Score").GetComponent<TextMeshProUGUI>();
        bestScoreText = deathUi.transform.Find("BestScore").GetComponent<TextMeshProUGUI>();
        deathUi.SetActive(false);
    }

    public void OnDeath()
    {
        if (scoreCode != null && scoreText != null)
        {
            scoreText.text = scoreCode.score.ToString();

            int bestScore = PlayerPrefs.GetInt("BestScore", 0);
            bestScoreText.text = bestScore.ToString();
        }
        else
        {
            Debug.LogWarning("Score component or score text is not set up properly.");
        }

        deathUi.SetActive(true);
    }

    public void PressedPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
