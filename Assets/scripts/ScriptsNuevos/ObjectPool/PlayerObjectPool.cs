using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectPool : MonoBehaviour
{
    public GameObject prefab; // Prefab del objeto a instanciar
    [SerializeField] private int initialSize = 10; // Tamaño inicial del pool

    List<GameObject> pool = new List<GameObject>();

    public float reset;
    float timer = 0;

    private void Awake()// crea los proyectiles que se utilizarán
    {
        for (int i = 0; i < initialSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }
    private void Start()
    {// cada cierto tiempo de desactiva un proyectil para evitar quedarse sin proyectiles
        InvokeRepeating("DeActivate",reset,reset);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= reset)
        {
            DeActivate();
            timer = 0;
        }
    }

    public GameObject Spawn()//activa un proyectil del pool y lo asigna
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeSelf)
            {
                obj.SetActive(true);
                return obj;
            }
        }
        return null;
    }
    
    void DeActivate()//Desactiva un proyectil del pool
    {
        foreach (GameObject obj in pool)
        {
            if (obj.activeSelf)
            {
                obj.SetActive(false);
                break;
            }
        }
    }
    public void DestroyAll()
    {
        foreach (var obj in pool)
        {
            if (obj != null)
            {
                Destroy(obj);
            }
        }
        // Limpia la lista después de destruir los objetos del pool
        pool.Clear();
    }
}
