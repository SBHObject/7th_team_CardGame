using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public static StartManager Instance;
    public GameObject stagePanel;
    public static bool cardsUpdated = false;


    public void PlayBtn()
    {
        ButtonSFXPlayer.Instance.PlayButtonSFX();
        stagePanel.SetActive(true);
    }
    private void Update()
    {
        if (cardsUpdated)
        {
            cardsUpdated = false;
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }





}
