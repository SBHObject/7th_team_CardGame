using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioClip audioClip;
    public AudioSource audioSource;
    
    private void Awake() {
        if(Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

    void Start() {
        audioSource = GetComponent<AudioSource>();

        //��ġ�� �ʱ�ȭ
        audioSource.pitch = 1.0f;
        audioSource.clip = this.audioClip;
        audioSource.Play();
    }

    //�ð��� �� �ȳ����� �۵�
    public void HurryUpBGM()
    {
        //BGM ����ӵ� ����
        audioSource.pitch = 1.1f;
    }
}
