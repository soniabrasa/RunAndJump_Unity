using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCs : MonoBehaviour
{
    float jumpForce;
    Rigidbody rb;


    void Start()
    {
        jumpForce = 8f;
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        // El gameObject no se desplaza en X (movimiento infinito del escenario)

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }
    }

    void Jump()
    {
        Debug.Log($"{gameObject.name}.Jump()");

        // Rigidbody.AddForce(Vector3 force, ForceMode mode = ForceMode.Force);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }


    // bool IsGrounded() { return transform.position.y < 0.05f; }
    bool IsGrounded()
    {
        // Default return
        bool grounded = false;

        // Physics.Raycast
        // https://docs.unity3d.com/ScriptReference/Physics.Raycast.html
        RaycastHit hit;

        // @params
        Vector3 origin = transform.position;
        Vector3 direction = Vector3.down;
        float maxDistance = 0.1f;

        // Sobrecarga con hitInfo
        // Raycast(origin, direction, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);

        if (Physics.Raycast(origin, direction, out hit, maxDistance))
        {
            grounded = true;

            // RaycastHit info
            // https://docs.unity3d.com/ScriptReference/RaycastHit.html

            // Debug.Log($"{gameObject.name}.IsGrounded");
            // Debug.Log($"\t Found an object - distance {hit.distance}");
        }

        return grounded;
    }
}
