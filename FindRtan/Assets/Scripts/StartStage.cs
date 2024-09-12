using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartStage : MonoBehaviour
{
    public GameObject HardBtn;
    public GameObject HardBtnOff;
    public GameObject HiddenBtn;
    // Start is called before the first frame update
    void Start()
    {
        bool nC = PlayerPrefs.GetInt("NormalModeCleared", 0) == 1;
        bool hC = PlayerPrefs.GetInt("HardModeCleared", 0) == 1;
        if (nC)
        {
            HardBtn.SetActive(true);
            HardBtnOff.SetActive(false);
        }
        else if (hC)
        {
            HiddenBtn.SetActive(true);
        }
        else if (!nC)
        {
            HardBtn.SetActive(false);
            HardBtnOff.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
