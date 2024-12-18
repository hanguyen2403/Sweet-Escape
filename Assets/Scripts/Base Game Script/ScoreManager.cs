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
    private int numberStars;
    private GameData gameData;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        board = FindObjectOfType<Board>();
        gameData = FindObjectOfType<GameData>();
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
        for (int i = 0; i < board.scoreGoals.Length; i++)
        {
            if (score > board.scoreGoals[i] && numberStars < i + 1)
            {
                numberStars++;
            }
        }
        if (board != null && scoreBar != null) { 
            int length = board.scoreGoals.Length;
            scoreBar.fillAmount = (float)  score / (float) board.scoreGoals[length -1];
        }
        if (gameData != null)
        {

            if (score > gameData.saveData.highScores[board.level])
            {
                gameData.saveData.highScores[board.level] = score;
                gameData.saveData.stars[board.level] = numberStars;
            }
            gameData.Save();
        }
    }
}
