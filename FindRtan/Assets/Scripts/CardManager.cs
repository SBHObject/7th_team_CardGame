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

    //생성 연출을 위해,SpawnCard 함수에서 필드로 이동
    private int cardNum = 0;
    //카드 생성 연출 시작지점
    public Transform cardDeckPosition;
    //카드 배치 이동속도
    private float moveSpeed = 5f;

    //카드 저장
    private GameObject[] realCards;

    void Start() {
        SpwanCard();
    }

    void SpwanCard()
    {
        Debug.Log("[CardManager.cs] SpawnCard");

        Time.timeScale = 1.0f;
        audioSource = GetComponent<AudioSource>();


        int difficulty = StageButton.stageLevel; // 스테이지레벨 체크
        cardNum = 0;    // 생성할 카드 수
        // 아래는 스테이지 레벨에 따른 카드수 결정
        switch (difficulty)
        {
            case 1: // Normal
                cardNum = 12;
                break;
            case 2: // Hard
                cardNum = 20;
                break;
            case 3: // hidden
                cardNum = 10;
                break;
        }

        realCards = new GameObject[cardNum];

        List<int> arr = new List<int>();
        for (int i = 0; i < cardNum; i++)
        {
            arr.Add(i / 2);
        }
        arr = arr.OrderBy(x => Random.Range(0f, cardNum / 2 - 1)).ToList();

        for (int i = 0; i < cardNum; i++)
        {
            GameObject go = Instantiate(card, this.transform);

            go.transform.SetParent(cards);
            go.GetComponent<Card>().Setting(arr[i]); // 카드 기본 설정

            GameManager.Instance.cardCount = arr.Count;

            realCards[i] = go;
            //카드 생성후, 배치 이펙트를 보여주기 전까지 비활성화
            go.SetActive(false);
        }

        CardArrangeEffect();
    }

    public void IsMatched() {
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
                else if (GameManager.Instance.cardCount == 2)
                {
                    Invoke(nameof(EndGame), 1.5f);
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

    //카드 생성 연출
    private void CardArrangeEffect()
    {
        //카드배치의 세로줄 수, 나머지가 있으면 +1 추가
        int lineNum = (cardNum % 4 == 0) ? cardNum / 4 : cardNum / 4 + 1;
        int lastLine = (cardNum % 4 == 0) ? 4 : cardNum % 4;
        //가짜 카드 배열 생성
        GameObject[] fakeCardDeck = new GameObject[cardNum];
        //위치에 필요한만큼 가짜카드 생성
        for(int i = 0; i < cardNum; i++)
        {
            fakeCardDeck[i] = Instantiate(card, cardDeckPosition.transform.localPosition, Quaternion.identity);
            //가짜카드을의 버튼기능 비활성화
            fakeCardDeck[i].GetComponentInChildren<Button>().enabled = false;
        }
        //마지막 카드 가중치
        int lastCardAdded = 0;
        //세로줄로 카드 이동
        for (int j = 0; j < lineNum; j++)
        {
            //가로줄로 카드 이동
            for (int k = 0; k < 4; k++)
            {
                if(j == lineNum -1 && k >= lastLine)
                {
                    lastCardAdded++;
                    continue;
                }
                //홀수일때, 중앙값이 -1인 알고리즘 필요 짝수일때, 중앙의 양쪽값이 -0.3, -0.7
                float middleNum = lineNum % 2 == 0 ? lineNum / 2f - 0.5f : lineNum / 2;
                //카드 목표지점
                Vector3 targetPosition = new Vector3(-2.1f + (1.4f * k), -1 + (middleNum - j) * 1.4f, 0);
                //카드 이동 코루틴
                StartCoroutine(CardMove(fakeCardDeck[j * 4 + k], targetPosition, fakeCardDeck, j * 4 + k - lastCardAdded));
            }
        }
    }

    private IEnumerator CardMove(GameObject moveObject, Vector3 targetPosition, GameObject[] fakeCards, int lastCard)
    {
        //강제 update 구현...
        while (true)
        {
            //지정위치에 가까워지면 코루틴 강제 종료
            if (Vector3.SqrMagnitude(targetPosition - moveObject.transform.position) < 0.01f)
            {
                //마지막 카드의 이동이 끝나면 작동
                if(lastCard == cardNum - 1)
                {
                    //게임 시작
                    GameManager.Instance.isStart = true;
                    //시작시 SFX 재생
                    GameManager.Instance.PlayStartSound();
                }
                //코루틴 종료 전, 최종적으로 위치를 맞춰줌
                moveObject.transform.position = targetPosition;
                //진짜 카드 활성화
                realCards[lastCard].gameObject.SetActive(true);
                break;

            }
            //가짜 카드들 이동
            moveObject.transform.position = Vector3.Lerp(moveObject.transform.position, targetPosition, moveSpeed * Time.deltaTime);
            //강제 업데이트 구현...
            yield return new WaitForSeconds(Time.deltaTime);
        }
        
        Destroy(moveObject.gameObject);
    }
}
