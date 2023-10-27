using System;

namespace BallSystem
{
    public class BallScorer
    {
        public event Action OnBallScoreChange;
        public int Score { get; private set; }

        public void AddScore(int value)
        {
            Score += value;
            OnBallScoreChange?.Invoke();
        }
    }
}