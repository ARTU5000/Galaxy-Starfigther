using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindajeVFX : MonoBehaviour
{
    public float activeTime = 1f;
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        audioSource.Play();
        Invoke(nameof(Disable), activeTime);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }
}
