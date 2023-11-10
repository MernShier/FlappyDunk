using System;
using UnityEngine;

namespace RingSystem
{
    public class FinalRing : Ring
    {
        public event Action OnFinalRingPass;
        protected override void Pass(Collider2D passer)
        {
            OnFinalRingPass?.Invoke();
            base.Pass(passer);
        }
    }
}
