using System;
using UnityEngine;

public class StarController : MonoBehaviour
{
    [SerializeField] GameObject itemEffect;
    public float rotationSpeed = 20f;

    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // Call the GetItem() method from the StageController script
            StageController stageController = FindObjectOfType<StageController>();
            if (stageController != null)
            {
                stageController.GetItem();
            }

            // Optionally, you can add an effect when the item is collected.
            if (itemEffect != null)
            {
                Instantiate(itemEffect, transform.position, Quaternion.identity);
            }

            // Disable the star object after being collected.
            gameObject.SetActive(false);
        }
    }
}