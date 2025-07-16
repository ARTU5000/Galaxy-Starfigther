using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Pausa : MonoBehaviour
{
    public Text instructions;
    private bool pause;
    
    public GameObject boton;

    // Start is called before the first frame update
    void Start()
    {
        pause = false;
        instructions.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause") && pause == false)
        {
            
            instructions.gameObject.SetActive(true);
            pause = true;
            Time.timeScale = 0f;
            instructions.text = "Pausa";
            EventSystem.current.SetSelectedGameObject(null);

            EventSystem.current.SetSelectedGameObject(boton);
        }
        else if (Input.GetButtonDown("Pause") && pause == true)
        {
            pause = false;
            instructions.text = " ";
            Time.timeScale = 1f;
            
            instructions.gameObject.SetActive(false);
        }
    }

    public void unPause()
    {
        if (pause == true)
        {
            pause = false;
            instructions.text = " ";
            Time.timeScale = 1f;
            
            instructions.gameObject.SetActive(false);
        }
    }

    public void Reload()
    {
        if (pause == true)
        {
            pause = false;
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void MainMenu()
    {
        if (pause == true)
        {
            pause = false;
            Time.timeScale = 1f;
            SceneManager.LoadScene("Menu");
        }
    }
}
