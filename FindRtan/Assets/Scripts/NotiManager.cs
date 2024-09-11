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

    public void ShowNotification(Sprite cardImage)
    {
        notificationCardImage.sprite = cardImage;
        notificationPanel.SetActive(true);
    }
}
