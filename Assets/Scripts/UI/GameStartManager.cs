using UnityEngine;

public class GameStartMangaer : MonoBehaviour
{

    public GameObject startPanel;
    public GameObject levelPanel;
    void Start()
    {
        startPanel.SetActive(true);
        levelPanel.SetActive(false);
    }

    public void PlayGame()
    {
        startPanel.SetActive(false);
        levelPanel.SetActive(true);
    }

    public void Home()
    {
        startPanel.SetActive(true);
        levelPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
