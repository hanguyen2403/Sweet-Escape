using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;
public class ScoreManager : MonoBehaviour
{
    private Board board;
    public TextMeshProUGUI scoreText;
    public int score;
    public UnityEngine.UI.Image scoreBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        board = FindObjectOfType<Board>();
        scoreBar = GameObject.Find("ScoreBar").GetComponent<UnityEngine.UI.Image>();
        scoreBar.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
    }

    public void IncreaseScore( int amountToIncrease)
    {
        score += amountToIncrease;
        if (board != null && scoreBar != null) { 
            int length = board.scoreGoals.Length;
            scoreBar.fillAmount = (float)  score / (float) board.scoreGoals[length -1];
        }
    }
}
