using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    int score = 0;
    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }
}
