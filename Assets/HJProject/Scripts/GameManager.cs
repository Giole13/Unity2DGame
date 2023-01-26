using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject gameOverText = default;
    private GameObject timeTextObj = default;     //!< 생존 시간을 표시할 텍스트
    private GameObject bestRecordTextObj = default;   //!< 최고 기록을 표시할 텍스트 


    private const string BEST_TIME_RECORD = "BestTime";
    private const string SCENE_NAME = "PlayScene";
    private float surviveTime = default;
    private bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        // { 출력할 텍스트 오브젝트를 찾아온다.
        GameObject uiObjs_ =  GioleFunc.GetRootObj("UiObj");
        // } 출력할 텍스트 오브젝트를 찾아온다.
        timeTextObj = uiObjs_.FindChildObj("TimeText");
        gameOverText = uiObjs_.FindChildObj("GameOverText");
        bestRecordTextObj = uiObjs_.FindChildObj("BestScore");
        
        gameOverText.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
        surviveTime = 0;
        isGameOver = false;

        // if(tartgetObj == null || tartgetObj == default){
        //     Debug.Log("TimeText Root 오브젝트가 아니라서 못 찾았다.");
        // }
        // else{
        //     Debug.Log("UiObj 오브젝트여서 찾았다.");
        // }

    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                GioleFunc.LoadScene(SCENE_NAME);
                // SceneManager.LoadScene(SCENE_NAME);
            }   // if: R키를 누르면 재시작

            if (Input.GetKeyDown(KeyCode.Q))
            {
                // Q 키를 누르면 종료
                GioleFunc.QuitThisGame();
            }
        }   // if: 게임 오버인 경우

        // 게임오버가 아닌 경우

        // { 생존시간을 갱신한다.
        surviveTime = surviveTime + Time.deltaTime;
        GioleFunc.SetTmpText(timeTextObj, 
        $"Time : {Mathf.FloorToInt(surviveTime)}");
        // timeText.text = $"Time : {Mathf.FloorToInt(surviveTime)}";
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
        GioleFunc.SetTmpText(bestRecordTextObj, 
        $"Best Time : {Mathf.FloorToInt(bestTime)}");
        // bestRecordText.text = $"Best Time : {Mathf.FloorToInt(bestTime)}";
    }       // EndGame()
}