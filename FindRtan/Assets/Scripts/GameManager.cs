using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject notificationPrefab;
    public Sprite[] cardImages;
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
    // 게임매니저 오브젝트에 붙은 오디오소스 불러오기
    private AudioSource audioSource;

    //승리, 패배 사운드
    public AudioClip winSound;
    public AudioClip failSound;
    //게임 시작시 SFX
    public AudioClip startSound;

    //게임 시작 여부
    public bool isStart = false;
    private bool hurry = false;

    void Update() 
    {

        //시작여부가 false이면, 작동하지 않음
        if (isStart == false)
        {
            return;
        }

        if (time >= 30.0f && isStart == true) 
        {
                time = 30f;
                EndGame();
        } 
        else
        {
            //30초 이전에만 시간 증가
            time += Time.deltaTime;
            if(time >= 20f && hurry == false)
            {
                //20초가 넘으면, BGM 속도 증가
                AudioManager.Instance.HurryUpBGM();
                //한번만 작동
                hurry = true;
            }
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

    private void Start()
    {
        if (NotificationManager.Instance == null)
        {
            GameObject notificationObject = Instantiate(notificationPrefab);
            DontDestroyOnLoad(notificationObject); // 씬 전환 시에도 유지
        }
        Time.timeScale = 1.0f;
        audioSource = GetComponent<AudioSource>();
        //효과음 재생 볼륨 초기화
        audioSource.volume = 0.3f;
    }
    public void RandomCard()// 랜덤카드선택 및 획득카드알림, 수집상태 저장
    {
        int randomIndex = Random.Range(0, cardImages.Length); //0에서 배열의 크기 사이의 숫자를 랜덤으로 하나 선택
        Sprite selectedCard = cardImages[randomIndex]; // 선택한 숫자를 넣어 그 카드의 sprite를 저장

        // NotificationManager를 통해 알림 표시
        if (NotificationManager.Instance != null)
        {
            NotificationManager.Instance.ShowNotification(selectedCard); // 위에서 저장한 sprite를 알림판넬에 전달
        }

        PlayerPrefs.SetInt("CollectedCard_" + randomIndex, 1); // PlayerPrefs 를 이용해서 해당카드번호를 저장
        PlayerPrefs.Save();
    }

    public void EndGame()
    {
        int stageLvl = StageButton.stageLevel;

        if (stageLvl == 1)
        {
            RandomCard();
            PlayerPrefs.SetInt("NormalModeCleared", 1); // 노말모드 클리어 저장
            PlayerPrefs.Save();// 데이터저장
        }
        else if (stageLvl == 2)
        {
            RandomCard();
            PlayerPrefs.SetInt("HardModeCleared", 1);
            PlayerPrefs.Save();
        } 
            
        isStart = false;
        //BGM 속도 돌려놓기
        AudioManager.Instance.ResetBGMPirch();

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
            //SFX 재생, 승리
            audioSource.PlayOneShot(winSound);
        }
        else
        {
            //패배 UI 발생
            failUi.SetActive(true);
            //SFX 재생, 패배
            //너무 시끄러워서 볼륨 조절...
            audioSource.volume = 0.2f;
            audioSource.PlayOneShot(failSound);
        }
    }

    //게임 시작 SFX 재생을 위한 함수
    public void PlayStartSound()
    {
        audioSource.PlayOneShot(startSound);
    }

}
