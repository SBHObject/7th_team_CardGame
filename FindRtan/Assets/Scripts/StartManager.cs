using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public static StartManager Instance;
    public Sprite[] cardImages;
    public Image[] cardSlots;
    public GameObject stagePanel;
    public GameObject HardBtn;
    public GameObject HardBtnOff;
    public GameObject HiddenBtn;
    public static bool cardsUpdated = false;

    private void Start()
    {
        UpdateCardSlots();
        bool nC = PlayerPrefs.GetInt("NormalModeCleared", 0) == 1;
        bool hC = PlayerPrefs.GetInt("HardModeCleared", 0) == 1;
        if (nC)
        {
            HardBtn.SetActive(true);
            HardBtnOff.SetActive(false);
        }
        else if (hC)
        {
            HiddenBtn.SetActive(true);
        }
        else if (!nC)
        {
            HardBtn.SetActive(false) ;
            HardBtnOff.SetActive(true);
        }
    }
    private void Update()
    {
        if (!cardsUpdated)
        {
            UpdateCardSlots();
            cardsUpdated = true;
        }
    }
    void OnEnable()
    {
        UpdateCardSlots();
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 알림 관련 메서드 제거
    // public void RewardRandomCard() { ... }

    void CollectCard(int cardIndex)
    {
        PlayerPrefs.SetInt("CollectedCard_" + cardIndex, 1);
        PlayerPrefs.Save();
    }

    void UpdateCardSlots()
    {
        for (int i = 0; i < cardSlots.Length; i++)
        {
            if (PlayerPrefs.GetInt("CollectedCard_" + i, 0) == 1)
            {
                cardSlots[i].sprite = cardImages[i];
                cardSlots[i].gameObject.SetActive(true);
            }
            else
            {
                cardSlots[i].gameObject.SetActive(false);
            }
        }
    }


}
