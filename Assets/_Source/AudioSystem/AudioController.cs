using AudioSystem.Data;
using UnityEngine;

namespace AudioSystem
{
    public class AudioController : MonoBehaviour
    {
        [field: SerializeField] public AudioSource SfxAudioSource { get; private set; }
        [field: SerializeField] public AudioSource BackgroundAudioSource { get; private set; }
        [field: SerializeField] public GameAudio GameAudio { get; private set; }

        private void Start()
        {
            if (PlayerPrefs.HasKey("SfxVolume"))
            {
                SfxAudioSource.volume = PlayerPrefs.GetFloat("SfxVolume");
            }
            if (PlayerPrefs.HasKey("BackgroundVolume"))
            {
                BackgroundAudioSource.volume = PlayerPrefs.GetFloat("BackgroundVolume");
            }
        }

        public void PlayOneShot(AudioClip audioClip)
        {
            SfxAudioSource.PlayOneShot(audioClip);
        }
    }
}