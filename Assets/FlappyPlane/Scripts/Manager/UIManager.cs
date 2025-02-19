using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;
    public Button exitButton;
    public GameObject startSet;
    public TextMeshProUGUI bestScoreText;

    public GameObject bestScoreUpdateSet;
    public TextMeshProUGUI inputName;
    public Button inputButton;

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        if (scoreText == null)
            Debug.LogError("score text is null");

        if (restartText == null)
            Debug.LogError("restart text is null");
        if (exitButton == null)
            Debug.LogError("exit button is null");

        gameManager = GameManager.Instance;

        startSet.SetActive(!GameManager.isGameStart);
        restartText.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);

        exitButton.onClick.AddListener(ExitToMain);
        bestScoreText.text = PlayerPrefs.GetInt(GameManager.FlappyPlaneBestScoreKey).ToString();

        inputButton.onClick.AddListener(SaveName);
    }

    public void SetStart()
    {
        startSet.SetActive(false);
    }

    public void SetRestart()
    {
        restartText.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();

    }

    public void ExitToMain()
    {
        SceneManager.LoadScene("MainScene");
        GameManager.isGameStart = false;
    }

    public void UpdateBestScore(int score)
    {
        bestScoreText.text = score.ToString();
    }

    public void SaveName()
    {
        PlayerPrefs.SetString(GameManager.FlappyPlaneBestScoreNameKey, inputName.text);
        bestScoreUpdateSet.gameObject.SetActive(false);

    }

    public void ShowBestScoreUpdate(bool isUpdate)
    {
        bestScoreUpdateSet.gameObject.SetActive(isUpdate);
    }
}
