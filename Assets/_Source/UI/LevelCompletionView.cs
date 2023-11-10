using RingSystem;
using UnityEngine;
using Zenject;

namespace UI
{
    public class LevelCompletionView : MonoBehaviour
    {
        [SerializeField] private GameObject levelCompletionMenu;
        private FinalRing _finalRing;

        [Inject]
        private void Construct(FinalRing finalRing)
        {
            _finalRing = finalRing;
        }

        private void Start()
        {
            _finalRing.OnFinalRingPass += UpdateLevelCompletionMenu;
        }

        private void UpdateLevelCompletionMenu()
        {
            levelCompletionMenu.SetActive(true);
        }
    }
}
