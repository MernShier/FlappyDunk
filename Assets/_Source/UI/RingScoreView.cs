using ScoreSystem;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI
{
    public class RingScoreView : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;
        private RingScore _ringScore;

        [Inject]
        private void Construct(RingScore ringScore)
        {
            _ringScore = ringScore;
        }

        private void Start()
        {
            _ringScore.OnRingScoreChange += RingScoreTextUpdate;
            RingScoreTextUpdate();
        }

        private void RingScoreTextUpdate()
        {
            scoreText.text = $"x{_ringScore.ScoreForRing}";
        }
    }
}