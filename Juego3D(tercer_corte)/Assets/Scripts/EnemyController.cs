using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3f;
    public int damage = 10;
    public float pushBackForce = 5f;
    public AudioSource hurtScream;
    private GameObject player;
    private Health playerHealth;
    private Rigidbody rb;

    void Start()
    {
        player = GameObject.FindWithTag("Player"); // Asegúrate de que el jugador tenga el tag "Player"
        if (player != null)
        {
            playerHealth = player.GetComponent<Health>();
        }
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (player != null)
        {
            // Mover al enemigo hacia el jugador
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (playerHealth != null)
            {
                playerHealth.health -= damage;
                hurtScream.Play();
            }
            Vector3 pushDirection = (transform.position - collision.transform.position).normalized;
            rb.AddForce(pushDirection * pushBackForce, ForceMode.Impulse);
        }
    }
}
