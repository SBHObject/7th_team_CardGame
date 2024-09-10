using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int idx = 0;

    public SpriteRenderer frontImage;

    public GameObject front;
    public GameObject back;

    public AudioClip clip;
    public AudioSource audioSource;

    public Button btn;

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    public void Setting(int number) {
        idx = number;
        frontImage.sprite = Resources.Load<Sprite>($"CardImage{idx}");

        Vector2 spriteSize = frontImage.sprite.bounds.size;
        Vector3 frontImgObjectSize = frontImage.transform.localScale;

        float scaleX = frontImgObjectSize.x / spriteSize.x;
        float scaleY = frontImgObjectSize.y / spriteSize.y;

        frontImage.transform.localScale = new Vector3(scaleX, scaleY, 1);
    }

    public void OpenCard() {
        Debug.Log("[Card.cs] OpenCard");
        CheckFirstSecondCard(); 
        FlipCard();
        audioSource.PlayOneShot(clip);
    }

    private void FlipCard() {
        GetComponent<RectTransform>().DORotate(new Vector3(0f, 90f, 0f), 0.3f, RotateMode.FastBeyond360)
            .SetEase(Ease.InOutQuad) 
            .OnComplete(() => {
                if(front.activeSelf) {
                    front.SetActive(false);
                    back.SetActive(true);
                }
                else {
                    front.SetActive(true);
                    back.SetActive(false);
                }
                transform.DORotate(new Vector3(0f, 0f, 0f), 0.3f, RotateMode.FastBeyond360)
                    .SetEase(Ease.InOutQuad);
            });
    }

    private void CheckFirstSecondCard() {
        if (CardManager.Instance.secondCard == null) {
            if(CardManager.Instance.firstCard == null) {
                CardManager.Instance.firstCard = this;
            }
            else {
                CardManager.Instance.secondCard = this;
                CardManager.Instance.isMatched();
            }
        }
    }

    public void HideCard() {
        Debug.Log("[Card.cs] HideCard");
        DOTween.Sequence()
            .AppendInterval(0.75f)
            .Append(GetComponent<RectTransform>().DOScale(0, 0.5f)
                .SetEase(Ease.InOutCubic)
                .OnComplete(() => {
                    front.SetActive(false);
                    back.SetActive(false);
                }));
    }

    public void CloseCard() {
        Debug.Log("[Card.cs] CloseCard");
        Invoke("CloseCardInvoke", 0.75f);
    }

    void CloseCardInvoke() {
        DOTween.Kill(this);
        FlipCard();
    }
}
