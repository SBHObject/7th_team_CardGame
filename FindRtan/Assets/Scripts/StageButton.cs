using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageButton : MonoBehaviour
{
    public GameObject stagePanel;
    public static int stageLevel;
<<<<<<< HEAD
    public void NormalBtn()
    {
        SceneManager.LoadScene("MainScene");
=======

    public void NomalBtn()
    {
        ButtonSFXPlayer.Instance.PlayButtonSFX();
        SceneManager.LoadScene("MainScene");// Check ex)NomalScene
>>>>>>> Dev
        stageLevel = 1;
    }

    public void HardBtn()
    {
<<<<<<< HEAD
        SceneManager.LoadScene("MainScene");
=======
        ButtonSFXPlayer.Instance.PlayButtonSFX();
        SceneManager.LoadScene("MainScene");// Check ex)HardScene
>>>>>>> Dev
        stageLevel = 2;
    }

    public void HiddenBtn()
    {
<<<<<<< HEAD
        SceneManager.LoadScene("MainScene");
=======
        ButtonSFXPlayer.Instance.PlayButtonSFX();
        SceneManager.LoadScene("MainScene");// Check ex)HiddenScene
>>>>>>> Dev
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
    }
}
