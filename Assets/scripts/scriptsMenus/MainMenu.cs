using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Credits()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void Controls()
    {
        SceneManager.LoadScene("Controles");
    }

    public void Versus()
    {
        //SceneManager.LoadScene("MenuVersus");
    }

    public void Survival()
    {
        SceneManager.LoadScene("Mapa_2_Survival");
    }

     public void exit()
    {
        Application.Quit();
    }
}
