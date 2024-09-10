using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Text timeText;
    float time = 0.00f;


    public int cardCount = 0;

    public GameObject endText;

    //승리시 작동할 UI
    public GameObject winUi;
    //패배시 작동할 UI
    public GameObject failUi;

    //승리시, 남은 시간을 표기하는 텍스트
    public Text leftTimeText;

    void Update() {
        if (time >= 30.0f) {
            //게임 종료후 인보크를 발생시키기 위해 timeSacle = 0 삭제
            time = 30f;
            EndGame();
        }
        else
        {
            //30초 이전에만 시간 증가
            time += Time.deltaTime;
        }
        timeText.text = time.ToString("N2");
    }

    void Awake() {
        if(Instance == null)  {
            Instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    public void EndGame() {
        endText.SetActive(true);

        //게임 종료(끝! 텍스트 발생) 후, 1초후 UI 활성화
        Invoke("ActiveGameoverUi", 1);
    }

    //게임오버 UI를 발생시키는 함수
    public void ActiveGameoverUi()
    {
        //cardCount 변수가 0일때 승리, 아니면 패배
        if(cardCount == 0)
        {
            //승리시 남은시간 표기
            leftTimeText.text = time.ToString("N2");
            //승리 UI 발생
            winUi.SetActive(true);
        }
        else
        {
            //패배 UI 발생
            failUi.SetActive(true);
        }
    }

}
