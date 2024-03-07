using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ball")) // Si colisionamos con la bola
        {
            // GameManager.Instance.ReloadScene(); // Recargamos la escena
            GameManager.Instance.LoseLife();
            GetComponent<AudioSource>().Play();
        }

        if (collision.CompareTag("powerUp")) // Si colisionamos con un powerUp lo destruimos
        {
            Destroy(collision.gameObject);
        }
    }
}
