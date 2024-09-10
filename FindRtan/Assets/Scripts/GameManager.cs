using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public GameObject MainBtn;
    public static GameManager Instance;
    public Text timeText;
    float time = 0.00f;
    

    public int cardCount = 0;

    public GameObject endText;

    //�¸��� �۵��� UI
    public GameObject winUi;
    //�й�� �۵��� UI
    public GameObject failUi;

    //�¸���, ���� �ð��� ǥ���ϴ� �ؽ�Ʈ
    public Text leftTimeText;
    // ���ӸŴ��� ������Ʈ�� ���� ������ҽ� �ҷ�����
    private AudioSource audioSource;

    //�¸�, �й� ����
    public AudioClip winSound;
    public AudioClip failSound;

    //���� ���� ����
    public bool isStart = false;

    void Update() 
    {
        //���ۿ��ΰ� false�̸�, �۵����� ����
        if (isStart == false)
            return;

        if (time >= 30.0f) 
        {
            //���� ������ �κ�ũ�� �߻���Ű�� ���� timeSacle = 0 ����
            time = 30f;
            EndGame();
        }
        else
        {
            //30�� �������� �ð� ����
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

    private void Start()
    {
        MainBtn.SetActive(false);
        Time.timeScale = 1.0f;
        audioSource = GetComponent<AudioSource>();
    }

    public void EndGame() {
        endText.SetActive(true);
        Time.timeScale = 0.0f; // ��� Ȯ���� ���� �ð�����
        MainBtn.SetActive(true);
        //���� ����(��! �ؽ�Ʈ �߻�) ��, 1���� UI Ȱ��ȭ
        Invoke("ActiveGameoverUi", 1);
    }

    //���ӿ��� UI�� �߻���Ű�� �Լ�
    public void ActiveGameoverUi()
    {
        //cardCount ������ 0�϶� �¸�, �ƴϸ� �й�
        if(cardCount == 0)
        {
            //�¸��� �����ð� ǥ��
            leftTimeText.text = time.ToString("N2");
            //�¸� UI �߻�
            winUi.SetActive(true);
            //SFX ���, �¸�
            audioSource.PlayOneShot(winSound);
        }
        else
        {
            //�й� UI �߻�
            failUi.SetActive(true);
            //SFX ���, �й�
            audioSource.PlayOneShot(failSound);
        }
    }

}
