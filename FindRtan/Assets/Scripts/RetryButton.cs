using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    //�̹� �ܰ� �����, ���� Ȱ��ȭ �Ǿ��ִ� ���� �״�� ������
    public void Retry() {
        //���� ���� �ҷ�����
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ButtonSFXPlayer.Instance.PlayButtonSFX();
    }

    public void MainMaueBtn()
    {
        SceneManager.LoadScene("StartScene");
        ButtonSFXPlayer.Instance.PlayButtonSFX();
    }
}
