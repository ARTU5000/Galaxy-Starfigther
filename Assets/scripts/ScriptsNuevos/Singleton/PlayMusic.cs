using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public AudioClip music;
    public float volume;

    private void Start()
    {
        if (music != null && !IsClipPlaying(music))
        {
            AudioManager.Instance.PlayAudioClip(music, volume); // Reproduce el clip
        }
        else
        {
            Debug.LogWarning("No se asignó un AudioClip.");
        }
    }

    private bool IsClipPlaying(AudioClip music) // Revisa si se esta tocando un clip y si es el mismo clip el que ya se esta tocando
    {
        return AudioManager.Instance.AudioSource.isPlaying && AudioManager.Instance.AudioSource.clip == music;
    }
}
