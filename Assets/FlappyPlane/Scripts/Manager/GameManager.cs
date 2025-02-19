using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //싱글톤의 가장 기본적인 형태
    static GameManager gameManager;
    public static GameManager Instance { get { return gameManager; } }

    static public bool isGameStart = false;

    private int currentScore = 0;

    UIManager uimanager;
    public UIManager UIManager { get { return uimanager; } }

    private void Awake()
    {
        gameManager = this;
        uimanager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        if(!isGameStart)
            Time.timeScale = 0f;
        uimanager.UpdateScore(0);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        uimanager.SetRestart();
    }

    public void StartGame()
    {
        isGameStart = true;
        Time.timeScale = 1f;
        uimanager.SetStart();
        Debug.Log("StartGame");
    }

    public void RestartGame()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        Debug.Log("RestartGame");
        Time.timeScale = 1f;
        SceneManager.LoadScene("FlappyPlaneScene");
    }

    public void AddScore(int score)
    {
        currentScore += score;
        //Debug.Log("Score : " + currentScore);
        uimanager.UpdateScore(currentScore);
    }
}
