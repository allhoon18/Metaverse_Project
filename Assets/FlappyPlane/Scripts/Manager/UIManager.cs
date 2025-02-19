using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;
    public Button exitButton;

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

        restartText.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);

        exitButton.onClick.AddListener(ExitToMain);
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
    }
}
