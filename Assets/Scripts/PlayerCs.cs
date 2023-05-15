using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCs : MonoBehaviour
{
    float jumpForce;
    Animator animator;
    Rigidbody rb;


    void Start()
    {
        jumpForce = 8f;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (GameManager.instance.GameOver) { return; }

        if (IsGrounded())
        {
            // El gameObject no se desplaza en X (movimiento infinito del escenario)

            if (Input.GetButtonDown("Jump"))
            {
                Jump();
                animator.SetTrigger("Jump_trig");
            }

            if (animator.GetBool("Jump_b"))
            {
                animator.SetBool("Jump_b", false);
            }
        }

        // Rigidbodi Phsysics velocity
        if (rb.velocity.y < 0)
        {
            animator.ResetTrigger("Jump_trig");
            animator.SetBool("Jump_b", true);
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

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Barrier"))
        {
            Debug.Log($"{gameObject.name}.OnCollisionEnter({other.gameObject.name})");

            // Tipo de animación entre 1 y 2
            int deathType = Random.Range(1, 3);

            animator.SetInteger("DeahtType_int", deathType);
            animator.SetBool("Death_b", true);

            Debug.Log($"\t Death type {deathType}");

            GameManager.instance.SetGameOver();
        }
    }
}
