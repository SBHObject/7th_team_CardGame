using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotiObject : MonoBehaviour
{
    public static NotiObject Instance;
    void Awake()
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
