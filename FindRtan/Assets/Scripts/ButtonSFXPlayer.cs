using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSFXPlayer : MonoBehaviour
{
    public static ButtonSFXPlayer Instance;

    //��ư Ŭ���� ����� ����
    private AudioSource audioSource;
    public AudioClip buttonSFX;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(this);
    }

    public void PlayButtonSFX()
    {
        audioSource.PlayOneShot(buttonSFX);
    }
}
