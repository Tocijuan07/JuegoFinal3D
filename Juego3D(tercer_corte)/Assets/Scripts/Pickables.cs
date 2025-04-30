using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rorb : MonoBehaviour
{
    public GameObject player;
    public Health health;
    public FPSController fpsController;

    public string type;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        health = player.GetComponent<Health>();
        fpsController = player.GetComponent<FPSController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.ToString());
        if (collision.gameObject.CompareTag("Player"))
        {
            switch (type)
            {
                case "RedOrb":
                    health.health += 10; 
                    break;

                case "Torch":
                    health.health += 10; // Ejemplo: el orbe cura al jugador
                    break;

                case "SpeedOrb":
                    fpsController.WalkSpeed += 2; // Ejemplo: aumenta velocidad
                    break;

                default:
                    Debug.LogWarning("Tipo de orbe desconocido: " + type);
                    break;
            }

            Destroy(gameObject); // El orbe desaparece al recogerlo
        }
    }
}
