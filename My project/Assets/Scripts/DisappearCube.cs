using System. Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearCube : MonoBehaviour
{
    [SerializeField] float JumpForce;

    [SerializeField] Vector3 direction;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision. gameObject. CompareTag("Player"))
        {
          
            ContactPoint contact = collision.contacts[0];
           
            
            if (Vector3.Dot(contact.normal, Vector3.down) > 0.9f)
            {
                collision.transform.GetComponent<Movement>().MoveTo(direction, JumpForce);
                gameObject.SetActive(false);
            }
        }
    }
}