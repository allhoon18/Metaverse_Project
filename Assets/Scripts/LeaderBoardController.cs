using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardController : MonoBehaviour
{
    public Button readButton;
    public GameObject leaderBoardUI;
    public Button leaderBoardCloseButton;
    public TextMeshProUGUI flappyPlaneBestScore;
    public TextMeshProUGUI flappyPlaneBestScoreName;

    private void Awake()
    {
        readButton.onClick.AddListener(ShowLeaderBoard);
        leaderBoardCloseButton.onClick.AddListener(CloseLeaderBoard);
    }

    private void ShowLeaderBoard()
    {
        leaderBoardUI.gameObject.SetActive(true);
        UpdateFlappyPlaneBestScore();
    }

    private void UpdateFlappyPlaneBestScore()
    {
        flappyPlaneBestScore.text = PlayerPrefs.GetInt(GameManager.FlappyPlaneBestScoreKey).ToString();
        flappyPlaneBestScoreName.text = PlayerPrefs.GetString(GameManager.FlappyPlaneBestScoreNameKey);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        readButton.gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        readButton.gameObject.SetActive(false);
        leaderBoardUI.gameObject.SetActive(false);
    }

    public void CloseLeaderBoard()
    {
        leaderBoardUI.gameObject.SetActive(false);
    }
}
