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

    public void ShowNotification(Sprite cardImage) // 카드획득 알림
    {
        // 이전에 RandomCard()함수에서 받아온 Sprite가 notificationCardImage.sprite에 들어감
        notificationCardImage.sprite = cardImage; 
        notificationPanel.SetActive(true); // 미리 만들어둔 판넬을 켜주고 
        StartCoroutine(HideNotificationAfterDelay(3f)); // 여기부터 아래까지는 코루틴을 이용한 3초 딜레이주기
    }
    private IEnumerator HideNotificationAfterDelay(float delay) 
    {
        yield return new WaitForSeconds(delay); // 위에서 작성한 3초만큼 기다렸다가 다음코드 진행
        notificationPanel.SetActive(false); // 판넬끄기
    }
}
