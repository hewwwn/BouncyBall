using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]  Transform target;
    [SerializeField]  float minDistance = 3f;

    [SerializeField] float maxDistance = 30f;

    [SerializeField] float wheelSpeed = 500f;

    [SerializeField] float xMoveSpeed = 500f;

    [SerializeField] float yMoveSpeed = 200f;
    private float yMinLimit = 5f;
    private float yMaxLimit = 80f;
    private float x, y;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        distance = Vector3.Distance(transform.position, target.position);
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null) return;

        if (Input.GetMouseButton(1))
        {
            x += Input.GetAxis("Mouse X") * xMoveSpeed * Time.deltaTime;
            y += Input.GetAxis("Mouse Y") * yMoveSpeed * Time.deltaTime;

            y = ClampAngle(y, yMinLimit, yMaxLimit);
            transform.rotation = Quaternion.Euler(y, x, 0);
        }

        distance -= Input.GetAxis("Mouse ScrollWheel") * wheelSpeed * Time.deltaTime;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);
        
    }

    private void LateUpdate()
    {
        if (target == null) return;

        transform.position = transform.rotation * new Vector3(0, 0, -distance) + target.position;
    }

    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;

        return Mathf.Clamp(angle, min, max);
    }
}
