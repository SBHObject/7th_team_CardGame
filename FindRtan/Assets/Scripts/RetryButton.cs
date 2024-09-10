using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    //이번 단계 재시작, 현재 활성화 되어있는 씬을 그대로 가져옴
    public void Retry() {
        //지금 씬을 불러오기
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMaueBtn()
    {
        SceneManager.LoadScene("StartScene");
    }
}
