using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText = default;
    public TMP_Text timeText = default;     //!< 생존 시간을 표시할 텍스트
    public TMP_Text bestRecordText = default;   //!< 최고 기록을 표시할 텍스트 


    private const string BEST_TIME_RECORD = "BestTime";
    private const string SCENE_NAME = "PlayScene";
    private float surviveTime = default;
    private bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        gameOverText.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
        surviveTime = 0;
        isGameOver = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SCENE_NAME);
            }   // if: R키를 누르면 재시작

            if (Input.GetKeyDown(KeyCode.Q))
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
            }
        }   // if: 게임 오버인 경우

        // 게임오버가 아닌 경우

        // { 생존시간을 갱신한다.
        surviveTime = surviveTime + Time.deltaTime;
        timeText.text = $"Time : {Mathf.FloorToInt(surviveTime)}";
        // } 생존시간을 갱신한다.

    }       //Update()

    //현재 게임을 게임오버 상태로 변경하는 메서드
    public void EndGame()
    {
        isGameOver = true;
        // gameOverText.SetActive(true);
        gameOverText.transform.localScale = Vector3.one;

        // BestTime 키로 저장된 이전까지의 최고 기록 가져오기
        float bestTime = PlayerPrefs.GetFloat(BEST_TIME_RECORD);

        // 이전까지의 치고 기록보다 현재 생존 시간이 더 긴 경우
        if (bestTime < surviveTime)
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat(BEST_TIME_RECORD, bestTime);
        }       // if: 현재 surviveTime 이 bestTime보다 클 경우 저장 

        // 최고 기록을 텍스트에 갱신한다.
        bestRecordText.text = $"Best Time : {Mathf.FloorToInt(bestTime)}";
    }       // EndGame()
}