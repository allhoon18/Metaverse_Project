using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardController : MonoBehaviour
{
    //리더보드 UI를 활성화하는 버튼 
    public Button readButton;
    //리더보드 UI
    public GameObject leaderBoardUI;
    //리더보드 UI를 비활성화하는 버튼
    public Button leaderBoardCloseButton;
    //Flappy Plane 미니게임 최고기록 이름 및 점수
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
        //PlayerPref에 저장된 이름과 점수를 불러옴
        flappyPlaneBestScore.text = PlayerPrefs.GetInt(GameManager.FlappyPlaneBestScoreKey).ToString();
        flappyPlaneBestScoreName.text = PlayerPrefs.GetString(GameManager.FlappyPlaneBestScoreNameKey);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //리더보드 오브젝트 주변 범위에 들어갔을 때 리더보드 활성화 버튼을 활성화
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
