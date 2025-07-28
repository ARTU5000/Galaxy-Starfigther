using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSet : MonoBehaviour
{
    public Text numero;
    public DataManager dataManager;
    public int maxTime;
    // Start is called before the first frame update
    void Start()
    {
        dataManager = GameObject.FindObjectOfType<DataManager>();
        maxTime = 120;
        dataManager.SetMaxPlayTime(maxTime);
        numero.text = maxTime.ToString();
    }

    public void AddTime()
    {
        if (maxTime < 300)
        {
            maxTime += 20;
            dataManager.SetMaxPlayTime(maxTime);
            numero.text = maxTime.ToString();
        }
        else
        {
            maxTime = 300;
            dataManager.SetMaxPlayTime(maxTime);
            numero.text = maxTime.ToString();
        }
    }

    public void RemoveTime()
    {
        if (maxTime > 0)
        {
            maxTime -= 20;
            dataManager.SetMaxPlayTime(maxTime);
            numero.text = maxTime.ToString();
        }
        else
        {
            maxTime = 0;
            dataManager.SetMaxPlayTime(maxTime);
            numero.text = maxTime.ToString();
        }
    }
}
