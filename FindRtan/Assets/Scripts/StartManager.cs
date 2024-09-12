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

<<<<<<< HEAD
    private void Start()
    {

    }
    private void Update()
    {
        if (cardsUpdated)
        {
            cardsUpdated = false;
        }
=======

    public void PlayBtn()
    {
        ButtonSFXPlayer.Instance.PlayButtonSFX();
        stagePanel.SetActive(true);
>>>>>>> Dev
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
