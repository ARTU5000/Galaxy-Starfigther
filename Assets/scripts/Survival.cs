using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Survival : MonoBehaviour
{
    public float timr = 0;

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
        timr += Time.deltaTime;

        Perder();
        Ganar();
    }

    void Perder()
    {
        if (gameOver1.activeSelf && gameOver2.activeSelf)
        {
            pause = true;
            Time.timeScale = 0f;
            estadopartida.text = "DERROTA!";
            instructions.text = "oprime R para repetir patrida                oprime M para regresar al menu";
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
            SceneManager.LoadScene("MenuSupervivencia");
        }
    }

    void Ganar()
    {
        if (timr >= 120)
        {
            pause = true;
            Time.timeScale = 0f;
            estadopartida.text = "VICTORIA!";
            instructions.text = "oprime R para repetir patrida                oprime M para regresar al menu";
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
            SceneManager.LoadScene("MenuSupervivencia");
        }
    }
}
