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

        //피치값 초기화
        audioSource.pitch = 1.0f;
        audioSource.clip = this.audioClip;
        audioSource.Play();
    }

    //시간이 얼마 안남으면 작동
    public void HurryUpBGM()
    {
        //BGM 재생속도 증가
        audioSource.pitch = 1.1f;
    }
}
