using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroEnemy : MonoBehaviour
{
    [Header("Elementos")]
    [SerializeField]
    private Transform target; 
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float smoothness = 0.5f;

    private Rigidbody rb;
    public Character character;

    [Header("Combate")]
    private Rigidbody targetRb;
    private Character targetCharacter;
    private Vector3 pushDirection;

    public float pushDuration = 0.5f; // Duração do empurrão

    private bool isPushing = false;
    private float pushTimer = 0f;

    private void Awake() {
        target= GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (target == null)
        {
            return;
        }
    }

    private void Start()
    {
        character = GetComponent<Character>();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //Movimento
        if (target == null)
        {
            Debug.LogWarning("Alvo não definido para o objeto!");
            return;
        }
        Vector3 direction = (target.position - transform.position).normalized;

        float smoothSpeed = speed * smoothness;

        rb.AddForce(direction * smoothSpeed);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, speed);

        //Empurrão
        if (isPushing)
        {
            if (pushTimer < pushDuration)
            {
                float pushForceInterpolated = Mathf.Lerp(character.strength - targetCharacter.resistance + rb.velocity.x + rb.velocity.z, 0f, pushTimer / pushDuration);

                targetRb.AddForce(pushDirection * pushForceInterpolated, ForceMode.Force);

                pushTimer += Time.fixedDeltaTime;
            }
            else
            {
                isPushing = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            targetRb = collision.gameObject.GetComponent<Rigidbody>();
            targetCharacter = collision.gameObject.GetComponent<Character>();

            if (targetRb != null)
            {
                isPushing = true;
                pushDirection = (collision.transform.position - transform.position).normalized;
                pushTimer = 0f;
            }
        }
    }
}