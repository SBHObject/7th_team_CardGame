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

    public void UpdateCardSlots() // PlayerPrefs�� ����Ǿ��ִ� ȹ���� ī���ȣ�� �°� ���θ޴��� �ش� ���� Ȱ��ȭ
    {
        for (int i = 0; i < cardSlots.Length; i++) // �ݺ����� ���� ī�彽���� ����ŭ �ϳ��� Ȯ����
        {
            if (PlayerPrefs.GetInt("CollectedCard_" + i, 0) == 1) // Ȯ���߿� �ش罽���� �������̶��
            {
                cardSlots[i].sprite = cardImages[i]; // �ش�ī���̹����� �ش� sprite�� �����ϰ�
                cardSlots[i].gameObject.SetActive(true); // Ȱ��ȭ
            }
            else // ��������������
            {
                cardSlots[i].gameObject.SetActive(false); // ��Ȱ��ȭ
            }
        }
    }
}
