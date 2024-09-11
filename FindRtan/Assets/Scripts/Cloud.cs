using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    float speed = 0.0025f;
    // Start is called before the first frame update
    void Start()
    {
        float x = 6.13f;
        float y = Random.Range(4.05f, 4.34f);
        transform.position = new Vector2 (x, y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed;
        float check = transform.position.x;
        if (check <= -6)
        {
         Destroy(gameObject);   
        }
    }
}
