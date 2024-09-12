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

    public void UpdateCardSlots() // 다른곳에 빼서 해보기
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
