using AudioSystem;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class AudioSlidersView : MonoBehaviour
    {
        [SerializeField] private Slider sfxSlider;
        [SerializeField] private Slider musicSlider;
        private AudioController _audioController;

        [Inject]
        private void Construct(AudioController audioController)
        {
            _audioController = audioController;
        }
        
        private void Start()
        {
            if (PlayerPrefs.HasKey("SfxVolume"))
            {
                sfxSlider.value = PlayerPrefs.GetFloat("SfxVolume");
            }
            if (PlayerPrefs.HasKey("BackgroundVolume"))
            {
                musicSlider.value = PlayerPrefs.GetFloat("BackgroundVolume");
            }
            
            sfxSlider.onValueChanged.AddListener(delegate { ChangeSfxVolume();});
            musicSlider.onValueChanged.AddListener(delegate { ChangeBackgroundVolume();});
        }

        private void ChangeSfxVolume()
        {
            _audioController.SfxAudioSource.volume = sfxSlider.value;
            PlayerPrefs.SetFloat("SfxVolume", sfxSlider.value);
        }
        
        private void ChangeBackgroundVolume()
        {
            _audioController.BackgroundAudioSource.volume = musicSlider.value;
            PlayerPrefs.SetFloat("BackgroundVolume", musicSlider.value);
        }
    }
}
