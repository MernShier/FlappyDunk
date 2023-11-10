using System;
using Collision.Data;
using ScoreSystem;
using UnityEngine;
using Utils;
using Utils.Extensions;
using Zenject;

namespace RingSystem
{
    public abstract class Ring : MonoBehaviour
    {
        [SerializeField] private GameObject ringScorePopup;
        private CollisionConfig _collisionConfig;
        private UniversalParent _universalParent;
        private DiContainer _diContainer;
        public event Action OnRingDestroy;

        [Inject]
        private void Construct(CollisionConfig collisionConfig, UniversalParent universalParent, DiContainer diContainer)
        {
            _collisionConfig = collisionConfig;
            _universalParent = universalParent;
            _diContainer = diContainer;
        }
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (_collisionConfig.BallLayer.Contains(col.gameObject.layer))
            {
                Pass(col);
            }
        }

        protected virtual void Pass(Collider2D passer)
        {
            _diContainer.InstantiatePrefab(ringScorePopup, transform.position, Quaternion.identity, _universalParent.transform);
            DestroyRing();
        }

        public void DestroyRing()
        {
            OnRingDestroy?.Invoke();
            transform.parent.gameObject.SetActive(false);
        }
    }
}