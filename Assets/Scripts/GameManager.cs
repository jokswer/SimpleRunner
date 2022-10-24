using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject finishWindow;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private CoinManager coinManager;

    void Start()
    {
        levelText.SetText(SceneManager.GetActiveScene().name);
    }

    public void Play()
    {
        startMenu.SetActive(false);
        FindObjectOfType<PlayerBehavior>().Play();
    }

    public void ShowFinishWindow()
    {
        finishWindow.SetActive(true);
    }

    public void NextLevel()
    {
        var nextSceneBuildIndex = SceneManager.GetActiveScene().buildIndex + 1;
        
        if (nextSceneBuildIndex < SceneManager.sceneCountInBuildSettings)
        {
            coinManager.SaveToProgress();
            SceneManager.LoadScene(nextSceneBuildIndex);
        }
    }
}