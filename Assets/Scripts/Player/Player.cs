using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public Character character;
    private bool isDragging = false;
    private Vector3 dragStartPos;
    private Vector3 dragEndPos;
    public float rollForce = 10f;
    private float draggingTime = 0f;
    private float maxDraggingTime = 1f;

    [Header("Combate")]
    private Rigidbody targetRb;
    private Character targetCharacter;
    private Vector3 pushDirection;
    public float pushDuration = 0.5f;
    private bool isPushing = false;
    private float pushTimer = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        character = GetComponent<Character>();
    }

    private void FixedUpdate()
    {
        if (isPushing)
        {
            if (pushTimer < pushDuration)
            {
                float pushForceInterpolated = Mathf.Lerp((character.strength + PlayerPrefs.GetInt("Strength") - targetCharacter.resistance + rb.velocity.x + rb.velocity.z), 0f, pushTimer / pushDuration);

                targetRb.AddForce(pushDirection * pushForceInterpolated, ForceMode.Force);

                pushTimer += Time.fixedDeltaTime;
            }
            else
            {
                isPushing = false;
            }
        }
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                isDragging = true;
                dragStartPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved && draggingTime < maxDraggingTime)
            {
                dragEndPos = touch.position;
                ApplyRollForce();
                draggingTime += Time.fixedDeltaTime;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isDragging = false;
                draggingTime = 0;
            }
        }
    }

    private void ApplyRollForce()
    {
        Vector3 dragDir = dragEndPos - dragStartPos;
        dragDir.Normalize();

        Vector3 rollForceVector = new Vector3(dragDir.x, 0f, dragDir.y) * rollForce * 0.4f;

        rb.AddForce(rollForceVector, ForceMode.Impulse);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            targetRb = collision.gameObject.GetComponent<Rigidbody>();
            targetCharacter = collision.gameObject.GetComponent<Character>();

            if (targetRb != null)
            {
                isPushing = true;
                pushDirection = (collision.transform.position - transform.position).normalized;
                pushTimer = 0f;
                Debug.Log("PUSH!");
            }
        }
    }
}