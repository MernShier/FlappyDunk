using ScoreSystem;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;
        private Score _score;

        [Inject]
        private void Construct(Score score)
        {
            _score = score;
        }

        private void Start()
        {
            _score.OnBallScoreChange += ScoreTextUpdate;
            ScoreTextUpdate();
        }

        private void ScoreTextUpdate()
        {
            scoreText.text = $"Score: {_score.Value}";
        }
    }
}