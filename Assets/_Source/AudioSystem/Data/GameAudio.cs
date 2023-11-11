using System;
using UnityEngine;

namespace AudioSystem.Data
{
    [Serializable]
    public class GameAudio
    {
        [field:SerializeField] public AudioClip RingPass { get; set; }
        [field:SerializeField] public AudioClip CollectiblePickup { get; set; }
        [field:SerializeField] public AudioClip Death { get; set; }
        [field:SerializeField] public AudioClip Tap { get; set; }
    }
}
