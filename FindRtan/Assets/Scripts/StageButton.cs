using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageButton : MonoBehaviour
{
    public static int stageLevel = 0;
    public void NomalBtn()
    {
        SceneManager.LoadScene("MainScene");// Check ex)NomalScene
        stageLevel = 1;
    }

    public void HardBtn()
    {
        SceneManager.LoadScene("MainScene");// Check ex)HardScene
        stageLevel = 2;
    }

    public void HiddenBtn()
    {
        SceneManager.LoadScene("MainScene");// Check ex)HiddenScene
        stageLevel = 3;
    }
}
