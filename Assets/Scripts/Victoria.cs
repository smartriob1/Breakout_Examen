using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victoria : MonoBehaviour
{
    void Start()
    {
        SaveManager.SaveRecord(GameManager.Instance.points);
        GameManager.Instance.ResetGame();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
