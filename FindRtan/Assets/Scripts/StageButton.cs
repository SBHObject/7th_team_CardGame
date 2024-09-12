using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageButton : MonoBehaviour
{
    public GameObject stagePanel;
    public static int stageLevel;
    public void NormalBtn()
    {
        ButtonSFXPlayer.Instance.PlayButtonSFX();
        SceneManager.LoadScene("MainScene");
        stageLevel = 1;
    }

    public void HardBtn()
    {
        ButtonSFXPlayer.Instance.PlayButtonSFX();
        SceneManager.LoadScene("MainScene");
        stageLevel = 2;
    }

    public void HiddenBtn()
    {
        ButtonSFXPlayer.Instance.PlayButtonSFX();
        SceneManager.LoadScene("MainScene");
        stageLevel = 3;
    }
    public void PlayBtn()
    {
        stagePanel.SetActive(true);
    }
    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        SceneManager.LoadScene("StartScene");
    }
}
