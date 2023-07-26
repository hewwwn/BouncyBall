using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BounceBallController : MonoBehaviour
{
    public float minHeight;
    public float moveSpeed = 5f;
    public float bounceForce = 5f;
    public float maxBounceHeight = 3f;
    public LayerMask groundLayer;

    private Rigidbody rb;
    private bool isBouncing = false;
 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (x != 0 || z != 0)
        {
            Vector3 movementDirection = new Vector3(x, 0, z).normalized;
            if (movementDirection != Vector3.zero)
            {
                rb.AddForce(movementDirection * moveSpeed * Time.deltaTime, ForceMode.VelocityChange);
            }

            //Vector3 newPosition = rb.position + movementDirection * moveSpeed * Time.deltaTime;
            //rb.MovePosition(newPosition);
        }

        ChangeStageFallDown();

        // Vector3 position = rb.position;
        // position.y = Mathf.Clamp(position.y, 0f, maxBounceHeight);
        // rb.position = position;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!isBouncing && collision.gameObject.layer == 3)
        {
            Bounce(collision.contacts);
        }
    }

    void Bounce(ContactPoint[] normal)
    {
        isBouncing = true;
        foreach (var point in normal)
        {
            rb.AddForce(point.normal.normalized * bounceForce, ForceMode.Impulse);
        }
        StartCoroutine(ResetBouncing());
    }

    IEnumerator ResetBouncing()
    {
        
        yield return new WaitForSeconds(0.5f);
        isBouncing = false;
    }

    private void ChangeStageFallDown()
    {
        if (transform.position.y < minHeight)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    
}