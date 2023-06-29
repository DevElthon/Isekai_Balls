using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target; 
    public float distance = 10f; 
    public float height = 10f; 
    public float smoothSpeed = 0.5f;
    private Vector3 offset;
    public float minX = -10f; 
    public float maxX = 10f; 
    public float minZ = -10f; 
    public float maxZ = 10f;

    private void Start()
    {
        offset = new Vector3(0f, height, -distance);

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        if(target == null)
            return;
    }

    private void LateUpdate()
    {
        if (target == null)
        {
            return;
        }

        Vector3 desiredPosition = target.position + offset;

        float clampedX = Mathf.Clamp(desiredPosition.x, minX, maxX);
        float clampedY = desiredPosition.y; 
        float clampedZ = Mathf.Clamp(desiredPosition.z, minZ, maxZ);

        Vector3 clampedPosition = new Vector3(clampedX, clampedY, clampedZ);

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, clampedPosition, smoothSpeed * Time.deltaTime);

        transform.position = smoothedPosition;

        // transform.LookAt(target);
    }
}