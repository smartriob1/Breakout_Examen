using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    /*
    Los límites definidos con bound nos hacen falta debido a que el jugador se puede salir de la pantalla
    debido a que su rigidbody es quinemático, por lo que no se ve afectado por la gravedad ni puede colisionar
    con objetos estáticos.
    */
    [SerializeField] private float bound = 4.5f; // x axis bound 

    private Vector2 startPos; // Posición inicial del jugador
    private bool powerUp = false;
    private float segundos;
    private Vector3 tamañoNormal;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position; // Guardamos la posición inicial del jugador
        tamañoNormal = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
       PlayerMovement();
        if(powerUp)
        {
            segundos -= Time.deltaTime;
            if(segundos <= 0)
            {
                DecrementarTamaño();
            }
        }
    }

    void PlayerMovement()
    {
         float moveInput = Input.GetAxisRaw("Horizontal");
        // Controlaríamo el movimiento de la siguiente forma de no ser el rigidbody quinemático
        // transform.position += new Vector3(moveInput * speed * Time.deltaTime, 0f, 0f);

        Vector2 playerPosition = transform.position;
        // Mathf.Clamp nos permite limitar un valor entre un mínimo y un máximo
        playerPosition.x = Mathf.Clamp(playerPosition.x + moveInput * speed * Time.deltaTime, -bound, bound);
        transform.position = playerPosition;
    }

    public void ResetPlayer()
    {
        transform.position = startPos; // Posición inicial del jugador
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("powerUp.AddLife")) // Si colisionamos con un powerUp
        {
            Destroy(collision.gameObject); // Lo destruimos
            GameManager.Instance.AddLife(); // Añadimos una vida
        }
        if (collision.CompareTag("powerUp.LoseLife")) // Si colisionamos con un powerUp
        {
            Destroy(collision.gameObject); // Lo destruimos
            GameManager.Instance.LoseLifePowerUp(); // Añadimos una vida
        }
        if (collision.CompareTag("powerUp.Plataforma")) // Si colisionamos con un powerUp
        {
            Destroy(collision.gameObject); // Lo destruimos
            AlargarTamaño(); // Añadimos una vida
        }
    }

    private void AlargarTamaño()
    {
        if (!powerUp)
        {
            powerUp = true;
            transform.localScale = new Vector3(transform.localScale.x * 2, transform.localScale.y, transform.localScale.z);
        }
        segundos = 10f;
        
    }

    private void DecrementarTamaño()
    {
        powerUp = false;
        transform.localScale = tamañoNormal;
    }
}
