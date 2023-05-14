using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationInfinite : MonoBehaviour
{
    Vector3 initPosition;
    float step, maxPositionX;


    void Start()
    {
        initPosition = transform.position;

        // Collider para saber las medidas del gameObject
        BoxCollider bc = GetComponent<BoxCollider>();

        if (bc != null)
        {
            step = bc.size.x / 2;
        }

        maxPositionX = initPosition.x - step;

        // Debug.Log($"{gameObject.name}.Start initPosition.x = {initPosition.x}");
        // Debug.Log($"{gameObject.name}.Start step = {step}");

    }


    void Update()
    {
        if (transform.position.x < maxPositionX)
        {
            // Debug.Log($"{gameObject.name}.Update maxPositionX = {maxPositionX}");
            // Debug.Log($"\t position.x = {transform.position.x}");

            transform.position = initPosition;
        }
    }
}
