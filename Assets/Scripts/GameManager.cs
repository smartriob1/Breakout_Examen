using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Para poder usar SceneManager

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int blocksLeft; // Bloques restantes en la escena

    public int vidas = 3;

    [SerializeField] private int pointsPerBlock = 10; // Puntos por bloque
    public int points = 0; // Puntos actuales


    private void Awake()
    {
        // Patrón Singleton
        if (Instance != null && Instance != this) // Si ya existe una instancia de GameManager
        {
            Destroy(gameObject); // Destruimos el objeto
        }
        else // Si no existe una instancia de GameManager
        {
            Instance = this; // La creamos
            DontDestroyOnLoad(gameObject); // No se destruirá al cargar una nueva escena
        }
    }

    public void LoadBlocks()
    {
        /* FindGameObjectsWithTag nos permite obtener todos los objetos con una etiqueta determinada
         y nos los devuelve en un array de GameObjects
        */
        blocksLeft = GameObject.FindGameObjectsWithTag("block").Length; // Obtenemos el número de bloques en la escena
        Debug.Log("Blocks left: " + blocksLeft);
    }

    public void BlockDestroyed()
    {
        blocksLeft--; // Restamos un bloque
        FindObjectOfType<UIManager>().AddScore(pointsPerBlock); // Añadimos puntos
        points += pointsPerBlock; // Añadimos puntos
        if (blocksLeft <= 0) // Si no quedan bloques
        {
            Debug.Log("Level completed!");
            LoadNextLevel(); // Cargamos el siguiente nivel
        }
    }

    private void LoadNextLevel()
    {
         
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Recargamos la escena actual
    }

    public void LoseLife()
    {
        
        vidas--; // Restamos una vida
        FindObjectOfType<UIManager>().LoseLife();
        if (vidas <= 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene("GameOver");
            // TODO: Modificar GameOver para retry
        } else {
            ResetLevel(); // Recargamos la escena
        }       
    }

    public void LoseLifePowerUp()
    {
        vidas--; // Restamos una vida
        FindObjectOfType<UIManager>().LoseLife();
        if (vidas <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void AddLife()
    {
        vidas++; // Añadimos una vida
        FindObjectOfType<UIManager>().AddLife();
    }

    public void ResetLevel()
    {
        FindObjectOfType<Player>().ResetPlayer(); // Reseteamos la posición del jugador
        FindObjectOfType<Ball>().ResetBall(); // Reseteamos la posición de la bola
    }

    public void ResetGame()
    {
        points = 0; // Reseteamos los puntos
        vidas = 3; // Reseteamos las vidas
    }
}
