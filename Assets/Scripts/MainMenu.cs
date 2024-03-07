using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject recordsPanel, menuPanel;
    [SerializeField] TMPro.TextMeshProUGUI textRecord1, textRecord2, textRecord3, textRecord4, textRecord5;



    public void PlayButton()
    {
        SceneManager.LoadScene("Nivel1");
        audioSource.Play();
    }


    public void ShowRecords()
    {
        if (menuPanel.activeSelf)
        {
            menuPanel.SetActive(false);
            recordsPanel.SetActive(true);
        }
        List<int> records = new List<int>();
        records = SaveManager.LoadRecords();

        if(records.Count > 0)
        {
            textRecord1.text = "1: " + records[0];
            if(records.Count > 1)
            {
                textRecord2.text = "2: " + records[1];
            }
            else
            {
                textRecord4.text = "2: " + 0;
            }

            if (records.Count > 2)
            {
                textRecord3.text = "3: " + records[2];
            }
            else
            {
                textRecord4.text = "3: " + 0;
            }

            if (records.Count > 3)
            {
                textRecord4.text = "4: " + records[3];
            }
            else
            {
                textRecord4.text = "4: " + 0;
            }

            if (records.Count > 4)
            {
                textRecord5.text = "5: " + records[4];
            }
            else
            {
                textRecord4.text = "5: " + 0;
            }

        }
        else
        {
            textRecord1.text = "1: " + 0;
        }
        
    }

    public void ShowMenu()
    {
        if (recordsPanel.activeSelf)
        {
            recordsPanel.SetActive(false);
            menuPanel.SetActive(true);
        }
    }
}
