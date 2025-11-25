using UnityEngine;
using TMPro;   // <-- use this instead of UnityEngine.UI

public class ScoreText : MonoBehaviour
{
    public TMP_Text scoreText; // TMP version for Score
    public static ScoreText instance;

    int score = 0;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        scoreText.text = score.ToString() + " pts ";

    }
    public void AddPoint()
    {
        score += 1;
        scoreText.text = score.ToString() + " pts ";
    }
}