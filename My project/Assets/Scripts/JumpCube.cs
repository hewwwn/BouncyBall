using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JumpCube : MonoBehaviour
{
    [SerializeField] float JumpForce;

    [SerializeField] Vector3 direction;
  
    void Awake()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponent<Movement>().MoveTo(direction, JumpForce);
            

        }
    }
    
    
}
