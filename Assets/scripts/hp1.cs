using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hp1 : MonoBehaviour
{
    public Image hp;//
    public Image shield;//
    public Image Lives;//
    public float actual_life;
    public float actual_shield;
    private float total_life = 20;
    private float total_shield = 20;
    Rigidbody rb;

   // public Text playerships;//
    public int ships;//
    //public Text gameOver;//
    public int playernum;//
    public GameObject fragment;
    public float posx;
    //public GameObject senuelo;

    public gameManager manager;

    void start()
    {
        manager = FindObjectOfType<gameManager>();
        playernum = this.gameObject.GetComponent<PlayerInput>().PlayerNum;
        //FindHUDObjects();
        actual_life = 20;
        actual_shield = 20;
        rb = GetComponent<Rigidbody>();
        
        ships = 3;
        //playerships.text = ships.ToString();

    }

    public void FindHUDObjects()
    {
        GameObject MyHUD = manager.GameHUD[playernum];
        GameObject[] allChildren = MyHUD.GetComponentsInChildren<GameObject>(true);

        foreach (GameObject child in allChildren)
            if (child.name == "hp")
                hp = child.GetComponent<Image>();

        foreach (GameObject child in allChildren)
            if (child.name == "shield")
                shield = child.GetComponent<Image>();

        foreach (GameObject child in allChildren)
            if (child.name == "nave")
                Lives = child.GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        hp.fillAmount = actual_life / total_life;
        shield.fillAmount = actual_shield / total_shield;

        if (actual_life <= 0)
        {
            if (ships > 0)
            {
                for(int i = 0; i < 5; i++)
                Instantiate(fragment, transform.position, Quaternion.identity);

                actual_life = 20;
                actual_shield = 20;

                ships--;
                //playerships.text = ships.ToString();
                //senuelo.SetActive(false);
            }
            else
            {
                for(int i = 0; i < 5; i++)
                Instantiate(fragment, transform.position, Quaternion.identity);

                //senuelo.SetActive(true);

                //gameOver.text = "JUGADOR " + playernum.ToString() + " HA CAIDO";
                transform.position = new Vector3(posx, -500, -25);

                this.gameObject.SetActive(false);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Normal_shoot"))
        {
            if (actual_shield > 0)
                actual_shield--;
            else
                actual_life--;
        }
        else if (collision.gameObject.CompareTag("Heavy_shoot"))
        {
            if (actual_shield > 0)
                actual_shield -= 4;
            else
                actual_life -= 4;
        }

        if (collision.gameObject.CompareTag("Asteroid") || collision.gameObject.CompareTag("Enemy"))
        {
            if (actual_shield > 0)
                actual_shield -= 2;
            else
                actual_life -= 2;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Respawn")
            transform.position = new Vector3(posx, 0, -25);
    }

    public int vidas()
    {
        return ships;
    }
}