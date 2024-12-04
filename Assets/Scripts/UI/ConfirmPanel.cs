using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class ConfirmPanel : MonoBehaviour
{
    [Header ("Level Information")]
    public string levelToLoad;
    public int level;
    private GameData gameData;
    private int starsActive;
    private int highScore;
    [Header ("UI Stuff")]
    public Image[] stars;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI starText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        gameData = FindObjectOfType<GameData>();
        LoadData();
        ActiveStars();
        SetText();
    }

    void LoadData()
    {
        if (gameData != null)
        {
            starsActive = gameData.saveData.stars[level - 1];
            highScore = gameData.saveData.highScores[level - 1];
        }
    }

    void SetText()
    {
        highScoreText.text = "" + highScore;
        starText.text = "" + starsActive + "/3";
    }

    void ActiveStars()
    {
        for (int i = 0; i < starsActive; i++)
        {
            stars[i].enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void Cancel()
    {
        gameObject.SetActive(false);
    }
    public void Play()
    {
        PlayerPrefs.SetInt("Current Level", level - 1);
        SceneManager.LoadScene(levelToLoad);
    }
}
