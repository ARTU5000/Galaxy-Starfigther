using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPower : MonoBehaviour
{
    public hp1 hpScript;
    public PlayerInput PInput;

    public int powerNum;
    int playernum;
    public Image image;
    public Sprite[] Types;
    public gameManager manager;
    private bool isRolling;
    public bool hasPower;
    public Image backImage;
    public Color[] GunColor;

    public float duration = 5f;
    public float changeRate = 0.2f;
    public DataManager dataManager;
    public int dificulty;
    int difficultyModifier;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<gameManager>();
        playernum = this.gameObject.GetComponent<PlayerInput>().PlayerNum;
        hpScript = this.GetComponent<hp1>();
        PInput = this.GetComponent<PlayerInput>();
        GetHudRef();
        image.sprite = Types[0];
        hasPower = false;
        isRolling = false;
        dataManager = GameObject.FindObjectOfType<DataManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        dificulty = dataManager.dificulty;

        switch (dificulty) 
        {
            case 1:
                difficultyModifier = 2;
                break;
            case 2:
                difficultyModifier = 0;
                break;
            case 3:
                difficultyModifier = -1;
                break;
            default:
                difficultyModifier = 0; 
                break;
        }

        if (other.gameObject.layer == 16 && !hasPower)
        {
            powerNum = difficultyModifier + Random.Range(0, 11);
            RandomAnim();
            Destroy(other.gameObject);
        }

        if (other.gameObject.layer == 17)
        {
            GetNewGun();
            Destroy(other.gameObject);
        }
    }

    public void GetNewGun()
    {
        Debug.Log("getGun");
        int gunIndex = Random.Range(0, 6);
        int PGunIndex = PInput.GetIndex();

        switch (gunIndex)
        {
            case 0:
            case 1:
                if (PGunIndex == 0) 
                {
                    backImage.color = GunColor[1];
                    PInput.ChangeIndex(1);
                    break;
                }
                else
                {
                    backImage.color = GunColor[0];
                    PInput.ChangeIndex(0);
                    break;
                }
            case 2:
            case 3:
                if (PGunIndex == 1) 
                {
                    backImage.color = GunColor[2];
                    PInput.ChangeIndex(2);
                    break;
                }
                else
                {
                    backImage.color = GunColor[1];
                    PInput.ChangeIndex(1);
                    break;
                }
            case 4:
                if (PGunIndex == 2) 
                {
                    backImage.color = GunColor[3];
                    PInput.ChangeIndex(3);
                    break;
                }
                else
                {
                    backImage.color = GunColor[2];
                    PInput.ChangeIndex(2);
                    break;
                }
            case 5:
                backImage.color = GunColor[3];
                PInput.ChangeIndex(3);
                break;
            default:
                backImage.color = GunColor[0];
                break;
        }
    }

    public void RandomAnim()
    {
        hasPower = true;
        if (!isRolling)
            StartCoroutine(RouletteCoroutine());
    }

    private IEnumerator RouletteCoroutine()
    {
        isRolling = true;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            int index = Random.Range(1, Types.Length);
            image.sprite = Types[index];
            yield return new WaitForSeconds(changeRate);
            elapsed += changeRate;
        }

        getPower();

        isRolling = false;
    }

    public void GetHudRef()
    {
        Transform MyHUD = manager.GameHUD[playernum].transform;
        Transform[] allChildren = MyHUD.GetComponentsInChildren<Transform>(true);

        foreach (Transform child in allChildren)
            if (child.name == "ImagePowerUp")
                image = child.GetComponent<Image>();

        foreach (Transform child in allChildren)
            if (child.name == "Back")
                backImage = child.GetComponent<Image>();

        backImage.color = GunColor[0];
    }
    public void getPower()
    {
        switch (powerNum)
        {
            case -1:
            case 0:
            case 1:
            case 2:
                image.sprite = Types[2];
                break;
            case 3:
            case 4:
            case 5:
                image.sprite = Types[3];
                break;
            case 6:
            case 7:
            case 8:
                image.sprite = Types[1];
                break;
            case 9:
            case 10:
            case 11:
            case 12:
                image.sprite = Types[4];
                break;
            default:
                image.sprite = Types[2];
                break;
        }
    }

    public void UsePower(int playerNum)
    {
        switch (powerNum)
        {
            case -1:
            case 0:
            case 1:
            case 2:
                if (hpScript.actual_life <= 3 * (hpScript.total_life / 4) && !isRolling)
                    hpScript.actual_life += hpScript.total_life / 4;
                else if (!isRolling)
                    hpScript.actual_life = hpScript.total_life / 4;
                break;
            case 3:
            case 4:
            case 5:
                if (!isRolling)
                    hpScript.actual_life = hpScript.total_life;
                break;
            case 6:
            case 7:
            case 8:
                if (!isRolling)
                    hpScript.actual_shield = 20;
                break;
            case 9:
            case 10:
            case 11:
            case 12:
                if (!isRolling)
                    hpScript.masVidas();
                break;
            default:
                if (hpScript.actual_life <= 15 && !isRolling)
                    hpScript.actual_life += 5;
                else if (!isRolling)
                    hpScript.actual_life = 20;
                break;
        }

        hasPower = false;
        image.sprite = Types[0];
    }
}
