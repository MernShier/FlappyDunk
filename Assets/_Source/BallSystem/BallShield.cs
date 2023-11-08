using System;

namespace BallSystem
{
    public class BallShield
    {
        public event Action OnBallShieldChange;
        public event Action OnBallMaxShieldChange;
        public int Shield { get; private set; }
        public int MaxShield { get; private set; }

        public void AddShield(int value)
        {
            Shield = Math.Clamp(Shield + value, 0, MaxShield);
            OnBallShieldChange?.Invoke();
        }
        
        public void SetMaxShield(int value)
        {
            MaxShield = value;
            OnBallMaxShieldChange?.Invoke();
        }
    }
}