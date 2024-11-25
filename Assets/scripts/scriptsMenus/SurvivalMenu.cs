using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SurvivalMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void nvs1()
    {
        SceneManager.LoadScene("Mapa_1_Survival");
    }

    public void nvs2()
    {
        SceneManager.LoadScene("Mapa_2_Survival");
    }

    public void nvs3()
    {
        SceneManager.LoadScene("Mapa_3_Survival");
    }

    public void nvs4()
    {
        SceneManager.LoadScene("Mapa_4_Survival");
    }

    public void nvs5()
    {
        SceneManager.LoadScene("Mapa_5_Survival");
    }

    public void nvs6()
    {
        SceneManager.LoadScene("Mapa_6_Survival");
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
