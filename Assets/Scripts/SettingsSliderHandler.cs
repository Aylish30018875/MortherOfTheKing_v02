using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SettingsSliderHandler : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Text _sliderText;

    private void Start()
    {
        _slider.onValueChanged.AddListener((v) => 
        {
            _sliderText.text = v.ToString();
        });
    }

    //Listing the sliders to try and access them for saving and loading the settings
    public Slider masterVolumeSlider;
    public Slider menuMusicSlider;
    public Slider ambientMusicSlider;
    public Slider soundEffectsSlider;
    public Slider towerSoundEffectsSlider;
    public Slider enemySoundEffectsSlider;
    public Slider dialogueVolumeSlider;
    public Slider cutsceneVolumeSlider;


}
