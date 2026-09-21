using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] public AudioMixer audioMixer;
    [SerializeField] public Slider volumeGPSlider;
    [SerializeField] public Slider volumeSFXSlider;
    [SerializeField] public Slider volumeUISlider;



    void Awake()
    {
        volumeGPSlider.onValueChanged.AddListener(SetGameplayVolume);
        volumeSFXSlider.onValueChanged.AddListener(SetSFXVolume);
        volumeUISlider.onValueChanged.AddListener(SetUIVolume);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        volumeGPSlider.onValueChanged.RemoveAllListeners();
        volumeSFXSlider.onValueChanged.RemoveAllListeners();
        volumeUISlider.onValueChanged.RemoveAllListeners();
    }
    private void SetGameplayVolume(float volume)
    {
        audioMixer.SetFloat("GameplayVolume", volume);
    }
    private void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", volume);

    }
    private void SetUIVolume(float volume)
    {
        audioMixer.SetFloat("UIVolume", volume);

    }
}
