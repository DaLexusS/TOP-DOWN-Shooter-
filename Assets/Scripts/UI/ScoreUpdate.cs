
using TMPro;
using UnityEngine;


public class ScoreUpdate : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] TMP_Text scoreText;

    private string text = "Score - ";

    private void Update()
    {
        scoreText.text = text + player.GetComponent<Score>().score;
    }
}
