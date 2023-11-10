using ScoreSystem;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI
{
    public class RingScorePopupView : MonoBehaviour
    {
        [SerializeField] private TMP_Text popupText;
        private RingScore _ringScore;

        [Inject]
        private void Construct(RingScore ringScore)
        {
            _ringScore = ringScore;
        }

        private void Start()
        {
            UpdatePopupText();
        }

        private void UpdatePopupText()
        {
            popupText.text = $"{_ringScore.ScoreForRing-1}";
        }
    }
}
