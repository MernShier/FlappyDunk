using System;

namespace BallSystem
{
    public class BallScorer
    {
        public event Action OnBallScoreChange;
        public float Score { get; private set; }

        public void AddScore(float value)
        {
            Score += value;
            OnBallScoreChange?.Invoke();
        }
    }
}