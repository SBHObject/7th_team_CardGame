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
            DontDestroyOnLoad(gameObject); // 씬 간에 유지되도록 설정
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowNotification(Sprite cardImage) // 카드획특판넬
    {
        notificationCardImage.sprite = cardImage;
        notificationPanel.SetActive(true);
        StartCoroutine(HideNotificationAfterDelay(3f)); //3초딜레이후 함수작동
    }
    private IEnumerator HideNotificationAfterDelay(float delay) // 알림끄기
    {
        yield return new WaitForSeconds(delay);
        notificationPanel.SetActive(false);
    }
}
