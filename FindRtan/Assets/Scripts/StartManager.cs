using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    bool nC = false;
    bool hC = false;

    public GameObject stagePanel;
    public GameObject HardBtn;
    public GameObject HardBtnOff;
    public GameObject HiddenBtn;

    public void PlayBtn()
    {
        stagePanel.SetActive(true);
    }

    void Update()
    {
        if (nC == true)
        {
            HardBtn.SetActive(true);
            HardBtnOff.SetActive(false);
            if (hC == true)
            {
                HiddenBtn.SetActive(true);
            }
            else if (hC == false) { HiddenBtn.SetActive(false); }
        }
        else if (nC == false)
        {
            HardBtn.SetActive(false);
            HardBtnOff.SetActive(true);
        }
        
    }
}