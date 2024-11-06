using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
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
        if (Input.GetKeyDown(KeyCode.Space) && pause == false)
        {
            pause = true;
            Time.timeScale = 0f;
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
            SceneManager.LoadScene("MenuSupervivencia");
        }
        else if (Input.GetKeyDown(KeyCode.Space) && pause == true)
        {
            pause = false;
            instructions.text = " ";
            Time.timeScale = 1f;
        }
    }
}
