using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI text;
    [SerializeField] private GameObject[] lifes;
    [SerializeField] GameManager gameManager;

    void Awake()
    {
        text = GameObject.Find("Score").GetComponent<TMPro.TextMeshProUGUI>();
        lifes = GameObject.FindGameObjectsWithTag("life");
        /*
        while(gameManager == null) {
            gameManager = GameManager.Instance;
        }
        */
        gameManager = GameManager.Instance;
        gameManager.LoadBlocks();
    }

    void Start()
    {
        SetScore(gameManager.points);
        SetLifes(gameManager.vidas);
    }

   public void AddScore(int score)
   {
        
        int points = int.Parse(text.text);
        points += score;
        text.text = points.ToString();
   }

   public void ResetScore()
   {
        text.text = "0";
   }

   public void SetScore(int score)
   {
        text.text = score.ToString();
   }

   public void SetLifes(int vidas) 
   {
        foreach (var life in lifes)
        {
            life.SetActive(false);
        }
        for (int i = 0; i < vidas; i++)
        {
            lifes[i].SetActive(true);
        }
   }

   public void LoseLife()
   {
        for (int i = lifes.Length -1; i > 0; i--)
        {
            if(lifes[i].activeSelf) 
            {
                lifes[i].SetActive(false);
                break;
            }
        }
   }

   public void AddLife()
   {
        for (int i = 0; i < lifes.Length; i++)
        {
            if(!lifes[i].activeSelf) 
            {
                lifes[i].SetActive(true);
                break;
            }
        }
   }


}
