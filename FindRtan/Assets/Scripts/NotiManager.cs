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

    public void ShowNotification(Sprite cardImage) // ī��ȹƯ�ǳ�
    {
        notificationCardImage.sprite = cardImage;
        notificationPanel.SetActive(true);
        StartCoroutine(HideNotificationAfterDelay(3f)); //3�ʵ������� �Լ��۵�
    }
    private IEnumerator HideNotificationAfterDelay(float delay) // �˸�����
    {
        yield return new WaitForSeconds(delay);
        notificationPanel.SetActive(false);
    }
}
