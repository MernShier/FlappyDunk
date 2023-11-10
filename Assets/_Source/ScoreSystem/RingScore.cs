using System;
using System.Collections;
using UnityEngine;
using Utils;

namespace ScoreSystem
{
    public class RingScore
    {
        private const int BASE_SCORE_FOR_RING = 1;
        private const int BASE_SCORE_MULT = 1;
        private AsyncProcessor _asyncProcessor;
        public event Action OnRingScoreChange;
        public float ScoreForRing { get; private set; }
        public float ScoreMult { get; private set; }

        private RingScore(AsyncProcessor asyncProcessor)
        {
            _asyncProcessor = asyncProcessor;
            ScoreForRing = BASE_SCORE_FOR_RING;
            ScoreMult = BASE_SCORE_MULT;
        }
        
        public void AddScoreForRing()
        {
            ScoreForRing += BASE_SCORE_FOR_RING * ScoreMult;
            OnRingScoreChange?.Invoke();
        }
        
        public void ResetScoreForRing()
        {
            ScoreForRing = BASE_SCORE_FOR_RING * ScoreMult;
            OnRingScoreChange?.Invoke();
        }
        
        public void StartMultiplyScore(float duration, float mult)
        {
            _asyncProcessor.StartCoroutine(MultiplyScore(duration, mult));
        }
        
        private IEnumerator MultiplyScore(float duration, float mult)
        {
            ScoreMult += mult - 1;
            ScoreForRing *= ScoreMult;
            OnRingScoreChange?.Invoke();
            
            yield return new WaitForSeconds(duration);
            
            ScoreForRing /= ScoreMult;
            ScoreMult -= mult - 1;
            OnRingScoreChange?.Invoke();
        }
    }
}
