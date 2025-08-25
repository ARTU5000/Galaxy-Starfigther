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
    public float ships;//
    public float total_ships;
    //public Text gameOver;//
    public int playernum;//
    public GameObject fragment;
    public GameObject vfx; 
    public GameObject vfx2; 
    public GameObject Shieldvfx; 
    public GameObject Hpvfx2; 
    public float posx;
    //public GameObject senuelo;

    public gameManager manager;
    public DataManager dataManager;

    bool assigned = false;

    void Start()
    {
        manager = FindObjectOfType<gameManager>();
        playernum = this.gameObject.GetComponent<PlayerInput>().PlayerNum;
        dataManager = GameObject.FindObjectOfType<DataManager>();
        FindHUDObjects();
        int dificulty = dataManager.dificulty;
        total_life = (dificulty + 1) * 10;
        actual_life = total_life;
        actual_shield = 0;
        rb = GetComponent<Rigidbody>();
        
        ships = 3;
        total_ships = 3;
        //playerships.text = ships.ToString();
        dataManager.SetRemainingLifes(playernum, ships);
    }

    public void FindHUDObjects()
    {
        Transform MyHUD = manager.GameHUD[playernum].transform;
        Transform[] allChildren = MyHUD.GetComponentsInChildren<Transform>(true);

        foreach (Transform child in allChildren)
            if (child.name == "hp")
                hp = child.GetComponent<Image>();

        foreach (Transform child in allChildren)
            if (child.name == "shield")
                shield = child.GetComponent<Image>();

        foreach (Transform child in allChildren)
            if (child.name == "nave")
                Lives = child.GetComponent<Image>();
        Lives.fillAmount = 0;
        assigned = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (assigned)
        {
            hp.fillAmount = actual_life / total_life;
            shield.fillAmount = actual_shield / total_shield;

            if(actual_shield > 0)
                Shieldvfx.SetActive(true);
            else
                Shieldvfx.SetActive(false);

            if (actual_life <= 0)
            {
                
                CameraShake.instance.Shake(0.4f, 2f);
                dataManager.PlayerDown(Time.time, playernum);
                if (ships > 0)
                {
                    for (int i = 0; i < 5; i++)
                        Instantiate(fragment, transform.position, Quaternion.identity);
                        
                    GameObject.Instantiate(vfx, transform.position, Quaternion.identity);

                    actual_life = 20;
                    actual_shield = 0;

                    ships--;

                    //Debug.Log((total_ships - ships) / total_ships);
                    Lives.fillAmount = (total_ships - ships) / total_ships;


                    //playerships.text = ships.ToString();
                    //senuelo.SetActive(false);
                    dataManager.SetRemainingLifes(playernum, ships);
                }
                else
                {
                    for (int i = 0; i < 5; i++)
                        Instantiate(fragment, transform.position, Quaternion.identity);

                    GameObject.Instantiate(vfx2, transform.position, Quaternion.identity);
                    //senuelo.SetActive(true);

                    //gameOver.text = "JUGADOR " + playernum.ToString() + " HA CAIDO";
                    transform.position = new Vector3(posx, -500, -25);

                    this.gameObject.SetActive(false);
                }
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Normal_shoot"))
        {
            CameraShake.instance.Shake(0.3f, 0.5f);
            Hpvfx2.SetActive(true);
            if (actual_shield > 0)
                actual_shield--;
            else
                actual_life--;
        }
        else if (collision.gameObject.CompareTag("Heavy_shoot"))
        {
            CameraShake.instance.Shake(0.3f, 0.8f);
            Hpvfx2.SetActive(true);
            if (actual_shield > 0)
                actual_shield -= 4;
            else
                actual_life -= 4;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            CameraShake.instance.Shake(0.3f, 0.8f);
            Hpvfx2.SetActive(true);
            if (actual_shield > 0)
                actual_shield -= 2;
            else
                actual_life -= 2;
        }
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            CameraShake.instance.Shake(0.3f, 0.5f);
            Hpvfx2.SetActive(true);
            if (actual_shield > 0)
                actual_shield --;
            else
                actual_life --;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Respawn")
            transform.position = new Vector3(posx, 0, -25);
    }

    public void masVidas()
    {
        ships++;

        if (ships > total_ships)
            ships = total_ships;

        Lives.fillAmount = (total_ships - ships) / total_ships;
        dataManager.SetRemainingLifes(playernum, ships);
    }
}