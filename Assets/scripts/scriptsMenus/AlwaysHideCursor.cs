using UnityEngine;

public class AlwaysHideCursor : MonoBehaviour
{
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        Time.timeScale = 1f;
    }
}