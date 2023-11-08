using System;

namespace ScoreSystem
{
    public class Score
    {
        public event Action OnBallScoreChange;
        public float Value { get; private set; }

        public void ChangeScore(float value)
        {
            Value += value;
            OnBallScoreChange?.Invoke();
        }
    }
}