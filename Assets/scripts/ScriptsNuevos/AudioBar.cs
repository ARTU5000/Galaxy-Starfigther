using UnityEngine;
using UnityEngine.UI;

public class GlobalVolumeListener : MonoBehaviour
{
    public Slider volumeSlider; // Asignar desde el Inspector

    void Start()
    {
        volumeSlider.value = AudioListener.volume;

        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float value)
    {
        AudioListener.volume = value; // 0 a 1
    }
}