using UnityEngine;
using UnityEngine.SceneManagement;
public class BackToSplash : MonoBehaviour
{
    public string sceneToLoad;
    private GameData gameData;
    private Board board;
    public void WinOk()
    {
        if (gameData != null)
        {
            gameData.saveData.isActive[board.level + 1] = true; //tới round tiếp theo
            gameData.Save();
        }
        SceneManager.LoadScene(sceneToLoad);
    }
    public void loseOk()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameData = FindObjectOfType<GameData>();
        board = FindObjectOfType<Board>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
