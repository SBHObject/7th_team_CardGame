using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    public GameObject cloud;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MakeCloud", 0.0f, 7.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void MakeCloud()
    {
        Instantiate(cloud);
    }
}
