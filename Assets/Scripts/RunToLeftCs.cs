using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunToLeftCs : MonoBehaviour
{
    float speed;


    void Start()
    {
        speed = 12f;
    }


    void Update()
    {
        // En cada frame, transform.left * speed;
        transform.position -= transform.right * speed * Time.deltaTime;
    }
}
