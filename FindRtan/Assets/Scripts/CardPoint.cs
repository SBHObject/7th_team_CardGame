using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPoint : MonoBehaviour
{
    public static CardPoint instance;
    public Sprite[] cardImages;
    public Image[] cardSlots;

    private void Start()
    {
  
            UpdateCardSlots();   

    }
    private void Awake()
    {
        if (instance == null)
        {  instance = this; }
        else
        {
            Destroy(instance);
        }
    }

    public void UpdateCardSlots() // PlayerPrefs에 저장되어있는 획득한 카드번호에 맞게 메인메뉴에 해당 슬롯 활성화
    {
        for (int i = 0; i < cardSlots.Length; i++) // 반복문을 통해 카드슬롯의 수만큼 하나씩 확인함
        {
            if (PlayerPrefs.GetInt("CollectedCard_" + i, 0) == 1) // 확인중에 해당슬롯이 보유중이라면
            {
                cardSlots[i].sprite = cardImages[i]; // 해당카드이미지를 해당 sprite에 설정하고
                cardSlots[i].gameObject.SetActive(true); // 활성화
            }
            else // 보유하지않으면
            {
                cardSlots[i].gameObject.SetActive(false); // 비활성화
            }
        }
    }
}
