using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour
{

    public GameObject stagePanel;
    public GameObject HardBtn;
    public GameObject HardBtnOff;
    public GameObject HiddenBtn;


    public void PlayBtn()
    {
        ButtonSFXPlayer.Instance.PlayButtonSFX();
        stagePanel.SetActive(true);
    }

    void Update()
    {
        bool nC = PlayerPrefs.GetInt("NormalModeCleared", 0) == 1;
        bool hC = PlayerPrefs.GetInt("HardModeCleared", 0) == 1;

        HardBtn.SetActive(nC);
        HardBtnOff.SetActive(!nC);
        HiddenBtn.SetActive(hC);
        
    }
}