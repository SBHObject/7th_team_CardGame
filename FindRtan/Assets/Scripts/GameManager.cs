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
    //���� ���۽� SFX
    public AudioClip startSound;

    //���� ���� ����
    public bool isStart = false;
    private bool hurry = false;

    void Update() 
    {

        //���ۿ��ΰ� false�̸�, �۵����� ����
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
            //30�� �������� �ð� ����
            time += Time.deltaTime;
            if(time >= 20f && hurry == false)
            {
                //20�ʰ� ������, BGM �ӵ� ����
                AudioManager.Instance.HurryUpBGM();
                //�ѹ��� �۵�
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
            DontDestroyOnLoad(notificationObject); // �� ��ȯ �ÿ��� ����
        }
        Time.timeScale = 1.0f;
        audioSource = GetComponent<AudioSource>();
        //ȿ���� ��� ���� �ʱ�ȭ
        audioSource.volume = 0.3f;
    }
    public void RandomCard()// ����ī�弱�� �� ȹ��ī��˸�, �������� ����
    {
        int randomIndex = Random.Range(0, cardImages.Length); //0���� �迭�� ũ�� ������ ���ڸ� �������� �ϳ� ����
        Sprite selectedCard = cardImages[randomIndex]; // ������ ���ڸ� �־� �� ī���� sprite�� ����

        // NotificationManager�� ���� �˸� ǥ��
        if (NotificationManager.Instance != null)
        {
            NotificationManager.Instance.ShowNotification(selectedCard); // ������ ������ sprite�� �˸��ǳڿ� ����
        }

        PlayerPrefs.SetInt("CollectedCard_" + randomIndex, 1); // PlayerPrefs �� �̿��ؼ� �ش�ī���ȣ�� ����
        PlayerPrefs.Save();
    }

    public void EndGame()
    {
        int stageLvl = StageButton.stageLevel;

        if (stageLvl == 1)
        {
            RandomCard();
            PlayerPrefs.SetInt("NormalModeCleared", 1); // �븻��� Ŭ���� ����
            PlayerPrefs.Save();// ����������
        }
        else if (stageLvl == 2)
        {
            RandomCard();
            PlayerPrefs.SetInt("HardModeCleared", 1);
            PlayerPrefs.Save();
        } 
            
        isStart = false;
        //BGM �ӵ� ��������
        AudioManager.Instance.ResetBGMPirch();

        endText.SetActive(true);
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
            //�ʹ� �ò������� ���� ����...
            audioSource.volume = 0.2f;
            audioSource.PlayOneShot(failSound);
        }
    }

    //���� ���� SFX ����� ���� �Լ�
    public void PlayStartSound()
    {
        audioSource.PlayOneShot(startSound);
    }

}
