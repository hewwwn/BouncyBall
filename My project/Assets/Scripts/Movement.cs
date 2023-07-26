using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
[SerializeField] float moveSpeed;
Rigidbody body;

void Awake()
{
body = GetComponent<Rigidbody>();
}

public void MoveTo(Vector3 direction, float force = 0)
{
    Vector3 moveForce = Vector3.zero;

    if (force == 0)
    {
        direction.y = 0;
        moveForce = direction.normalized * moveSpeed;
    }
    else
    {
        moveForce = direction * force;
    }
    
    body.AddForce(moveForce); 

}
}
