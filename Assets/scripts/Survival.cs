using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class Survival : MonoBehaviour
{
    public float timr = 0;

    public GameObject gameOver1;
    public GameObject gameOver2;

    public Text estadopartida;
    public Text instructions;
    public GameObject InvButton;

    public GameObject PauseObj;

    public List<GameObject> Players = new List<GameObject>();

    bool allDown;

    public int timeToPlay;

    private bool pause;

    
    public DataManager dataManager;
    // Start is called before the first frame update
    void Start()
    {
        allDown = false;
        pause = false;
        instructions.gameObject.SetActive(false);

        dataManager = GameObject.FindObjectOfType<DataManager>();
        timeToPlay = dataManager.maxPlayTime;
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
        foreach (GameObject p in Players)
        {
            if (p.activeSelf)
            {
                allDown = false; break;
            }
            else
            {
                allDown = true;
            }
        }
        
        if (allDown == true && pause == false)
        {
            instructions.gameObject.SetActive(true);

            pause = true;
            Time.timeScale = 0f;
            estadopartida.text = "DERROTA!";
            Final();
        }
    }

    void Ganar()
    {
        if (timr >= timeToPlay && pause == false)
        {
            instructions.gameObject.SetActive(true);

            pause = true;
            Time.timeScale = 0f;
            estadopartida.text = "VICTORIA!";
            Final();
        }
    }

    void Final()
    {
        PauseObj.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(InvButton);
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
