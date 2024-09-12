using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageButton : MonoBehaviour
{
    public static int stageLevel;

    public void NomalBtn()
    {
        ButtonSFXPlayer.Instance.PlayButtonSFX();
        SceneManager.LoadScene("MainScene");// Check ex)NomalScene
        stageLevel = 1;
    }

    public void HardBtn()
    {
        ButtonSFXPlayer.Instance.PlayButtonSFX();
        SceneManager.LoadScene("MainScene");// Check ex)HardScene
        stageLevel = 2;
    }

    public void HiddenBtn()
    {
        ButtonSFXPlayer.Instance.PlayButtonSFX();
        SceneManager.LoadScene("MainScene");// Check ex)HiddenScene
        stageLevel = 3;
    }

}
