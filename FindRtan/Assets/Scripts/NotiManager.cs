using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NotificationManager : MonoBehaviour
{
    public static NotificationManager Instance;
    public GameObject notificationPanel;
    public Image notificationCardImage;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �� ���� �����ǵ��� ����
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowNotification(Sprite cardImage) // ī��ȹ�� �˸�
    {
        // ������ RandomCard()�Լ����� �޾ƿ� Sprite�� notificationCardImage.sprite�� ��
        notificationCardImage.sprite = cardImage; 
        notificationPanel.SetActive(true); // �̸� ������ �ǳ��� ���ְ� 
        StartCoroutine(HideNotificationAfterDelay(3f)); // ������� �Ʒ������� �ڷ�ƾ�� �̿��� 3�� �������ֱ�
    }
    private IEnumerator HideNotificationAfterDelay(float delay) 
    {
        yield return new WaitForSeconds(delay); // ������ �ۼ��� 3�ʸ�ŭ ��ٷȴٰ� �����ڵ� ����
        notificationPanel.SetActive(false); // �ǳڲ���
    }
}
