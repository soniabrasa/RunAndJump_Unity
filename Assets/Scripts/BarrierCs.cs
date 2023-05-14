using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierCs : MonoBehaviour
{
    float deactivatePositionX;
    void Start()
    {
        deactivatePositionX = -20f;
    }


    void Update()
    {
        if (transform.position.x < deactivatePositionX)
        {
            GameManager.instance.DeactivateBarrier(gameObject);
        }
    }
}
