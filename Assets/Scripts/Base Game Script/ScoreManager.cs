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
        if (board != null && scoreBar != null) { 
            int length = board.scoreGoals.Length;
            scoreBar.fillAmount = (float)  score / (float) board.scoreGoals[length -1];
        }
        if (gameData != null)
        {

            if (score > gameData.saveData.highScores[board.level])
            {
                gameData.saveData.highScores[board.level] = score;
            }
            if (score > board.scoreGoals[0])
            {
                gameData.saveData.stars[board.level] = 1;
            }
            if (score > board.scoreGoals[1])
            {
                gameData.saveData.stars[board.level] = 2;
            }
            if (score > board.scoreGoals[2])
            {
                gameData.saveData.stars[board.level] = 3;
            }
            gameData.Save();
        }
    }
}
