using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Versus : MonoBehaviour
{ 
    public GameObject gameOver1;
    public GameObject gameOver2;

    public Text estadopartida;
    public Text instructions;

    private bool pause;
    // Start is called before the first frame update
    void Start()
    {
        pause = false;
    }

    // Update is called once per frame
    void Update()
    {
        GanarJ1();
        GanarJ2();
    }

    void GanarJ1()
    {
        if (gameOver1.activeSelf)
        {
            pause = true;
            Time.timeScale = 0f;
            estadopartida.text = "¡GANO J2!";
            instructions.text = "oprime R para repetir patrida                oprime M para regresar al menú";
        }
        else if (Input.GetKey(KeyCode.R) && pause == true)
        {

            pause = false;
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (Input.GetKey(KeyCode.M) && pause == true)
        {

            pause = false;
            Time.timeScale = 1f;
            SceneManager.LoadScene("MenuVersus");
        }
    }

    void GanarJ2()
    {
        if (gameOver2.activeSelf)
        {
            pause = true;
            Time.timeScale = 0f;
            estadopartida.text = "¡GANO J1!";
            instructions.text = "oprime R para repetir patrida                oprime M para regresar al menú";
        }
        else if (Input.GetKey(KeyCode.R) && pause == true)
        {

            pause = false;
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (Input.GetKey(KeyCode.M) && pause == true)
        {

            pause = false;
            Time.timeScale = 1f;
            SceneManager.LoadScene("MenuVersus");
        }
    }
}
