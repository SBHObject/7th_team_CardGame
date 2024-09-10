using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public static CardManager Instance;

    private CardManager() {}

    void Awake() {
        if(Instance == null)  {
            Instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    public Card firstCard;
    public Card secondCard;
    public Transform cards;
    public AudioClip audioClip;
    public AudioSource audioSource;
    public GameObject card;

    void Start() {
        SpwanCard();
    }

    void SpwanCard() {
        Debug.Log("[CardManager.cs] SpawnCard");

        Time.timeScale = 1.0f;
        audioSource = GetComponent<AudioSource>();


        int difficulty = StageButton.stageLevel; // 스테이지레벨 체크
        int cardNum = 0;    // 생성할 카드 수
        // 아래는 스테이지 레벨에 따른 카드수 결정
        switch(difficulty) {
            case 1 : // Normal
                cardNum = 12;
                break;
            case 2 : // Hard
                cardNum = 20;
                break;
            case 3: // hidden
                cardNum = 10;
                break;
        }

        List<int> arr = new List<int>();
        for (int i = 0; i < cardNum; i++) {
            arr.Add(i/2);
        }
        arr = arr.OrderBy(x => Random.Range(0f, cardNum/2-1)).ToList();

        for (int i = 0; i < cardNum; i++) {
            GameObject go = Instantiate(card, this.transform);

            go.transform.SetParent(cards);
            go.GetComponent<Card>().Setting(arr[i]); // 카드 기본 설정

            GameManager.Instance.cardCount = arr.Count;
        }
    }

    public void isMatched() {
        Debug.Log("[CardManager.cs] isMatched");

        int boom = StageButton.stageLevel; // 스테이지 레벨체크
        if (boom == 3) // 스테이지가 히든일경우
        {
            if (firstCard.idx == secondCard.idx) // 두개가 동일한 카드이면
            {
                if (firstCard.idx == 0) // 폭탄인지 체크 > 폭탄이라면
                {
                    Invoke(nameof(EndGame), 1.5f); // 게임끝
                }
            }
        }
        // 아래는 동일카드 체크 및 게임종료 로직
        if(firstCard.idx == secondCard.idx) {
            audioSource.PlayOneShot(audioClip);

            firstCard.HideCard();
            secondCard.HideCard();

            GameManager.Instance.cardCount -= 2;

            if (GameManager.Instance.cardCount == 0) {
                //GameManager.Instance.isPlay = false; // 게임이 종료됐음을 명시
                Invoke(nameof(EndGame), 1.5f);
            }
        }
        else {
            firstCard.CloseCard();
            secondCard.CloseCard();
        }
        CardReset();
    }

    void CardReset() {
        firstCard = null;
        secondCard = null;
    }

    void EndGame() {
        GameManager.Instance.EndGame();
    }
}
