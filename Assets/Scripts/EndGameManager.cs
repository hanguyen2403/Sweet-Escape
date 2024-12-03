using TMPro;
using UnityEngine;

public enum GameType
{
    Moves, 
    Time
}

[System.Serializable]
public class EndGameRequirements
{
    public GameType gameType;
    public int counterValue;
}
public class EndGameManager : MonoBehaviour
{
    public GameObject movesLabel;
    public GameObject timeLabel;
    public GameObject youWinPanel;
    public GameObject tryAgainPanel;
    public TextMeshProUGUI counter;
    public EndGameRequirements requirements;
    public int currentCounterValue;
    private Board board;
    private float timerSeconds;

    void Start()
    {
        board = FindObjectOfType<Board>();
        SetupGame();
    }

    // Update is called once per frame
    void SetupGame()
    {

        currentCounterValue = requirements.counterValue;
        if(requirements.gameType == GameType.Moves)
        {
            movesLabel.SetActive(true);
            timeLabel.SetActive(false);
        }
        else
        {
            timerSeconds = 1;
            movesLabel.SetActive(false);
            timeLabel.SetActive(true);
        }
        counter.text = "" + currentCounterValue;
    }

    public void DecreaseCounterValue()
    {
        if (board.currentState != GameState.pause)
        {
            currentCounterValue--;
            counter.text = "" + currentCounterValue;
            if (currentCounterValue <= 0)
            {
                LoseGame();
            }
        }
    }

    public void WinGame()
    {
        youWinPanel.SetActive(true);
        board.currentState = GameState.win;
        currentCounterValue = 0;
        counter.text = "" + currentCounterValue;
        FadePanelController fade = FindObjectOfType<FadePanelController>();
        fade.GameOver();
    }

    public void LoseGame()
    {
        tryAgainPanel.SetActive(true);
        board.currentState = GameState.lose;
        Debug.Log("You Lose!");
        currentCounterValue = 0;
        counter.text = "" + currentCounterValue;
        FadePanelController fade = FindObjectOfType<FadePanelController>();
        fade.GameOver();
    }


    private void Update()
    {
        if (requirements.gameType == GameType.Time && currentCounterValue > 0) 
        {
            timerSeconds -= Time.deltaTime;
            if (timerSeconds <= 0)
            {
                DecreaseCounterValue();
                timerSeconds = 1;
            }
        }
    }
}
